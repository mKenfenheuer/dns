using System;

namespace DNS.Protocol.ResourceRecords {
    public interface IResourceRecord : IMessageEntry, IEquatable<object>
    {
        TimeSpan TimeToLive { get; }
        int DataLength { get; }
        byte[] Data { get; }

    }
}
