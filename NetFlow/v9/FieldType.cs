using System;
using System.Collections.Generic;
using System.Text;

namespace IPFixCollector.Modules.Netflow.v9
{
    public enum FieldType : ushort
	{
		IN_BYTES = 1,
		IN_PKTS,
		FLOWS,
		PROTOCOL,
		TOS,
		TCP_FLAGS,
		L4_SRC_PORT,
		IPV4_SRC_ADDR,
		SRC_MASK,
		INPUT_SNMP,
		L4_DST_PORT,
		IPV4_DST_ADDR,
		DST_MASK,
		OUTPUT_SNMP,
		IPV4_NEXT_HOP,
		SRC_AS,
		DST_AS,
		BGP_IPV4_NEXT_HOP,
		MUL_DST_PKTS,
		MUL_DST_BYTES,
		LAST_SWITCHED,
		FIRST_SWITCHED,
		OUT_BYTES,
		OUT_PKTS,
		IPV6_SRC_ADDR = 27,
		IPV6_DST_ADDR,
		IPV6_SRC_MASK,
		IPV6_DST_MASK,
		IPV6_FLOW_LABEL,
		ICMP_TYPE,
		MUL_IGMP_TYPE,
		SAMPLING_INTERVAL,
		SAMPLING_ALGORITHM,
		FLOW_ACTIVE_TIMEOUT,
		FLOW_INACTIVE_TIMEOUT,
		ENGINE_TYPE,
		ENGINE_ID,
		TOTAL_BYTES_EXP,
		TOTAL_PKTS_EXP,
		TOTAL_FLOWS_EXP,
		MPLS_TOP_LABEL_TYPE = 46,
		MPLS_TOP_LABEL_IP_ADDR,
		FLOW_SAMPLER_ID,
		FLOW_SAMPLER_MODE,
		FLOW_SAMPLER_RANDOM_INTERVAL,
		DST_TOS = 55,
		SRC_MAC,
		DST_MAC,
		SRC_VLAN,
		DST_VLAN,
		IP_PROTOCOL_VERSION,
		DIRECTION,
		IPV6_NEXT_HOP,
		BGP_IPV6_NEXT_HOP,
		IPV6_OPTION_HEADERS,
		MPLS_LABEL_1 = 70,
		MPLS_LABEL_2,
		MPLS_LABEL_3,
		MPLS_LABEL_4,
		MPLS_LABEL_5,
		MPLS_LABEL_6,
		MPLS_LABEL_7,
		MPLS_LABEL_8,
		MPLS_LABEL_9,
		MPLS_LABEL_10
	}
}
