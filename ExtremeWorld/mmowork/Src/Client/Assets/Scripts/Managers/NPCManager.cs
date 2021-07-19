using Common.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class NPCManager : Singleton<NPCManager>
    {
        public delegate bool NpcActionHandler(NpcDefine npc);

        Dictionary<NpcFunction, NpcActionHandler> eventMap = new Dictionary<NpcFunction, NpcActionHandler>();

        public void RegisterNpcEvent(NpcFunction function, NpcActionHandler action)
        {
            if (!eventMap.ContainsKey(function))
            {
                eventMap[function] = action;
            }
            else {
                eventMap[function] += action;
            }
        }

        public NpcDefine GetNpcDefine(int npcID)
        {
            NpcDefine npc = null;
            DataManager.Instance.NPCs.TryGetValue(npcID, out npc);
            return npc;
        }

        public bool Interactive(int npcId)
        {
            if (DataManager.Instance.NPCs.ContainsKey(npcId))
            {
                if (DataManager.Instance.NPCs.ContainsKey(npcId))
                {
                    var npc = DataManager.Instance.NPCs[npcId];
                    return Interactive(npc);
                }
            }
            return false;
        }

        public bool Interactive(NpcDefine npc)
        {
            if (npc.Type == NpcType.Task)
            {
                return DoTaskInteractive(npc);
            }
            else if (npc.Type == NpcType.Function)
            {
                return DoFunctionInteractive(npc);
            }
            return false;
        }

        private bool DoTaskInteractive(NpcDefine npc)
        {
            MessageBox.Show("点击了NPC: " + npc.Name, "NPC对话");
            return true;
        }

        private bool DoFunctionInteractive(NpcDefine npc)
        {
            if (npc.Type != NpcType.Function)
            {
                return false;
            }

            if (!eventMap.ContainsKey(npc.Function))
            {
                return false;
            }

            return eventMap[npc.Function](npc);
        }
    }
}
