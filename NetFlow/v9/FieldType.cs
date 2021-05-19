using System;
using System.Collections.Generic;
using System.Text;

namespace IPFixCollector.Modules.Netflow.v9
{
	/// <summary>
	/// The list of IPFIX fields according to IANA:
	/// https://www.iana.org/assignments/ipfix/ipfix.xhtml
	/// </summary>
	public enum FieldType : ushort
	{
		Reserved = 0,
		octetDeltaCount = 1,
		packetDeltaCount = 2,
		deltaFlowCount = 3,
		protocolIdentifier = 4,
		ipClassOfService = 5,
		tcpControlBits = 6,

		sourceTransportPort = 7,

		sourceIPv4Address = 8,
		sourceIPv4PrefixLength = 9,
		ingressInterface = 10,
		destinationTransportPort = 11,

		destinationIPv4Address = 12,
		destinationIPv4PrefixLength = 13,
		egressInterface = 14,
		ipNextHopIPv4Address = 15,
		bgpSourceAsNumber = 16,
		bgpDestinationAsNumber = 17,
		bgpNextHopIPv4Address = 18,
		postMCastPacketDeltaCount = 19,
		postMCastOctetDeltaCount = 20,
		flowEndSysUpTime = 21,
		flowStartSysUpTime = 22,
		postOctetDeltaCount = 23,
		postPacketDeltaCount = 24,
		minimumIpTotalLength = 25,
		maximumIpTotalLength = 26,
		sourceIPv6Address = 27,
		destinationIPv6Address = 28,
		sourceIPv6PrefixLength = 29,
		destinationIPv6PrefixLength = 30,
		flowLabelIPv6 = 31,
		icmpTypeCodeIPv4 = 32,
		igmpType = 33,
		samplingInterval = 34,
		samplingAlgorithm = 35,

		flowActiveTimeout = 36,
		flowIdleTimeout = 37,
		engineType = 38,

		engineId = 39,
		exportedOctetTotalCount = 40,
		exportedMessageTotalCount = 41,
		exportedFlowRecordTotalCount = 42,
		ipv4RouterSc = 43,
		sourceIPv4Prefix = 44,
		destinationIPv4Prefix = 45,
		mplsTopLabelType = 46,
		mplsTopLabelIPv4Address = 47,
		samplerId = 48,
		samplerMode = 49,
		samplerRandomInterval = 50,
		classId = 51,
		minimumTTL = 52,
		maximumTTL = 53,
		fragmentIdentification = 54,
		postIpClassOfService = 55,
		sourceMacAddress = 56,
		postDestinationMacAddress = 57,
		vlanId = 58,
		postVlanId = 59,
		ipVersion = 60,
		flowDirection = 61,

		ipNextHopIPv6Address = 62,
		bgpNextHopIPv6Address = 63,
		ipv6ExtensionHeaders = 64,

		mplsTopLabelStackSection = 70,

		mplsLabelStackSection2 = 71,


		mplsLabelStackSection3 = 72,


		mplsLabelStackSection4 = 73,


		mplsLabelStackSection5 = 74,


		mplsLabelStackSection6 = 75,


		mplsLabelStackSection7 = 76,


		mplsLabelStackSection8 = 77,


		mplsLabelStackSection9 = 78,


		mplsLabelStackSection10 = 79,


		destinationMacAddress = 80,
		postSourceMacAddress = 81,
		interfaceName = 82,
		interfaceDescription = 83,
		samplerName = 84,
		octetTotalCount = 85,
		packetTotalCount = 86,
		flagsAndSamplerId = 87,
		fragmentOffset = 88,
		forwardingStatus = 89,






















		mplsVpnRouteDistinguisher = 90,
		mplsTopLabelPrefixLength = 91,
		srcTrafficIndex = 92,
		dstTrafficIndex = 93,
		applicationDescription = 94,
		applicationId = 95,
		applicationName = 96,
		postIpDiffServCodePoint = 98,
		multicastReplicationFactor = 99,
		className = 100,
		classificationEngineId = 101,


		layer2packetSectionOffset = 102,
		layer2packetSectionSize = 103,
		layer2packetSectionData = 104,
		bgpNextAdjacentAsNumber = 128,
		bgpPrevAdjacentAsNumber = 129,
		exporterIPv4Address = 130,
		exporterIPv6Address = 131,
		droppedOctetDeltaCount = 132,
		droppedPacketDeltaCount = 133,
		droppedOctetTotalCount = 134,
		droppedPacketTotalCount = 135,
		flowEndReason = 136,
		commonPropertiesId = 137,
		observationPointId = 138,
		icmpTypeCodeIPv6 = 139,
		mplsTopLabelIPv6Address = 140,
		lineCardId = 141,
		portId = 142,
		meteringProcessId = 143,
		exportingProcessId = 144,
		templateId = 145,




		wlanChannelId = 146,
		wlanSSID = 147,
		flowId = 148,
		observationDomainId = 149,




		flowStartSeconds = 150,
		flowEndSeconds = 151,
		flowStartMilliseconds = 152,
		flowEndMilliseconds = 153,
		flowStartMicroseconds = 154,
		flowEndMicroseconds = 155,
		flowStartNanoseconds = 156,
		flowEndNanoseconds = 157,
		flowStartDeltaMicroseconds = 158,
		flowEndDeltaMicroseconds = 159,
		systemInitTimeMilliseconds = 160,
		flowDurationMilliseconds = 161,
		flowDurationMicroseconds = 162,
		observedFlowTotalCount = 163,
		ignoredPacketTotalCount = 164,
		ignoredOctetTotalCount = 165,
		notSentFlowTotalCount = 166,
		notSentPacketTotalCount = 167,
		notSentOctetTotalCount = 168,
		destinationIPv6Prefix = 169,
		sourceIPv6Prefix = 170,
		postOctetTotalCount = 171,
		postPacketTotalCount = 172,
		flowKeyIndicator = 173,


		postMCastPacketTotalCount = 174,
		postMCastOctetTotalCount = 175,
		icmpTypeIPv4 = 176,
		icmpCodeIPv4 = 177,
		icmpTypeIPv6 = 178,
		icmpCodeIPv6 = 179,
		udpSourcePort = 180,
		udpDestinationPort = 181,
		tcpSourcePort = 182,
		tcpDestinationPort = 183,
		tcpSequenceNumber = 184,
		tcpAcknowledgementNumber = 185,
		tcpWindowSize = 186,
		tcpUrgentPointer = 187,
		tcpHeaderLength = 188,
		ipHeaderLength = 189,
		totalLengthIPv4 = 190,
		payloadLengthIPv6 = 191,
		ipTTL = 192,
		nextHeaderIPv6 = 193,
		mplsPayloadLength = 194,
		ipDiffServCodePoint = 195,


		ipPrecedence = 196,


		fragmentFlags = 197,

























		octetDeltaSumOfSquares = 198,
		octetTotalSumOfSquares = 199,
		mplsTopLabelTTL = 200,
		mplsLabelStackLength = 201,
		mplsLabelStackDepth = 202,
		mplsTopLabelExp = 203,









		ipPayloadLength = 204,




		udpMessageLength = 205,
		isMulticast = 206,

















		ipv4IHL = 207,
		ipv4Options = 208,





























































		tcpOptions = 209,

























		paddingOctets = 210,
		collectorIPv4Address = 211,
		collectorIPv6Address = 212,
		exportInterface = 213,
		exportProtocolVersion = 214,


		exportTransportProtocol = 215,


		collectorTransportPort = 216,


		exporterTransportPort = 217,


		tcpSynTotalCount = 218,
		tcpFinTotalCount = 219,
		tcpRstTotalCount = 220,
		tcpPshTotalCount = 221,
		tcpAckTotalCount = 222,
		tcpUrgTotalCount = 223,
		ipTotalLength = 224,
		postNATSourceIPv4Address = 225,
		postNATDestinationIPv4Address = 226,
		postNAPTSourceTransportPort = 227,
		postNAPTDestinationTransportPort = 228,
		natOriginatingAddressRealm = 229,


		natEvent = 230,
		initiatorOctets = 231,
		responderOctets = 232,
		firewallEvent = 233,
		ingressVRFID = 234,
		egressVRFID = 235,
		VRFname = 236,
		postMplsTopLabelExp = 237,
		tcpWindowScale = 238,
		biflowDirection = 239,
		ethernetHeaderLength = 240,
		ethernetPayloadLength = 241,
		ethernetTotalLength = 242,
		dot1qVlanId = 243,


		dot1qPriority = 244,
		dot1qCustomerVlanId = 245,
		dot1qCustomerPriority = 246,
		metroEvcId = 247,
		metroEvcType = 248,
		pseudoWireId = 249,
		pseudoWireType = 250,
		pseudoWireControlWord = 251,
		ingressPhysicalInterface = 252,
		egressPhysicalInterface = 253,
		postDot1qVlanId = 254,
		postDot1qCustomerVlanId = 255,
		ethernetType = 256,
		postIpPrecedence = 257,
		collectionTimeMilliseconds = 258,
		exportSctpStreamId = 259,
		maxExportSeconds = 260,
		maxFlowEndSeconds = 261,
		messageMD5Checksum = 262,
		messageScope = 263,
		minExportSeconds = 264,
		minFlowStartSeconds = 265,
		opaqueOctets = 266,
		sessionScope = 267,
		maxFlowEndMicroseconds = 268,
		maxFlowEndMilliseconds = 269,
		maxFlowEndNanoseconds = 270,
		minFlowStartMicroseconds = 271,
		minFlowStartMilliseconds = 272,
		minFlowStartNanoseconds = 273,
		collectorCertificate = 274,
		exporterCertificate = 275,
		dataRecordsReliability = 276,
		observationPointType = 277,
		newConnectionDeltaCount = 278,
		connectionSumDurationSeconds = 279,
		connectionTransactionId = 280,
		postNATSourceIPv6Address = 281,
		postNATDestinationIPv6Address = 282,
		natPoolId = 283,
		natPoolName = 284,
		anonymizationFlags = 285,

















































































		anonymizationTechnique = 286,
		informationElementIndex = 287,
		p2pTechnology = 288,


		tunnelTechnology = 289,


		encryptedTechnology = 290,


		basicList = 291,
		subTemplateList = 292,
		subTemplateMultiList = 293,
		bgpValidityState = 294,
		IPSecSPI = 295,
		greKey = 296,
		natType = 297,
		initiatorPackets = 298,
		responderPackets = 299,
		observationDomainName = 300,
		selectionSequenceId = 301,
		selectorId = 302,
		informationElementId = 303,
		selectorAlgorithm = 304,












		samplingPacketInterval = 305,


		samplingPacketSpace = 306,


		samplingTimeInterval = 307,


		samplingTimeSpace = 308,


		samplingSize = 309,


		samplingPopulation = 310,


		samplingProbability = 311,


		dataLinkFrameSize = 312,


		ipHeaderPacketSection = 313,










		ipPayloadPacketSection = 314,












		dataLinkFrameSection = 315,












		mplsLabelStackSection = 316,














		mplsPayloadPacketSection = 317,












		selectorIdTotalPktsObserved = 318,


		selectorIdTotalPktsSelected = 319,


		absoluteError = 320,




		relativeError = 321,




		observationTimeSeconds = 322,
		observationTimeMilliseconds = 323,
		observationTimeMicroseconds = 324,
		observationTimeNanoseconds = 325,
		digestHashValue = 326,
		hashIPPayloadOffset = 327,
		hashIPPayloadSize = 328,
		hashOutputRangeMin = 329,


		hashOutputRangeMax = 330,


		hashSelectedRangeMin = 331,


		hashSelectedRangeMax = 332,


		hashDigestOutput = 333,


		hashInitialiserValue = 334,


		selectorName = 335,
		upperCILimit = 336,




		lowerCILimit = 337,




		confidenceLevel = 338,




		informationElementDataType = 339,


		informationElementDescription = 340,
		informationElementName = 341,
		informationElementRangeBegin = 342,
		informationElementRangeEnd = 343,
		informationElementSemantics = 344,


		informationElementUnits = 345,


		privateEnterpriseNumber = 346,
		virtualStationInterfaceId = 347,
		virtualStationInterfaceName = 348,
		virtualStationUUID = 349,
		virtualStationName = 350,
		layer2SegmentId = 351,














		layer2OctetDeltaCount = 352,
		layer2OctetTotalCount = 353,
		ingressUnicastPacketTotalCount = 354,
		ingressMulticastPacketTotalCount = 355,
		ingressBroadcastPacketTotalCount = 356,
		egressUnicastPacketTotalCount = 357,
		egressBroadcastPacketTotalCount = 358,
		monitoringIntervalStartMilliSeconds = 359,
		monitoringIntervalEndMilliSeconds = 360,
		portRangeStart = 361,


		portRangeEnd = 362,


		portRangeStepSize = 363,
		portRangeNumPorts = 364,
		staMacAddress = 365,
		staIPv4Address = 366,
		wtpMacAddress = 367,
		ingressInterfaceType = 368,
		egressInterfaceType = 369,
		rtpSequenceNumber = 370,
		userName = 371,
		applicationCategoryName = 372,
		applicationSubCategoryName = 373,
		applicationGroupName = 374,
		originalFlowsPresent = 375,
		originalFlowsInitiated = 376,
		originalFlowsCompleted = 377,
		distinctCountOfSourceIPAddress = 378,
		distinctCountOfDestinationIPAddress = 379,
		distinctCountOfSourceIPv4Address = 380,
		distinctCountOfDestinationIPv4Address = 381,
		distinctCountOfSourceIPv6Address = 382,
		distinctCountOfDestinationIPv6Address = 383,
		valueDistributionMethod = 384,
		rfc3550JitterMilliseconds = 385,
		rfc3550JitterMicroseconds = 386,
		rfc3550JitterNanoseconds = 387,
		dot1qDEI = 388,
		dot1qCustomerDEI = 389,
		flowSelectorAlgorithm = 390,
		flowSelectedOctetDeltaCount = 391,
		flowSelectedPacketDeltaCount = 392,
		flowSelectedFlowDeltaCount = 393,
		selectorIDTotalFlowsObserved = 394,
		selectorIDTotalFlowsSelected = 395,
		samplingFlowInterval = 396,
		samplingFlowSpacing = 397,
		flowSamplingTimeInterval = 398,
		flowSamplingTimeSpacing = 399,
		hashFlowDomain = 400,
		transportOctetDeltaCount = 401,
		transportPacketDeltaCount = 402,
		originalExporterIPv4Address = 403,
		originalExporterIPv6Address = 404,
		originalObservationDomainId = 405,
		intermediateProcessId = 406,
		ignoredDataRecordTotalCount = 407,
		dataLinkFrameType = 408,






		sectionOffset = 409,


		sectionExportedOctets = 410,


		dot1qServiceInstanceTag = 411,
		dot1qServiceInstanceId = 412,
		dot1qServiceInstancePriority = 413,
		dot1qCustomerSourceMacAddress = 414,
		dot1qCustomerDestinationMacAddress = 415,

		postLayer2OctetDeltaCount = 417,


		postMCastLayer2OctetDeltaCount = 418,


		postLayer2OctetTotalCount = 420,


		postMCastLayer2OctetTotalCount = 421,


		minimumLayer2TotalLength = 422,


		maximumLayer2TotalLength = 423,


		droppedLayer2OctetDeltaCount = 424,


		droppedLayer2OctetTotalCount = 425,


		ignoredLayer2OctetTotalCount = 426,


		notSentLayer2OctetTotalCount = 427,


		layer2OctetDeltaSumOfSquares = 428,


		layer2OctetTotalSumOfSquares = 429,


		layer2FrameDeltaCount = 430,
		layer2FrameTotalCount = 431,
		pseudoWireDestinationIPv4Address = 432,
		ignoredLayer2FrameTotalCount = 433,
		mibObjectValueInteger = 434,
		mibObjectValueOctetString = 435,
		mibObjectValueOID = 436,
		mibObjectValueBits = 437,
		mibObjectValueIPAddress = 438,
		mibObjectValueCounter = 439,
		mibObjectValueGauge = 440,
		mibObjectValueTimeTicks = 441,
		mibObjectValueUnsigned = 442,
		mibObjectValueTable = 443,
		mibObjectValueRow = 444,
		mibObjectIdentifier = 445,
		mibSubIdentifier = 446,
		mibIndexIndicator = 447,


		mibCaptureTimeSemantics = 448,




		mibContextEngineID = 449,
		mibContextName = 450,
		mibObjectName = 451,
		mibObjectDescription = 452,
		mibObjectSyntax = 453,
		mibModuleName = 454,
		mobileIMSI = 455,
		mobileMSISDN = 456,
		httpStatusCode = 457,
		sourceTransportPortsLimit = 458,
		httpRequestMethod = 459,
		httpRequestHost = 460,
		httpRequestTarget = 461,
		httpMessageVersion = 462,
		natInstanceID = 463,
		internalAddressRealm = 464,
		externalAddressRealm = 465,
		natQuotaExceededEvent = 466,
		natThresholdEvent = 467,
		httpUserAgent = 468,
		httpContentType = 469,
		httpReasonPhrase = 470,
		maxSessionEntries = 471,
		maxBIBEntries = 472,
		maxEntriesPerUser = 473,
		maxSubscribers = 474,
		maxFragmentsPendingReassembly = 475,
		addressPoolHighThreshold = 476,
		addressPoolLowThreshold = 477,
		addressPortMappingHighThreshold = 478,
		addressPortMappingLowThreshold = 479,
		addressPortMappingPerUserHighThreshold = 480,
		globalAddressMappingHighThreshold = 481,
		vpnIdentifier = 482,
		bgpCommunity = 483,
		bgpSourceCommunityList = 484,
		bgpDestinationCommunityList = 485,
		bgpExtendedCommunity = 486,
		bgpSourceExtendedCommunityList = 487,
		bgpDestinationExtendedCommunityList = 488,
		bgpLargeCommunity = 489,
		bgpSourceLargeCommunityList = 490,
		bgpDestinationLargeCommunityList = 491,
	};


}
