using Common;
using Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Managers
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/10/27 15:17:33
    /// subscribe：XXX
    /// </summary>
    class SessionManager: Singleton<SessionManager>
    {
        public Dictionary<int, NetConnection<NetSession>> Sessions = new Dictionary<int, NetConnection<NetSession>>();

        public void AddSession(int characterId, NetConnection<NetSession> session)
        {
            this.Sessions[characterId] = session;
        }

        public void RemoveSession(int characterId)
        {
            this.Sessions.Remove(characterId);
        }

        public NetConnection<NetSession> GetSession(int characterId)
        {
            NetConnection<NetSession> session = null;
            this.Sessions.TryGetValue(characterId, out session);
            return session;
        }
    }
}
