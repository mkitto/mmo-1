using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    interface IPostResponse
    {
        void PostProcess(NetMessageResponse message);
    }
}
