using IPFixCollector.DataModel;
using IPFixCollector.Modules.Netflow;
using IPFixCollector.Modules.Netflow.v10;
using IPFixCollector.Modules.Netflow.V5;
using IPFixCollector.Modules.Netflow.v9;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace IPFixCollector.NetflowCollection
{
    public delegate void NetworkFlowDecodedEventHandler(object sender, NetworkFlow networkFlow);
    public delegate void NetworkFlowMessageArrivalEventHandler(object sender, IPEndPoint networkFlowSource, ushort version);

    public class NetflowWorker
    {

        /// <summary>
        /// Fires whenever new Netflow packet arrived.
        /// </summary>
        public event NetworkFlowMessageArrivalEventHandler OnNetworkFlowMessageArrival;
        /// <summary>
        /// Fires on every NetworkFlow decoded. 
        /// </summary>
        public event NetworkFlowDecodedEventHandler OnNetworkFlowDecoded;   

        IPEndPoint _endPoint = new IPEndPoint(IPAddress.Any, 9996);

        /// <summary>
        /// Creates a worker for the given end point parameters.
        /// </summary>
        /// <param name="endPoint">The local IP endpoint to specify interface and port for worker to listen on.</param>
        public NetflowWorker(IPEndPoint endPoint)
        {
            _endPoint = endPoint;
        }

        /// <summary>
        /// Executes the worker and returns the tast that completes when the worker is terminated using the passed
        /// cancellation token.
        /// </summary>
        /// <param name="cancellationToken">
        /// The cancellation token used to terminate the worker.</param>
        public async Task RunAsync(CancellationToken cancellationToken)
        {
            TemplatesV10 _templates_v10 = new TemplatesV10();
            TemplatesV9 _templates_v9 = new TemplatesV9();

            // this is the task that completes when the cancellation request is being made.
            var cancelRequestTask = Task.Delay(-1, cancellationToken);
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(_endPoint);
                
                while (true)
                {
                    EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                    var buffer = new ArraySegment<byte>(new byte[2048]);
                    var recvTask = socket.ReceiveFromAsync(buffer, SocketFlags.None, ep);
                    await Task.WhenAny(recvTask, cancelRequestTask);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        socket.Close();
                        return;
                    }

                    var _bytes = buffer.Slice(0, recvTask.Result.ReceivedBytes);
                    var remoteEndPoint = recvTask.Result.RemoteEndPoint as IPEndPoint;

                    NetflowCommon common = new NetflowCommon(_bytes);
                    OnNetworkFlowMessageArrival?.Invoke(this, remoteEndPoint, common.Version);

                    if (common.Version == 5)
                    {
                        PacketV5 packet = new PacketV5(_bytes);
                        // what to do with V5?
                        // convert to network flow object?
                        // ...
                    }
                    else if ((common.Version == 9))
                    {
                        if (_bytes.Count() > 16)
                        {
                            V9Packet packet = new V9Packet(_bytes, _templates_v9);

                            Modules.Netflow.v9.FlowSet flowset = packet.FlowSet.FirstOrDefault(x => x.Template.Count() != 0);
                            if (flowset != null)
                            {
                                foreach (Modules.Netflow.v9.Template template in flowset.Template.Where(x => x.Field.Any(y => y.Value.Count != 0)))
                                {

                                    NetworkFlow networkFlow = new NetworkFlow();
                                    NetworkFlow netflow = networkFlow;

                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV4_SRC_ADDR))
                                    {
                                        netflow.Source_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV4_SRC_ADDR).Value.ToArray()).ToString();
                                        netflow.Target_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV4_DST_ADDR).Value.ToArray()).ToString();
                                    }
                                    else if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV6_SRC_ADDR))
                                    {
                                        netflow.Source_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV6_SRC_ADDR).Value.ToArray()).ToString();
                                        netflow.Target_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IPV6_DST_ADDR).Value.ToArray()).ToString();
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.L4_SRC_PORT))
                                    {
                                        netflow.Source_port = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.L4_SRC_PORT).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.L4_DST_PORT))
                                    {
                                        netflow.Target_port = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.L4_DST_PORT).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.PROTOCOL))
                                    {
                                        netflow.Protocol = template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.PROTOCOL).Value[0];
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.FIRST_SWITCHED))
                                    {
                                        netflow.Start_timestamp = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.FIRST_SWITCHED).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.LAST_SWITCHED))
                                    {
                                        netflow.Stop_timestamp = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.LAST_SWITCHED).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    netflow.Timestamp = DateTime.UtcNow;
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IN_PKTS))
                                    {
                                        netflow.Packets = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IN_PKTS).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IN_BYTES))
                                    {
                                        netflow.Kbyte = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v9.FieldType.IN_BYTES).Value.ToArray().Reverse().ToArray(), 0);
                                    }
                                    netflow.Id = Guid.NewGuid().ToString().Replace("-", "");


                                    OnNetworkFlowDecoded?.Invoke(this, netflow);
                                }
                            }
                        }
                    }
                    else if (common.Version == 10)
                    {
                        if (_bytes.Count() > 16)
                        {
                            V10Packet packet = new V10Packet(_bytes, _templates_v10);
                            Modules.Netflow.v10.FlowSet flowset = packet.FlowSet.FirstOrDefault(x => x.Template.Count() != 0);
                            if (flowset != null)
                            {
                                foreach (Modules.Netflow.v10.Template template in flowset.Template.Where(x => x.Field.Any(y => y.Type == "sourceTransportPort" && y.Value.Count > 0)))
                                {
                                    NetworkFlow netflow = new NetworkFlow
                                    {
                                        Id = Guid.NewGuid().ToString().Replace("-", ""),
                                        Source_port = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.sourceTransportPort).Value.ToArray().Reverse().ToArray(), 0),
                                        Target_port = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.destinationTransportPort).Value.ToArray().Reverse().ToArray(), 0),
                                        Protocol = template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.protocolIdentifier).Value[0],
                                        Start_timestamp = (long)BitConverter.ToUInt64(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.flowStartMilliseconds).Value.ToArray().Reverse().ToArray(), 0),
                                        Stop_timestamp = (long)BitConverter.ToUInt64(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.flowEndMilliseconds).Value.ToArray().Reverse().ToArray(), 0),
                                        Timestamp = DateTime.UtcNow,
                                        Packets = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.packetDeltaCount).Value.ToArray().Reverse().ToArray(), 0),
                                        Kbyte = BitConverter.ToUInt16(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.octetDeltaCount).Value.ToArray().Reverse().ToArray(), 0)
                                    };
                                    if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.sourceIPv4Address))
                                    {
                                        netflow.Source_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.sourceIPv4Address).Value.ToArray()).ToString();
                                        netflow.Target_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.destinationIPv4Address).Value.ToArray()).ToString();
                                    }
                                    else if (template.Field.Exists(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.sourceIPv6Address))
                                    {
                                        netflow.Source_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.sourceIPv6Address).Value.ToArray()).ToString();
                                        netflow.Target_address = new IPAddress(template.Field.FirstOrDefault(x => x.GetTypes() == (ushort)Modules.Netflow.v10.FieldType.destinationIPv6Address).Value.ToArray()).ToString();
                                    }
                                    OnNetworkFlowDecoded?.Invoke(this, netflow);
                                }
                            }
                            else
                            {
                                Console.WriteLine(String.Format("Template not known for this flow yet: {0}", packet.FlowSet.First().ID));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Fatal Error {0}", ex.Message));
            }
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
