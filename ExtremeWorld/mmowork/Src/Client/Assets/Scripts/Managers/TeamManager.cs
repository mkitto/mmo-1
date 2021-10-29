using Models;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/29 15:32:10
    /// subscribe：XXX
    /// </summary>
    class TeamManager: Singleton<TeamManager>
    {
        public void Init()
        {

        }

        public void UpdateTeamInfo(NTeamInfo team)
        {
            User.Instance.TeamInfo = team;
            ShowTeamUI(team != null);
        }

        public void ShowTeamUI(bool show)
        {
            if (UIMain.Instance != null)
            {
                UIMain.Instance.ShowTeamUI(show);
            }
        }
    }
}
