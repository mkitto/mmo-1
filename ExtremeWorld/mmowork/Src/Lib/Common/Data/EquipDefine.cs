using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Data
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/19 13:13:22
    /// subscribe：XXX
    /// </summary>
    public class EquipDefine
    {
        public int ID { get; set; }

        public EquipSlot Slot { get; set; }
        public string Category { get; set; }
        public float STR { get; set; }
        public float INT { get; set; }
        public float DEX { get; set; }
        public float HP { get; set; }
        public float MP { get; set; }
        public float AD { get; set; }
        public float AP { get; set; }
        public float DEF { get; set; }
        public float MDEF { get; set; }
        public float SPD { get; set; }
        public float CRI { get; set; }
    }
}
