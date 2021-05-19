using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPFixCollector.Modules.Netflow
{
    class NetflowCommon
    {
        public NetflowCommon(Span<byte> bytes)
        {
            Version = BinaryPrimitives.ReadUInt16BigEndian(bytes);
        }

        public ushort Version { get; private set; }
    }
}
