using System;
using System.Collections.Generic;
using DNS.Protocol.Utils;

namespace DNS.Protocol.ResourceRecords {
    public abstract class BaseResourceRecord : IResourceRecord {
        private IResourceRecord record;

        public BaseResourceRecord(IResourceRecord record) {
            this.record = record;
        }

        public Domain Name {
            get { return record.Name; }
        }

        public RecordType Type {
            get { return record.Type; }
        }

        public RecordClass Class {
            get { return record.Class; }
        }

        public TimeSpan TimeToLive {
            get { return record.TimeToLive; }
        }

        public int DataLength {
            get { return record.DataLength; }
        }

        public byte[] Data {
            get { return record.Data; }
        }

        public int Size {
            get { return record.Size; }
        }

        public override bool Equals(object obj)
        {
            var record = obj as BaseResourceRecord;
            return record != null &&
                   EqualityComparer<Domain>.Default.Equals(Name, record.Name) &&
                   Type == record.Type &&
                   Class == record.Class &&
                   TimeToLive.Equals(record.TimeToLive) &&
                   DataLength == record.DataLength &&
                   EqualityComparer<byte[]>.Default.Equals(Data, record.Data) &&
                   Size == record.Size;
        }

        public byte[] ToArray() {
            return record.ToArray();
        }

        internal ObjectStringifier Stringify() {
            return ObjectStringifier.New(this)
                .Add("Name", "Type", "Class", "TimeToLive", "DataLength");
        }


    }
}
