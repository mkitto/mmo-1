using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// author：Gochen Ryan
    /// date：2021/8/28 17:53:09
    /// subscribe：XXX
    /// </summary>
    public interface INetSession
    {
        byte[] GetResponse();
    }
}
