using Common;
using GameServer.Entities;
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
    /// date：2021/10/23 19:32:51
    /// subscribe：XXX
    /// </summary>
    class QuestService: Singleton<QuestService>
    {
        public QuestService()
        {
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<QuestAcceptRequest>(this.OnQuestAccept);
            MessageDistributer<NetConnection<NetSession>>.Instance.Subscribe<QuestSubmitRequest>(this.OnQuestSubmit);
        }

        public void Init()
        {

        }

        void OnQuestAccept(NetConnection<NetSession> sender, QuestAcceptRequest request)
        {
            Character character = sender.Session.Character;
            Log.InfoFormat("OnQuestAccept: :character: {0}, QuestId: {1}", character.Id, request.QuestId);

            sender.Session.Response.questAccept = new QuestAcceptResponse();
            var result = character.QuestManager.AcceptQuest(sender, request.QuestId);
            sender.Session.Response.questAccept.Result = result;
            sender.SendResponse();
        }

        void OnQuestSubmit(NetConnection<NetSession> sender, QuestSubmitRequest request)
        {
            Character character = sender.Session.Character;
            Log.InfoFormat("OnQuestSubmit: :character: {0}, QuestId: {1}", character.Id, request.QuestId);
            
            sender.Session.Response.questSubmit = new QuestSubmitResponse();
            var result = character.QuestManager.SubmitQuest(sender, request.QuestId);
            sender.Session.Response.questSubmit.Result = result;
            sender.SendResponse();
        }
    }
}
