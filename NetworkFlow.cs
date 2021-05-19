using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace IPFixCollector.DataModel
{
    public class NetworkFlow // : DynamicObject
    {
        [Key, StringLength(50)]
        public string FlowId { get; set; }
        public DateTime Timestamp { get; set; }

        [StringLength(50)]
        public string SourceAddress { get; set; }
        [StringLength(50)]
        public string TargetAddress { get; set; }
        public int SourceTransportPort { get; set; }
        public int DestinationTransportPort { get; set; }
        public int ProtocolIdentifier { get; set; }

        public long FlowStartSysUpTime { get; set; }
        public long FlowEndSysUpTime { get; set; }
        public int PacketDeltaCount { get; set; }
        public int OctetDeltaCount { get; set; }
    }
    /*
        // The inner dictionary.
        Dictionary<string, object> properties
            = new Dictionary<string, object>();

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get
            {
                return properties.Count;
            }
        }

        // If you try to get a value of a property
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return properties.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            properties[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
    }
    */
}
