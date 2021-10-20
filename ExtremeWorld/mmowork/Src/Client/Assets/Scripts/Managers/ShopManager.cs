using Common.Data;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/8/28 16:22:22
    /// subscribe：XXX
    /// </summary>
    class ShopManager : Singleton<ShopManager>
    {
        public void Init()
        {
            NPCManager.Instance.RegisterNpcEvent(NpcFunction.InvokeShop, OnOpenShop);
        }

        private bool OnOpenShop(NpcDefine npc)
        {
            this.ShowShop(npc.Param);
            return true;
        }

        public bool BuyItem(int shopId, int shopItemId)
        {
            ItemService.Instance.SendBuyItem(shopId, shopItemId);
            return true;
        }

        public void ShowShop(int shopId)
        {
            ShopDefine shop;
            if (DataManager.Instance.Shops.TryGetValue(shopId, out shop)) ;
            {
                UIShop uiShop = UIManager.Instance.Show<UIShop>();
                if (uiShop != null)
                {
                    uiShop.SetShop(shop);
                }
            }
        }
    }
}
