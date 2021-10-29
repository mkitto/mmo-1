using Common;
using GameServer.Entities;
using GameServer.Managers;
using GameServer.Models;
using Network;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Services
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/29 22:19:45
    /// subscribe：XXX
    /// </summary>
    class TeamService: Singleton<TeamService>
    {
        public TeamService()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<TeamInviteRequest>(this.OnTeamInviteRequest);
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<TeamInviteResponse>(this.OnTeamInviteResponse);
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<TeamLeaveRequest>(this.OnTeamLeave);
        }

        public void Init()
        {
            TeamManager.Instance.Init();
        }

        /// <summary>
        /// 收到组队请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="request"></param>
        void OnTeamInviteRequest(NetConnection<NetSession> sender, TeamInviteRequest request)
        {
            Character character = sender.Session.Character;
            Log.InfoFormat("OnTeamInviteRequest: FromId: {0}, FromName: {1}, ToId: {2}, ToName: {3}", request.FromId, request.FromName, request.ToId, request.ToName);
            // TODO: 执行一些前置数据校验

            // 开始逻辑
            NetConnection<NetSession> target = SessionManager.Instance.GetSession(request.ToId);
            if (target == null)
            {
                sender.Session.Response.teamInviteRes = new TeamInviteResponse();
                sender.Session.Response.teamInviteRes.Result = Result.Failed;
                sender.Session.Response.teamInviteRes.Errormsg = "好友不在线";
                sender.SendResponse();
                return;
            }

            if (sender.Session.Character.Team != null)
            {
                sender.Session.Response.teamInviteRes = new TeamInviteResponse();
                sender.Session.Response.teamInviteRes.Result = Result.Failed;
                sender.Session.Response.teamInviteRes.Errormsg = "对方已经有队伍";
                sender.SendResponse();
                return;
            }
            // 转发请求
            Log.InfoFormat("ForwardTeamInviteRequest: FromId: {0}, FromName: {1}, ToID: {2}, ToName: {3}", request.FromId, request.FromName.Length, request.ToId, request.ToName);
            target.Session.Response.teamInviteReq = request;
            target.SendResponse();
        }

        void OnTeamInviteResponse(NetConnection<NetSession> sender, TeamInviteResponse response)
        {
            Character character = sender.Session.Character;
            Log.InfoFormat("OnTeamInviteResponse: character: {0}, Result: {1}, FromId: {2}, ToID: {3}", character.Id, response.Request, response.Request.FromId, response.Request.ToId);
            sender.Session.Response.teamInviteRes = response;
            if (response.Result == Result.Success)
            {
                // 接受了组队请求
                var requester = SessionManager.Instance.GetSession(response.Request.FromId);
                if (requester == null)
                {
                    sender.Session.Response.teamInviteRes.Result = Result.Failed;
                    sender.Session.Response.teamInviteRes.Errormsg = "请求者已下线";
                }
                else
                {
                    TeamManager.Instance.AddTeamMember(requester.Session.Character, character);
                    requester.Session.Response.teamInviteRes = response;
                    requester.SendResponse();
                }
            }
            sender.SendResponse();
        }

        void OnTeamLeave(NetConnection<NetSession> sender, TeamLeaveRequest request)
        {
            Character character = sender.Session.Character;
            sender.Session.Response.teamLeave = new TeamLeaveResponse();
            character.Team.Leave(character);
            sender.Session.Response.teamLeave.Result = Result.Success;
            sender.Session.Response.teamLeave.Errormsg = "";
            sender.Session.Response.teamLeave.characterId = character.Id;
            sender.SendResponse();
        }
    }
}
