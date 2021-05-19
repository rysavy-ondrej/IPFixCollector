using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Buffers.Binary;

namespace IPFixCollector.Modules.Netflow.v9
{
    [Serializable]
	public class Field
	{
        private UInt16 _type;
		private UInt16 _length;
		private List<Byte> _value;

        private Byte[] _bytes;

		public String Type
		{
			get
			{
                return Field.FieldTypes(this._type);
			}
		}

        public UInt16 GetFieldType()
        {
            return this._type;
        }

		public UInt16 Length
		{
			get
			{
                return this._length;
			}
		}

		public List<Byte> Value
		{
			get
			{
                return this._value;
			}
			set
			{
                this._value = value;
			}
		}

        public Field(Span<byte> bytes)
        {
            this._bytes = bytes.ToArray();
            this.Parse();
        }

        private void Parse()
        {
            this._value = new List<byte>();
            if (this._bytes.Length == 4)
            {
                this._type = BinaryPrimitives.ReadUInt16BigEndian(this._bytes);
                this._length = BinaryPrimitives.ReadUInt16BigEndian(new ReadOnlySpan<byte>(this._bytes, 2, 2)); 
            }
        }

        public static String FieldTypes(UInt16 fieldType)
        {
            return ((FieldType)fieldType).ToString();
        }
	}
}
