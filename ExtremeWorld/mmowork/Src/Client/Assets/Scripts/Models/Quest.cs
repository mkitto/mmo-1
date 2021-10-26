using Common.Data;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/21 23:56:45
    /// subscribe：XXX
    /// </summary>
    public class Quest
    {
        public QuestDefine Define;
        public NQuestInfo Info;

        public Quest()
        {

        }

        public Quest(NQuestInfo info)
        {
            this.Info = info;
            this.Define = DataManager.Instance.Quests[info.QuestId];
        }

        public Quest(QuestDefine define)
        {
            this.Define = define;
            this.Info = null;
        }

        //public string GetTypeName()
        //{
        //    return EnumUtil.GetEnumDescription(this.Define.Type);
        //}
    }
}
