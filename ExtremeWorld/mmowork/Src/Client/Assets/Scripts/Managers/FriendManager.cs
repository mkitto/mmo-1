using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Managers
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/28 0:20:59
    /// subscribe：XXX
    /// </summary>
    class FriendManager: Singleton<FriendManager>
    {
        public List<NFriendInfo> allFriends;

        public void Init(List<NFriendInfo> friends)
        {
            this.allFriends = friends;
        }
    }
}
