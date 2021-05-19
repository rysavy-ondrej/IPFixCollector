using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Buffers.Binary;

namespace IPFixCollector.Modules.Netflow.v9
{
    [Serializable]
	public class Template
	{
		private UInt16 _templateId;
		private UInt16 _fieldsCount;
		private List<Field> _fields;
        private byte[] _bytes;

		public UInt16 TemplateId
		{
			get
			{
                return this._templateId;
			}
		}
		public UInt16 FieldsCount
		{
			get
			{
                return this._fieldsCount;
			}
		}
		public List<Field> Fields
		{
			get
			{
                return this._fields;
			}
		}

        public UInt16 AllFieldsLength
        {
            get
            {
                UInt16 len = 0;
                foreach (Field fields in this._fields)
                {
                    len += fields.Length;
                }
                return len;
            }
        }

        public Template(Span<byte> bytes)
        {
            this._bytes = bytes.ToArray();
            this.Parse();
        }

        private void Parse()
        {
            this._fields = new List<Field>();
            this._templateId = BinaryPrimitives.ReadUInt16BigEndian(_bytes);
            this._fieldsCount = BinaryPrimitives.ReadUInt16BigEndian(new ReadOnlySpan<byte>(_bytes, 2, 2));

            if (this._bytes.Length == ((this._fieldsCount*4)+4))
            {
                for (int i = 0, j=4; i < this._fieldsCount; i++, j+=4 )
                {                    
                    var field = new Field(new Span<byte>(this._bytes, j, 4));
                    this._fields.Add(field);
                }
            }
        }
    }
}
