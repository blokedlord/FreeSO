﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSO.Common.Serialization;
using Mina.Core.Buffer;
using FSO.Server.Protocol.Gluon.Model;

namespace FSO.Server.Protocol.Gluon.Packets
{
    public class TransferClaim : AbstractGluonPacket
    {
        public ClaimType Type;
        public int EntityId;
        public uint ClaimId;
        public string FromOwner;

        public override void Deserialize(IoBuffer input, ISerializationContext context)
        {
            Type = input.GetEnum<ClaimType>();
            EntityId = input.GetInt32();
            ClaimId = input.GetUInt32();
            FromOwner = input.GetPascalString();
        }

        public override GluonPacketType GetPacketType()
        {
            return GluonPacketType.TransferClaim;
        }

        public override void Serialize(IoBuffer output, ISerializationContext context)
        {
            output.PutEnum(Type);
            output.PutInt32(EntityId);
            output.PutUInt32(ClaimId);
            output.PutPascalString(FromOwner);
        }
    }
}
