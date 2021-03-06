using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;
using SkillBridge.Message;
using UnityEngine;
using UnityEngine.Events;

namespace Models
{
    class User : Singleton<User>
    {
        SkillBridge.Message.NUserInfo userInfo;
        public UnityAction OnGoldChange;

        public SkillBridge.Message.NUserInfo Info
        {
            get { return userInfo; }
        }


        public void SetupUserInfo(SkillBridge.Message.NUserInfo info)
        {
            this.userInfo = info;
        }

        public MapDefine CurrentMapData { get; set; }
        public SkillBridge.Message.NCharacterInfo CurrentCharacter { get; set; }
        public GameObject CurrentCharacterObject { get; set; }

        public NTeamInfo TeamInfo { get; set; }

        public void AddGold(int gold)
        {
            this.CurrentCharacter.Gold += gold;
            if (OnGoldChange != null)
            {
                OnGoldChange();
            }
        }
    }
}
