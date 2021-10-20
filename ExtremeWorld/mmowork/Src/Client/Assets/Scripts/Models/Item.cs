using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Data;

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
        public ItemDefine Define;
        public EquipDefine EquipInfo;

        public Item(NItemInfo item):this(item.Id, item.Count)
        {

        }

        public Item(int id, int count)
        {
            this.Id = id;
            this.Count = count;
            DataManager.Instance.Items.TryGetValue(this.Id, out this.Define);
            DataManager.Instance.Equips.TryGetValue(this.Id, out this.EquipInfo);
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Count: {1}", this.Id, this.Count);
        }
    }
}
