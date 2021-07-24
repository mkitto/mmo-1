﻿using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/7/24 13:04:05
    /// subscribe：XXX
    /// </summary>
    public class Item
    {
        public int Id;
        public int Count;

        public Item(NItemInfo item)
        {
            this.Id = item.Id;
            this.Count = item.Count;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Count: {1}", this.Id, this.Count);
        }
    }
}
