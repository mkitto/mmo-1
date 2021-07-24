﻿using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Data
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/7/20 7:25:55
    /// subscribe：XXX
    /// </summary>
    
    public enum ItemFunction
    {
        RecoverHP,
        RecoverMP,
        AddBuff,
        AddExp,
        AddMoney,
        AddItem,
        AddSkillPoint,
    }

    public class ItemDefine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Category { get; set; }
        public bool CanUse { get; set; }
        public int UseCD { get; set;  }
        public int Price { get; set; }
        public int SellPrice { get; set; }
        public ItemFunction Function { get; set; }
        public int Param { get; set; }
        public List<int> Params { get; set; }
    }
}
