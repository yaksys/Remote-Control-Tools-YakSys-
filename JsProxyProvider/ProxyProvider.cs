using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using JurikSoft.Proxy.Exceptions;

	
namespace JurikSoft
{	
	namespace Proxy
	{	
		
		#region Exceptions 

		namespace Exceptions
		{
			/// <summary> 
			/// Base JurikSoft Proxy Provider exception.
			/// </summary>
			public class ProxyProviderException : System.Exception
			{				
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Base JurikSoft Proxy Provider exception.";
					}
				}
			}
			
			/// <summary> 
			/// It is not socks version 5 server.
			/// </summary>
			public class Socks5ServiceNotFoundException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "This is not socks version 5 server.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Proxy Server did not response at the time out period.
			/// </summary>
			public class TimeOutException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Proxy Server did not response at the time out period.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Selected Proxy Server requred user authentication.
			/// </summary>
			public class AuthenticationRequiredException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Proxy Server requred user authentication.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// No acceptable connection methods available from methods listed by client.
			/// </summary>
			public class NoAcceptableMethodsException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "None of the connection methods listed by the client are acceptable.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Reply from Socks server version 5: General SOCKS server failure.
			/// </summary>
			public class GeneralSocksServerFailureException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: General SOCKS server failure.\nConnection will be closed.";
					}
				}
			}
			
			/// <summary> 
			/// Reply from Socks server version 5: Connection not allowed by rule set.
			/// </summary>
			public class ConnectionNotAllowedException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Connection not allowed by rule set.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Reply from Socks server version 5: Destination network is unreachable.
			/// </summary>
			public class NetworkUnreachableException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Network unreachable.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Socks server version 5 reply: Destination host is unreachable.
			/// </summary>
			public class HostUnreachableException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Host unreachable.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Socks server version 5 reply: Connection refused.
			/// </summary>
			public class ConnectionRefusedException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Connection refused.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Socks server version 5 reply: Time To Live was expired.
			/// </summary>
			public class TTLExpiredException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: TTL expired.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Socks server version 5 reply: Command not supported.
			/// </summary>
			public class UnsupportedSocksCommandException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Command not supported.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Socks server version 5 reply: Address type not supported.
			/// </summary>
			public class UnsupportedAddressTypeException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Socks server version 5 reply: Address type not supported.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Unable to connect to Proxy Server.
			/// </summary>
			public class ProxyConnectionException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Unable connect to Proxy Server.";
					}
				}
			}

			/// <summary> 
			/// This is not socks version 4 server.
			/// </summary>
			public class Socks4ServiceNotFoundException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "This is not socks version 4 server.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 
			/// Connection to socks server version 4 was rejected or failed.
			/// </summary>
			public class RequestRejectedOrFailed : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Connection to socks server version 4 was rejected or failed.";
					}
				}
			}

			/// <summary> 
			/// Request rejected becasue Socks server cannot connect to identd on the client.
			/// </summary>
			public class IdentdOnClientNotResponse : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Request rejected becasue SOCKS server cannot connect\nto identd on the client.\nConnection will be closed.";
					}
				}
			}
					
			/// <summary> 
			/// Request rejected because the client program and identd report different user-ids.
			/// </summary>
			public class DifferentUserIDs : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Request rejected because the client program and identd\nreport different user-ids.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 			
			/// Local computer unable to resolve destination HostName to IP Address.
			/// </summary>
			public class UnableToResolveHostName : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Local computer unable to resolve destination HostName to IP Address.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 			
			/// Authentication is not allowed by this server.
			/// </summary>
			public class AuthenticationNotAllowedException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Authentication is not allowed by this server.\nConnection will be closed.";
					}
				}
			}

			/// <summary> 			
			/// Authentication failure.
			/// </summary>
			public class AuthenticationFailureException : ProxyProviderException
			{
				/// <summary> 
				/// Gets a message that describes the current exception.
				/// </summary>
				public override string Message
				{
					get
					{
						return "Proxy Authentication failure.\nConnection will be closed.";
					}
				}
			}				
		}
		
	
		#endregion


		/// <summary>
		/// Represents the class that contains implementation of the TCP Tunneling technique for connection through Socks 4, 4a, 5, and HTTPS Proxy Servers.
		/// </summary>
		public class ProxyProvider
		{	
			#region Events
			
			/// <summary>
			/// 
			/// Represents the method that will handle the Proxy events.
			/// 
			/// </summary>		
			public delegate void BaseProxyEventHandler();
		
			
			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a connection request to Socks Server version 5.
			/// 
			/// </summary>		
			public event BaseProxyEventHandler
			SendingSocks5ConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a Authentication request to Socks Server version 5.
			/// 
			/// </summary>			
			public event BaseProxyEventHandler			
			SendingSocks5AuthenticationRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a request details to Socks Server version 5.
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			SendingSocks5RequestDetails;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a connection request to Socks Server version 4.
			/// 
			/// </summary>		
			public event BaseProxyEventHandler	
			SendingSocks4ConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a connection request to HTTPS Proxy Server.
			/// 
			/// </summary>		
			public event BaseProxyEventHandler	
			SendingHTTPSConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider send a Authentication request to HTTPS Proxy Server.
			/// 
			/// </summary>		
			public event BaseProxyEventHandler	
			SendingHTTPSAuthenticationRequest;
			
			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply to connection request from Socks Server verion 5.
			/// 
			/// </summary>								
			public event BaseProxyEventHandler	
			WaitingForReplyToSocks5ConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply to Authentication request from Socks Server verion 5.
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			WaitingForReplyToSocks5AuthenticationRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply from Socks Server verion 5 to sent request details .
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			WaitingForReplyToSocks5RequestDetails;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply from Socks Server verion 5 to sent connection request.
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			WaitingForReplyToSocks4ConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply from HTTPS Proxy Server to sent connection request.
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			WaitingForReplyToHTTPSConnectionRequest;

			/// <summary>
			/// 
			/// Occurs when the JurikSoft Proxy Provider wait reply from HTTPS Proxy Server to sent Authentication request.
			/// 
			/// </summary>	
			public event BaseProxyEventHandler	
			WaitingForReplyToHTTPSAuthenticationRequest;




			#endregion

			#region Only for Socks5 Server
			
			internal byte [] byteArray_Socks5ConnetionRequest = new byte[3], 
				byteArray_Socks5ConnectionResponse = new byte[2],
				byteArray_Socks5ReplyToRequestDetails = new byte[10];
	
			internal MemoryStream memoryStream_Socks5RequestDetails = new MemoryStream(),
				memoryStream_Socks5AuthenticationDetails = new MemoryStream();
			
			#endregion

			#region Only for Socks4 Server
			
			internal byte [] byteArray_Socks4ConnectionResponse = new byte[8];
				
			internal MemoryStream memoryStream_Socks4ConnetionRequest = new MemoryStream();
	
			#endregion

			#region Common Properties

			internal static string string_SerialNumber, string_RegistrationName;


			///  <summary>
			/// 
			///  Serial Number of your product copy sent to your Registration Name 
			/// 
			///  </summary>
			/// 		
			///  <remarks>
			/// 
			///  If you are not registered you will see the following message every time when you  
			///  Connect to necessary Host through Proxy Server using JurikSoft Proxy Provider: 
			///  
			///  <para>			
			///  "You are using the FREE COPY of JurikSoft Proxy Provider.			
			///  Please register a copy of JurikSoft Proxy Provider at 
			///  http://www.juriksoft.net to disable this appear message."
			///  </para>
			/// 
			///  You can purchase a copy of this software product at http://www.juriksoft.net.
			///   
			///  <para>	
			///  One copy (serial number) entitles to use this 
			///  software product to one software developers team.
			///  </para>
			///  </remarks>
			///  
			///  <example> This sample shows how to use Registration Information.
			///  <code>
			/// 
			///  JurikSoft.Proxy.ProxyProvider.SerialNumber = "1000000000";
			///  JurikSoft.Proxy.ProxyProvider.RegistrationName = "Test";
			/// 
			///  </code>
			///  </example>
			public static string SerialNumber
			{
				set
				{
					string_SerialNumber = value;
				}

				get
				{
					return string_SerialNumber;
				}
			}

		
			///  <summary>
			/// 
			///  Registration Name that you use when you buy JurikSoft Proxy Provider 
			/// 
			///  </summary>
			/// 		
			///  <remarks>
			/// 
			///  If you are not registered you will see the following message every time when you  
			///  Connect to necessary Host through Proxy Server using JurikSoft Proxy Provider: 
			///  
			///  <para>			
			///  "You are using the FREE COPY of JurikSoft Proxy Provider.			
			///  Please register a copy of JurikSoft Proxy Provider at 
			///  http://www.juriksoft.net to disable this appear message."
			///  </para>
			/// 
			///  You can purchase a copy of this software product at http://www.juriksoft.net.
			///   
			///  <para>	
			///  One copy (serial number) entitles to use this 
			///  software product to one software developers team.
			///  </para>
			///  </remarks>
			///  
			///  <example> This sample shows how to use Registration Information.
			///  <code>
			///  
			///  JurikSoft.Proxy.ProxyProvider.SerialNumber = "1000000000";
			///  JurikSoft.Proxy.ProxyProvider.RegistrationName = "Test";
			/// 
			///  </code>
			///  </example>		
			public static string RegistrationName
			{
			
				set
				{
					string_RegistrationName = value;
				}

				get
				{
					return string_RegistrationName;
				}
			}
		
		
			#endregion

			#region Internal Members
		
			internal static void CheckSN()
			{
				if(SerialNumber == null || SerialNumber.Length < 9) 
				{
					MessageBox.Show("You are using the FREE COPY of JurikSoft Proxy Provider.\nPlease register a copy of JurikSoft Proxy Provider at\nhttp://www.juriksoft.net to disable this appear message.", "JurikSoft");
					return;
				}

				SHA512Managed SHA512ManagedObject_Key = new SHA512Managed();
		
				byte [] byteArray_KeyHash = SHA512ManagedObject_Key.ComputeHash(Encoding.Unicode.GetBytes(RegistrationName));

				string string_CurrentNubmer = null;

				for(int int_CycleCount = 0; byteArray_KeyHash.Length != int_CycleCount; int_CycleCount++)
				{					
					string_CurrentNubmer += (byteArray_KeyHash[int_CycleCount]*4).ToString();				
				}

				if(SerialNumber == string_CurrentNubmer.Substring(0, 10)) return;
				else MessageBox.Show("You are using the FREE COPY of JurikSoft Proxy Provider.\nPlease register a copy of JurikSoft Proxy Provider at\nhttp://www.juriksoft.net to disable this appear message.", "JurikSoft");
			}

			
			internal TcpClient tcpClient_LinkToCloseByTimeOut = null;
			internal Socket socket_LinkToCloseByTimeOut = null;
		
			internal int int_GlobalTimeOutMS = 0;

			internal void ConnectionTimeOutWatcher()
			{
				if(int_GlobalTimeOutMS <= 0 || (tcpClient_LinkToCloseByTimeOut == null && socket_LinkToCloseByTimeOut == null)) return;

				int int_InternalTimeOutCount = 0;
				while(int_InternalTimeOutCount <= int_GlobalTimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(tcpClient_LinkToCloseByTimeOut != null) tcpClient_LinkToCloseByTimeOut.Close();
				if(socket_LinkToCloseByTimeOut != null) socket_LinkToCloseByTimeOut.Close();
			}

			#endregion

	
			/// <summary> 
			/// Connect input Socket object to selected Server through Socks Proxy Server version 4. 
			/// </summary>
			/// 
			/// <overloads>
			/// Connect to selected Server through Socks Proxy Server version 4. 
			/// </overloads>
			/// 
			/// <param name="socket_Link">  
			/// Reference to Socket object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// Socket socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks4Proxy(ref socket_Client, “10.0.0.1”, 80,  “10.0.0.5”, 1080, false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks4Proxy(ref Socket socket_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort ) 
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort )
				{				
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}

				IPAddress ipAddress_DstHost;
				IPEndPoint ipEndPoint_ProxyAddress;
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_ProxyHost);
					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_DstHost, int_ProxyPort);
				}

				catch(FormatException exception)
				{	
					try
					{				
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}
	
				if(socket_Link == null) socket_Link = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{					
					socket_LinkToCloseByTimeOut = socket_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					socket_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					socket_Link.Close();

					throw new ProxyConnectionException();
				}

				memoryStream_Socks4ConnetionRequest.SetLength(0);
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)4);				
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)1);				
				memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);
	
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{				

					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{			
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);

							memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
						}

						catch(SocketException exception_Socket)
						{	
							memoryStream_Socks4ConnetionRequest.Close();
						
							throw new UnableToResolveHostName();
						}
					}

					else
					{
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)1);

						memoryStream_Socks4ConnetionRequest.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}				
				}	
			
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);

				if(SendingSocks4ConnectionRequest != null) SendingSocks4ConnectionRequest();
				socket_Link.Send(memoryStream_Socks4ConnetionRequest.GetBuffer());

				memoryStream_Socks4ConnetionRequest.Close();

				if(WaitingForReplyToSocks4ConnectionRequest != null) WaitingForReplyToSocks4ConnectionRequest();
			
				int int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(socket_Link.Available <= 0)
				{
					memoryStream_Socks4ConnetionRequest.Close();
				
					socket_Link.Close();
			
					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks4ConnectionResponse);

				if(socket_Link.Available > 0 || byteArray_Socks4ConnectionResponse[0] != (byte)0 
					|| byteArray_Socks4ConnectionResponse[1] != (byte)90)
				{			

					if(socket_Link.Available > 0 || byteArray_Socks4ConnectionResponse[0] != (byte)0)
					{
						socket_Link.Close();

						throw new Socks4ServiceNotFoundException();
					}

					socket_Link.Close();

					if(byteArray_Socks4ConnectionResponse[1] != (byte)90)
					{
						switch((int)byteArray_Socks4ConnectionResponse[1])
						{			
							case 91:
								throw new RequestRejectedOrFailed();

							case 92:
								throw new IdentdOnClientNotResponse();
								
							case 93:
								throw new DifferentUserIDs();							
	
							default:
								throw new Socks4ServiceNotFoundException();				
						}
					}		
				}
			}	

		
			/// <summary> 
			/// Connect input TcpClient object to selected Server through Socks Proxy Server version 4.
			/// </summary>
			/// 
			/// <param name="tcpClient_Link">  
			/// Reference to TcpClient object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// TcpClient tcpClient_Link = new TcpClient();
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks4Proxy(ref tcpClient_Link, “10.0.0.1”, 80,  “10.0.0.5”, 1080, false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks4Proxy(ref TcpClient tcpClient_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
			
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort ) 
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}
				if(tcpClient_Link == null) tcpClient_Link = new TcpClient();

				try
				{
					tcpClient_LinkToCloseByTimeOut = tcpClient_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					tcpClient_Link.Connect(string_ProxyHost, int_ProxyPort);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{	
					tcpClient_Link.Close();					
				
					throw new ProxyConnectionException();
				}

				NetworkStream networkStream_Link = tcpClient_Link.GetStream();				

				memoryStream_Socks4ConnetionRequest.SetLength(0);
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)4);				
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)1);				
				memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);
	
				try
				{
					IPAddress ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{				
					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{			
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);

							memoryStream_Socks4ConnetionRequest.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
						}

						catch(SocketException exception_Socket)
						{	
							memoryStream_Socks4ConnetionRequest.Close();
						
							throw new UnableToResolveHostName();
						}
					}

					else
					{
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);
						memoryStream_Socks4ConnetionRequest.WriteByte((byte)1);

						memoryStream_Socks4ConnetionRequest.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}	
				
				}					
			
				memoryStream_Socks4ConnetionRequest.WriteByte((byte)0);		

				if(SendingSocks4ConnectionRequest != null) SendingSocks4ConnectionRequest();
				networkStream_Link.Write(memoryStream_Socks4ConnetionRequest.GetBuffer(), 0, (int)memoryStream_Socks4ConnetionRequest.Position);
	
				memoryStream_Socks4ConnetionRequest.Close();			
			
				if(WaitingForReplyToSocks4ConnectionRequest != null) WaitingForReplyToSocks4ConnectionRequest();
		
				int int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(!networkStream_Link.DataAvailable)
				{
					memoryStream_Socks4ConnetionRequest.Close();
				
					networkStream_Link.Close();
				
					tcpClient_Link.Close();
				
					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks4ConnectionResponse, 0, byteArray_Socks4ConnectionResponse.Length);
			
				if(networkStream_Link.DataAvailable || byteArray_Socks4ConnectionResponse[0] != (byte)0 
					|| byteArray_Socks4ConnectionResponse[1] != (byte)90)
				{

					if(networkStream_Link.DataAvailable || 
						byteArray_Socks4ConnectionResponse[0] != (byte)0)					
					{
						networkStream_Link.Close();		
					
						tcpClient_Link.Close();
					
						throw new Socks4ServiceNotFoundException();
					}

					networkStream_Link.Close();		
					tcpClient_Link.Close();

				
					if(byteArray_Socks4ConnectionResponse[1] != (byte)90)
					{
						switch((int)byteArray_Socks4ConnectionResponse[1])
						{			

							case 91:
								throw new RequestRejectedOrFailed();

							case 92:
								throw new IdentdOnClientNotResponse();
								
							case 93:
								throw new DifferentUserIDs();	
							
							default:						
								throw new Socks4ServiceNotFoundException();
					
						}
					}		
				}			
			}
	
	

			/// <summary> 
			/// Connect input Socket object to selected Server through Socks Proxy Server version 5. 
			/// </summary>
			/// 
			/// <overloads>
			/// Connect to selected Server through Socks Proxy Server version 5. 
			/// </overloads>
			/// 
			/// <param name="socket_Link">  
			/// Reference to Socket object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// Socket socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks5Proxy(ref socket_Client, “10.0.0.1”, 80,  “10.0.0.5”, 1080, false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks5Proxy(ref Socket socket_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();
			
				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
			
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort ) 
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}
				IPAddress ipAddress_DstHost;
				IPEndPoint ipEndPoint_ProxyAddress;
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_ProxyHost);
					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_DstHost, int_ProxyPort);
				}

				catch(FormatException exception)
				{	
					ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
				}
	
				if(socket_Link == null) socket_Link = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					socket_LinkToCloseByTimeOut = socket_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					socket_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					socket_Link.Close();

					throw new ProxyConnectionException();
				}

		
				byteArray_Socks5ConnetionRequest[0] = (byte)5;
				byteArray_Socks5ConnetionRequest[1] = (byte)1;
				byteArray_Socks5ConnetionRequest[2] = (byte)0;

				if(SendingSocks5ConnectionRequest != null) SendingSocks5ConnectionRequest();
				socket_Link.Send(byteArray_Socks5ConnetionRequest);
			
				if(WaitingForReplyToSocks5ConnectionRequest!= null) WaitingForReplyToSocks5ConnectionRequest();
			
				int int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks5ConnectionResponse);

				if(socket_Link.Available > 0 || byteArray_Socks5ConnectionResponse[0] != (byte)5 ||
					byteArray_Socks5ConnectionResponse[1] == (byte)255 || byteArray_Socks5ConnectionResponse[1] != (byte)0)
				{
				
					if(socket_Link.Available > 0) 
					{	
						socket_Link.Close();
					
						throw new Socks5ServiceNotFoundException();					
					}

					socket_Link.Close();

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5) 
					{
						throw new Socks5ServiceNotFoundException();
					}
					if(byteArray_Socks5ConnectionResponse[1] == (byte)255) 
					{
						throw new NoAcceptableMethodsException();
					}
					if(byteArray_Socks5ConnectionResponse[1] != (byte)0) 
					{
						throw new AuthenticationRequiredException();
					}
		
				}

				memoryStream_Socks5RequestDetails.SetLength(0);
				memoryStream_Socks5RequestDetails.WriteByte((byte)5);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)1);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)0);
	
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks5RequestDetails.WriteByte((byte)1);
					memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{		
					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{			
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);

							memoryStream_Socks5RequestDetails.WriteByte((byte)1);
							memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
						}

						catch(SocketException exception_Socket)
						{
							memoryStream_Socks5RequestDetails.Close();

							throw new UnableToResolveHostName();
						}
					}

					else
					{
						memoryStream_Socks5RequestDetails.WriteByte((byte)3);
			
						memoryStream_Socks5RequestDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
						memoryStream_Socks5RequestDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}
				}

				
			
				memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);
			
				if(SendingSocks5RequestDetails != null) SendingSocks5RequestDetails();
				socket_Link.Send(memoryStream_Socks5RequestDetails.GetBuffer());
			
				memoryStream_Socks5RequestDetails.Close();

				if(WaitingForReplyToSocks5RequestDetails != null) WaitingForReplyToSocks5RequestDetails();
				int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					memoryStream_Socks5RequestDetails.Close();

					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks5ReplyToRequestDetails);

				if(socket_Link.Available > 0 || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5 
					|| byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
				{	
				
					if(socket_Link.Available > 0 || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5) 					
					{
						socket_Link.Close();

						throw new Socks5ServiceNotFoundException();
					}

					socket_Link.Close();

					if(byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
					{
						switch((int)byteArray_Socks5ReplyToRequestDetails[1])
						{			
							case 1:
								throw new GeneralSocksServerFailureException();

							case 2:
								throw new ConnectionNotAllowedException();
					
							case 3:
								throw new NetworkUnreachableException();

							case 4:
								throw new HostUnreachableException();
				
							case 5:
								throw new ConnectionRefusedException();
		
							case 6:
								throw new TTLExpiredException();
				
							case 7:
								throw new UnsupportedSocksCommandException();
				
							case 8:
								throw new UnsupportedAddressTypeException();
	
							default:				
								throw new Socks5ServiceNotFoundException();					
						}
					}	
				}
			}

		
			/// <summary> 
			/// Connect input TcpClient object to selected Server through Socks Proxy Server version 5.
			/// </summary>
			/// 
			/// <param name="tcpClient_Link">  
			/// Reference to TcpClient object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// TcpClient tcpClient_Link = new TcpClient();
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_Link, “10.0.0.1”, 80,  “10.0.0.5”, 1080, false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks5Proxy(ref TcpClient tcpClient_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{	
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort ) 
				{				
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}
				if(tcpClient_Link == null) tcpClient_Link = new TcpClient();

				try
				{
					tcpClient_LinkToCloseByTimeOut = tcpClient_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					tcpClient_Link.Connect(string_ProxyHost, int_ProxyPort);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{	
					tcpClient_Link.Close();					
				
					throw new ProxyConnectionException();
				}

				NetworkStream networkStream_Link = tcpClient_Link.GetStream();
			
				byteArray_Socks5ConnetionRequest[0] = (byte)5;
				byteArray_Socks5ConnetionRequest[1] = (byte)1;
				byteArray_Socks5ConnetionRequest[2] = (byte)0;

				if(SendingSocks5ConnectionRequest != null) SendingSocks5ConnectionRequest();
				networkStream_Link.Write(byteArray_Socks5ConnetionRequest, 0, byteArray_Socks5ConnetionRequest.Length);
			
				if(WaitingForReplyToSocks5ConnectionRequest != null) WaitingForReplyToSocks5ConnectionRequest();
				int int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(!networkStream_Link.DataAvailable)
				{
					networkStream_Link.Close();
				
					tcpClient_Link.Close();

					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks5ConnectionResponse, 0, byteArray_Socks5ConnectionResponse.Length);

				if(networkStream_Link.DataAvailable || byteArray_Socks5ConnectionResponse[0] != (byte)5 ||
					byteArray_Socks5ConnectionResponse[1] == (byte)255 || byteArray_Socks5ConnectionResponse[1] != (byte)0)
				{				
					if(networkStream_Link.DataAvailable)
					{
						networkStream_Link.Close();
					
						tcpClient_Link.Close();		
					
						throw new Socks5ServiceNotFoundException();
					}

					networkStream_Link.Close();
					tcpClient_Link.Close();		

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5)
					{
						throw new Socks5ServiceNotFoundException();
					}
					if(byteArray_Socks5ConnectionResponse[1] == (byte)255)
					{
						throw new NoAcceptableMethodsException();
					}
					if(byteArray_Socks5ConnectionResponse[1] != (byte)0) 
					{
						throw new AuthenticationRequiredException();
					}
				}
			
				memoryStream_Socks5RequestDetails.SetLength(0);
				memoryStream_Socks5RequestDetails.WriteByte((byte)5);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)1);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)0);
	
				try
				{
					IPAddress ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks5RequestDetails.WriteByte((byte)1);

					memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{				
					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{			
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);

							memoryStream_Socks5RequestDetails.WriteByte((byte)1);
							memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
						}

						catch(SocketException exception_Socket)
						{	
							memoryStream_Socks5RequestDetails.Close();
						
							throw new UnableToResolveHostName();
						}
					}

					else
					{
						memoryStream_Socks5RequestDetails.WriteByte((byte)3);
			
						memoryStream_Socks5RequestDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
						memoryStream_Socks5RequestDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}
				}
				
				memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);

				if(SendingSocks5RequestDetails != null) SendingSocks5RequestDetails();
				networkStream_Link.Write(memoryStream_Socks5RequestDetails.GetBuffer(), 0, (int)memoryStream_Socks5RequestDetails.Position);
			
				memoryStream_Socks5RequestDetails.Close();

				if(WaitingForReplyToSocks5RequestDetails != null) WaitingForReplyToSocks5RequestDetails();
				int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(!networkStream_Link.DataAvailable)
				{
					memoryStream_Socks5RequestDetails.Close();
				
					networkStream_Link.Close();
				
					tcpClient_Link.Close();
				
					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks5ReplyToRequestDetails, 0, byteArray_Socks5ReplyToRequestDetails.Length);

				if(networkStream_Link.DataAvailable || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5 
					|| byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
				{
			
					if(networkStream_Link.DataAvailable || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5) 
					{
						networkStream_Link.Close();		
					
						tcpClient_Link.Close();
					
						throw new Socks5ServiceNotFoundException();
					}
			
					networkStream_Link.Close();		
					tcpClient_Link.Close();

					if(byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
					{
						switch((int)byteArray_Socks5ReplyToRequestDetails[1])
						{			

							case 1:
								throw new GeneralSocksServerFailureException();

							case 2:
								throw new ConnectionNotAllowedException();
								
							case 3:
								throw new NetworkUnreachableException();

							case 4:
								throw new HostUnreachableException();
							
							case 5:
								throw new ConnectionRefusedException();
						
							case 6:
								throw new TTLExpiredException();
								
							case 7:
								throw new UnsupportedSocksCommandException();
						
							case 8:
								throw new UnsupportedAddressTypeException();
	
							default:					
								throw new Socks5ServiceNotFoundException();					
						}
					}		
				}
			}	

		
			/// <summary> 
			/// Connect input Socket object to selected Server through Socks Proxy Server version 5 with Plain Text authentication. 
			/// </summary>
			/// 
			/// <param name="socket_Link">  
			/// Reference to Socket object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// 
			/// <param name="string_UserName">
			/// Parameter string_UserName are indicate User Name used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="string_Password">
			/// Parameter string_Password are indicate Password used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// Socket socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks5Proxy(ref socket_Client, “10.0.0.1”, 80,  “10.0.0.5”, 1080, "testLogin", "testPass", false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks5Proxy(ref Socket socket_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, string string_UserName, string string_Password, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				if(string_UserName.Length > 255 || string_UserName.Length <= 0) 
				{	
					throw new ArgumentOutOfRangeException("UserName", "Specified argument was out of the range of valid values.");
				}
				if(string_Password.Length > 255) 
				{				
					throw new ArgumentOutOfRangeException("Password", "Specified argument was out of the range of valid values.");
				}
				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort ) 
				{				
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort ) 
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}
				IPAddress ipAddress_DstHost;
				IPEndPoint ipEndPoint_ProxyAddress;
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_ProxyHost);
					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_DstHost, int_ProxyPort);
				}

				catch(FormatException exception)
				{	
					try
					{
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}
	
				if(socket_Link == null) socket_Link = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					socket_LinkToCloseByTimeOut = socket_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					socket_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					socket_Link.Close();
				
					throw new ProxyConnectionException();
				}
		
				byteArray_Socks5ConnetionRequest[0] = (byte)5;
				byteArray_Socks5ConnetionRequest[1] = (byte)1;
				byteArray_Socks5ConnetionRequest[2] = (byte)2;

				if(SendingSocks5ConnectionRequest != null) SendingSocks5ConnectionRequest();
				socket_Link.Send(byteArray_Socks5ConnetionRequest);
			
				if(WaitingForReplyToSocks5ConnectionRequest != null) WaitingForReplyToSocks5ConnectionRequest();
				int int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();
				
					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks5ConnectionResponse);

				if(socket_Link.Available > 0 || byteArray_Socks5ConnectionResponse[0] != (byte)5 ||
					byteArray_Socks5ConnectionResponse[1] == (byte)255 || byteArray_Socks5ConnectionResponse[1] != (byte)2)
				{
				
					if(socket_Link.Available > 0) 
					{	
						socket_Link.Close();
					
						throw new Socks5ServiceNotFoundException();					
					}

					socket_Link.Close();

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5)
					{
						throw new Socks5ServiceNotFoundException();
					}
	
					if(byteArray_Socks5ConnectionResponse[1] == (byte)255) 
					{
						throw new NoAcceptableMethodsException();
					}
					if(byteArray_Socks5ConnectionResponse[1] != (byte)2) 
					{
						throw new AuthenticationNotAllowedException();
					}
		
				}

				memoryStream_Socks5AuthenticationDetails.SetLength(0);
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)5);
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_UserName));				
				memoryStream_Socks5AuthenticationDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_UserName), 0, (byte)ASCIIEncoding.ASCII.GetByteCount(string_UserName));				
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_Password));	
				memoryStream_Socks5AuthenticationDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_Password), 0, (byte)ASCIIEncoding.ASCII.GetByteCount(string_Password));		
	
				if(SendingSocks5AuthenticationRequest != null) SendingSocks5AuthenticationRequest();
				socket_Link.Send(memoryStream_Socks5AuthenticationDetails.GetBuffer());
			
				memoryStream_Socks5AuthenticationDetails.Close();

				if(WaitingForReplyToSocks5AuthenticationRequest != null) WaitingForReplyToSocks5AuthenticationRequest();
				int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks5ConnectionResponse);

				if(socket_Link.Available > 0 || byteArray_Socks5ConnectionResponse[0] != (byte)5
					|| byteArray_Socks5ConnectionResponse[1] != (byte)0)
				{
				
					if(socket_Link.Available > 0)
					{
						socket_Link.Close();
		
						throw new Socks5ServiceNotFoundException();
					}

					socket_Link.Close();		

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5)
					{
						throw new Socks5ServiceNotFoundException();
					}	
					if(byteArray_Socks5ConnectionResponse[1] != (byte)0) 
					{
						throw new AuthenticationFailureException();
					}
				}


				memoryStream_Socks5RequestDetails.SetLength(0);
				memoryStream_Socks5RequestDetails.WriteByte((byte)5);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)1);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)0);
	
				try
				{
					ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks5RequestDetails.WriteByte((byte)1);
					memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{		
					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{			
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);
						}
						catch(SocketException exception_Socket)
						{		
							memoryStream_Socks5RequestDetails.Close();	
			
							throw new UnableToResolveHostName();
						}

						memoryStream_Socks5RequestDetails.WriteByte((byte)1);
						memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
					}

					else
					{
						memoryStream_Socks5RequestDetails.WriteByte((byte)3);
			
						memoryStream_Socks5RequestDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
						memoryStream_Socks5RequestDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}
				}

				
				memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);

				if(SendingSocks5RequestDetails != null) SendingSocks5RequestDetails();
				socket_Link.Send(memoryStream_Socks5RequestDetails.GetBuffer());
			
				memoryStream_Socks5RequestDetails.Close();

				if(WaitingForReplyToSocks5RequestDetails != null) WaitingForReplyToSocks5RequestDetails();
				int_InternalTimeOutCount = 0;
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					memoryStream_Socks5RequestDetails.Close();

					throw new TimeOutException();
				}
				else socket_Link.Receive(byteArray_Socks5ReplyToRequestDetails);

				if(socket_Link.Available > 0 || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5 
					|| byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
				{									
					if(socket_Link.Available > 0 || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5) 					
					{
						socket_Link.Close();
					
						throw new Socks5ServiceNotFoundException();
					}

					socket_Link.Close();

					if(byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
					{
						switch((int)byteArray_Socks5ReplyToRequestDetails[1])
						{			
							case 1:
								throw new GeneralSocksServerFailureException();

							case 2:
								throw new ConnectionNotAllowedException();
					
							case 3:
								throw new NetworkUnreachableException();

							case 4:
								throw new HostUnreachableException();
				
							case 5:
								throw new ConnectionRefusedException();
		
							case 6:
								throw new TTLExpiredException();
				
							case 7:
								throw new UnsupportedSocksCommandException();
				
							case 8:
								throw new UnsupportedAddressTypeException();
	
							default:				
								throw new Socks5ServiceNotFoundException();
					
						}
					}	
				}
			}

		
			/// <summary> 
			/// Connect input TcpClient object to selected Server through Socks Proxy Server version 5 with Plain Text authentication. 
			/// </summary>
			/// 
			/// <param name="tcpClient_Link">  
			/// Reference to TcpClient object, which will be connected to the selected Host through necessary Socks Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through Socks Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of Socks Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of Socks Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// 
			/// <param name="string_UserName">
			/// Parameter string_UserName are indicate User Name used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="string_Password">
			/// Parameter string_Password are indicate Password used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through Socks Proxy Server version 4 
			/// <code>
			/// 
			/// TcpClient tcpClient_Link = new TcpClient();
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughSocks5Proxy(ref tcpClient_Link, “10.0.0.1”, 80,  “10.0.0.5”, 1080, "testLogin", "testPass", false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughSocks5Proxy(ref TcpClient tcpClient_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, string string_UserName, string string_Password, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				if(string_UserName.Length > 255 || string_UserName.Length <= 0) 
				{	
					throw new ArgumentOutOfRangeException("UserName", "Specified argument was out of the range of valid values.");
				}
				if(string_Password.Length > 255) 
				{
					throw new ArgumentOutOfRangeException("Password", "Specified argument was out of the range of valid values.");
				}
				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort ) 
				{				
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort ) 
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.t");
				}
				if(tcpClient_Link == null) tcpClient_Link = new TcpClient();

				try
				{
					tcpClient_LinkToCloseByTimeOut = tcpClient_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					tcpClient_Link.Connect(string_ProxyHost, int_ProxyPort);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{	
					tcpClient_Link.Close();		
			
					throw new ProxyConnectionException();
				}

				NetworkStream networkStream_Link = tcpClient_Link.GetStream();
			
				byteArray_Socks5ConnetionRequest[0] = (byte)5;
				byteArray_Socks5ConnetionRequest[1] = (byte)1;
				byteArray_Socks5ConnetionRequest[2] = (byte)2;

				if(SendingSocks5ConnectionRequest != null) SendingSocks5ConnectionRequest();
				networkStream_Link.Write(byteArray_Socks5ConnetionRequest, 0, byteArray_Socks5ConnetionRequest.Length);
			
				if(WaitingForReplyToSocks5ConnectionRequest != null) WaitingForReplyToSocks5ConnectionRequest();
				int int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(!networkStream_Link.DataAvailable)
				{
					networkStream_Link.Close();
				
					tcpClient_Link.Close();

					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks5ConnectionResponse, 0, byteArray_Socks5ConnectionResponse.Length);

				if(networkStream_Link.DataAvailable || byteArray_Socks5ConnectionResponse[0] != (byte)5 ||
					byteArray_Socks5ConnectionResponse[1] == (byte)255 || byteArray_Socks5ConnectionResponse[1] != (byte)2)
				{
				
					if(networkStream_Link.DataAvailable)
					{
						networkStream_Link.Close();
					
						tcpClient_Link.Close();		
					
						throw new Socks5ServiceNotFoundException();
					}

					networkStream_Link.Close();
					tcpClient_Link.Close();		

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5)
					{
						throw new Socks5ServiceNotFoundException();
					}
					if(byteArray_Socks5ConnectionResponse[1] == (byte)255)
					{
						throw new NoAcceptableMethodsException();
					}
					if(byteArray_Socks5ConnectionResponse[1] != (byte)2) 
					{
						throw new AuthenticationNotAllowedException();
					}
				}

				memoryStream_Socks5AuthenticationDetails.SetLength(0);
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)5);
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_UserName));				
				memoryStream_Socks5AuthenticationDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_UserName), 0, (byte)ASCIIEncoding.ASCII.GetByteCount(string_UserName));				
				memoryStream_Socks5AuthenticationDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_Password));	
				memoryStream_Socks5AuthenticationDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_Password), 0, (byte)ASCIIEncoding.ASCII.GetByteCount(string_Password));		
	
				if(SendingSocks5AuthenticationRequest != null) SendingSocks5AuthenticationRequest();
				networkStream_Link.Write(memoryStream_Socks5AuthenticationDetails.GetBuffer(), 0, (int)memoryStream_Socks5AuthenticationDetails.Position);
			
				memoryStream_Socks5AuthenticationDetails.Close();

				if(WaitingForReplyToSocks5AuthenticationRequest != null) WaitingForReplyToSocks5AuthenticationRequest();
				int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(!networkStream_Link.DataAvailable)
				{
					networkStream_Link.Close();
			
					tcpClient_Link.Close();

					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks5ConnectionResponse, 0, byteArray_Socks5ConnectionResponse.Length);

				if(networkStream_Link.DataAvailable || byteArray_Socks5ConnectionResponse[0] != (byte)5
					|| byteArray_Socks5ConnectionResponse[1] != (byte)0)
				{
				
					if(networkStream_Link.DataAvailable)
					{
						networkStream_Link.Close();
					
						tcpClient_Link.Close();		
					
						throw new Socks5ServiceNotFoundException();
					}

					networkStream_Link.Close();
					tcpClient_Link.Close();		

					if(byteArray_Socks5ConnectionResponse[0] != (byte)5)
					{
						throw new Socks5ServiceNotFoundException();
					}
					if(byteArray_Socks5ConnectionResponse[1] != (byte)0) 
					{
						throw new AuthenticationFailureException();
					}
				}

				memoryStream_Socks5RequestDetails.SetLength(0);
				memoryStream_Socks5RequestDetails.WriteByte((byte)5);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)1);				
				memoryStream_Socks5RequestDetails.WriteByte((byte)0);
	
				try
				{
					IPAddress ipAddress_DstHost = IPAddress.Parse(string_DstHost);

					memoryStream_Socks5RequestDetails.WriteByte((byte)1);

					memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipAddress_DstHost.Address), 0, 4);
				}

				catch(FormatException exception)
				{				
					IPHostEntry ipHostEntry_ResolvingHost = new IPHostEntry();
				
					if(!bool_UseProxyToResolveHostnames)
					{
						try
						{
							ipHostEntry_ResolvingHost = Dns.Resolve(string_DstHost);
						}
						catch(SocketException exception_Socket)
						{							
							memoryStream_Socks5RequestDetails.Close();

							throw new UnableToResolveHostName();
						}

						memoryStream_Socks5RequestDetails.WriteByte((byte)1);
						memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(ipHostEntry_ResolvingHost.AddressList[0].Address), 0, 4);
					}

					else
					{
						memoryStream_Socks5RequestDetails.WriteByte((byte)3);
			
						memoryStream_Socks5RequestDetails.WriteByte((byte)ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
						memoryStream_Socks5RequestDetails.Write(ASCIIEncoding.ASCII.GetBytes(string_DstHost), 0, ASCIIEncoding.ASCII.GetByteCount(string_DstHost));
					}
				}
				
				memoryStream_Socks5RequestDetails.Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((Int16)int_DstPort)), 0, 2);

				if(SendingSocks5RequestDetails != null) SendingSocks5RequestDetails();
				networkStream_Link.Write(memoryStream_Socks5RequestDetails.GetBuffer(), 0, (int)memoryStream_Socks5RequestDetails.Position);
			
				memoryStream_Socks5RequestDetails.Close();

				if(WaitingForReplyToSocks5RequestDetails != null) WaitingForReplyToSocks5RequestDetails();
				int_InternalTimeOutCount = 0;
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{	
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}
		
				if(!networkStream_Link.DataAvailable)
				{
					memoryStream_Socks5RequestDetails.Close();
				
					networkStream_Link.Close();
				
					tcpClient_Link.Close();
			
					throw new TimeOutException();
				}
				else networkStream_Link.Read(byteArray_Socks5ReplyToRequestDetails, 0, byteArray_Socks5ReplyToRequestDetails.Length);

				if(networkStream_Link.DataAvailable || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5 
					|| byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
				{
			
					if(networkStream_Link.DataAvailable || byteArray_Socks5ReplyToRequestDetails[0] != (byte)5) 
					{
						networkStream_Link.Close();		

						tcpClient_Link.Close();

						throw new Socks5ServiceNotFoundException();
					}
			
					networkStream_Link.Close();		
					tcpClient_Link.Close();

					if(byteArray_Socks5ReplyToRequestDetails[1] != (byte)0)
					{
						switch((int)byteArray_Socks5ReplyToRequestDetails[1])
						{
							case 1:
								throw new GeneralSocksServerFailureException();

							case 2:
								throw new ConnectionNotAllowedException();
								
							case 3:
								throw new NetworkUnreachableException();

							case 4:
								throw new HostUnreachableException();
							
							case 5:
								throw new ConnectionRefusedException();
						
							case 6:
								throw new TTLExpiredException();
								
							case 7:
								throw new UnsupportedSocksCommandException();
						
							case 8:
								throw new UnsupportedAddressTypeException();
	
							default:					
								throw new Socks5ServiceNotFoundException();					
						}
					}		
				}
			}	

			
			
			/// <summary> 
			/// Connect input Socket object to selected Server through HTTPS Proxy Server. 
			/// </summary>
			/// 
			/// <overloads>
			/// Connect to selected Server through HTTPS Proxy Server. 
			/// </overloads>
			/// 
			/// <param name="socket_Link">  
			/// Reference to Socket object, which will be connected to the selected Host through necessary HTTPS Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of HTTPS Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of HTTPS Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through HTTPS Proxy Server version 4 
			/// <code>
			/// 
			/// Socket socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughHTTPSProxy(ref socket_Client, “10.0.0.1”, 80,  “10.0.0.5”, 1080,  false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughHTTPSProxy(ref Socket socket_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				byte [] byteArray_HTTPSConnectionResponse = null, byteArray_HTTPSConnectionRequest = null;

				string string_HTTPSConnectionResponse, string_HTTPSConnectionRequest;


				IPAddress ipAddress_Host;
				IPEndPoint ipEndPoint_ProxyAddress;
		
				if(bool_UseProxyToResolveHostnames == true)
					try
					{
						ipAddress_Host = IPAddress.Parse(string_DstHost);
						string_DstHost = ipAddress_Host.ToString();

					}
					catch(FormatException exception)
					{	
						try
						{
							ipAddress_Host = Dns.Resolve(string_DstHost).AddressList[0];
							string_DstHost = ipAddress_Host.ToString();
						}
						catch(SocketException exception_Socket)
						{							
							throw new UnableToResolveHostName();
						}
					}

			


				string_HTTPSConnectionRequest = "CONNECT " + string_DstHost.ToString() + ":" + int_DstPort.ToString() + " HTTP/1.0\n\n";

				byteArray_HTTPSConnectionRequest = System.Text.Encoding.ASCII.GetBytes(string_HTTPSConnectionRequest);
			
				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}

				try
				{
					ipAddress_Host = IPAddress.Parse(string_ProxyHost);

					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_Host, int_ProxyPort);
				}
				catch(FormatException exception)
				{	
					try
					{
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}

				if(socket_Link == null) socket_Link = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					socket_LinkToCloseByTimeOut = socket_Link;

					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					socket_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					socket_Link.Close();
				
					throw new ProxyConnectionException();
				}
	
				if(SendingHTTPSConnectionRequest != null)
				{
					SendingHTTPSConnectionRequest();	
				}

				if(SendingHTTPSConnectionRequest != null) SendingHTTPSConnectionRequest();

				socket_Link.Send(byteArray_HTTPSConnectionRequest);		
	
				if(WaitingForReplyToHTTPSConnectionRequest != null) WaitingForReplyToHTTPSConnectionRequest();

				int int_InternalTimeOutCount = 0;			
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}				

				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					throw new TimeOutException();
				}
				else 
				{
					byteArray_HTTPSConnectionResponse = new byte[socket_Link.Available];
					
					socket_Link.Receive(byteArray_HTTPSConnectionResponse);
				}

				string_HTTPSConnectionResponse = System.Text.Encoding.ASCII.GetString(byteArray_HTTPSConnectionResponse);

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 200", 8, 11) != -1)
				{				
					return;
				}

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 407", 8, 11) != -1)
				{				
					throw new AuthenticationRequiredException();
				}
			}

				
			/// <summary> 
			/// Connect input TcpClient object to selected Server through HTTPS Proxy Server. 
			/// </summary>
			/// 
			/// <param name="tcpClient_Link">  
			/// Reference to TcpClient object, which will be connected to the selected Host through necessary HTTPS Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of HTTPS Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of HTTPS Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through HTTPS Proxy Server version 4 
			/// <code>
			/// 
			/// TcpClient tcpClient_Link = new TcpClient();
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_Link, “10.0.0.1”, 80,  “10.0.0.5”, 1080, false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughHTTPSProxy(ref TcpClient tcpClient_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{		
				CheckSN();

				byte [] byteArray_HTTPSConnectionResponse = null, byteArray_HTTPSConnectionRequest = null;

				string string_HTTPSConnectionResponse, string_HTTPSConnectionRequest;


				IPAddress ipAddress_Host;
				IPEndPoint ipEndPoint_ProxyAddress;
		

				if(bool_UseProxyToResolveHostnames == true)
				{
					try
					{
						ipAddress_Host = IPAddress.Parse(string_DstHost);
						string_DstHost = ipAddress_Host.ToString();
					}
					catch(FormatException exception)
					{
						try
						{
							ipAddress_Host = Dns.Resolve(string_DstHost).AddressList[0];
							string_DstHost = ipAddress_Host.ToString();
						}
						catch(SocketException exception_Socket)
						{							
							throw new UnableToResolveHostName();
						}
					}
				}

				string_HTTPSConnectionRequest = "CONNECT " + string_DstHost.ToString() + ":" + int_DstPort.ToString() + " HTTP/1.0\n\n";

				byteArray_HTTPSConnectionRequest = System.Text.Encoding.ASCII.GetBytes(string_HTTPSConnectionRequest);
			
				MemoryStream memoryStream_ReceivedData = new MemoryStream();

				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}


				try
				{
					ipAddress_Host = IPAddress.Parse(string_ProxyHost);
					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_Host, int_ProxyPort);
				}
				catch(FormatException exception)
				{	
					try
					{
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}			

				if(tcpClient_Link == null) tcpClient_Link = new TcpClient();


				try
				{
					tcpClient_LinkToCloseByTimeOut = tcpClient_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					tcpClient_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					tcpClient_Link.Close();
				
					throw new ProxyConnectionException();
				}
	
				NetworkStream networkStream_Link = tcpClient_Link.GetStream();
			
				if(SendingHTTPSConnectionRequest != null) SendingHTTPSConnectionRequest();

				networkStream_Link.Write(byteArray_HTTPSConnectionRequest, 0, byteArray_HTTPSConnectionRequest.Length);
			
				if(WaitingForReplyToHTTPSConnectionRequest != null) WaitingForReplyToHTTPSConnectionRequest();
			
				int int_InternalTimeOutCount = 0;			
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(!networkStream_Link.DataAvailable)
				{
					networkStream_Link.Close();
				
					tcpClient_Link.Close();

					throw new TimeOutException();
				}
				else 
				{			
					while(networkStream_Link.DataAvailable)
					{
						memoryStream_ReceivedData.WriteByte((byte)networkStream_Link.ReadByte());			
					}
				
					byteArray_HTTPSConnectionResponse = memoryStream_ReceivedData.ToArray();				
				}

				string_HTTPSConnectionResponse = System.Text.Encoding.ASCII.GetString(byteArray_HTTPSConnectionResponse);

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 200", 8, 11) != -1)
				{
					return;
				}		

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 407", 8, 11) != -1)
				{				
					throw new AuthenticationRequiredException();
				}		
			}	
		


			/// <summary> 
			/// Connect input Socket object to selected Server through HTTPS Proxy Server with Basic authentication method. 
			/// </summary>
			/// 
			/// <param name="socket_Link">  
			/// Reference to Socket object, which will be connected to the selected Host through necessary HTTPS Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of HTTPS Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of HTTPS Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// 
			/// <param name="string_UserName">
			/// Parameter string_UserName are indicate User Name used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="string_Password">
			/// Parameter string_Password are indicate Password used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through HTTPS Proxy Server version 4 
			/// <code>
			/// 
			/// Socket socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughHTTPSProxy(ref socket_Client, “10.0.0.1”, 80,  “10.0.0.5”, 1080, "testLogin", "testPass", false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughHTTPSProxy(ref Socket socket_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, string string_UserName, string string_Password, bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				byte [] byteArray_HTTPSConnectionResponse = null, byteArray_HTTPSConnectionRequest = null, byteArray_HTTPSAuthData = null;

				string string_HTTPSConnectionResponse, string_HTTPSConnectionRequest, string_Base64HTTPSAuthData;

				IPAddress ipAddress_Host;
				IPEndPoint ipEndPoint_ProxyAddress;
		
				if(bool_UseProxyToResolveHostnames == true)
					try
					{
						ipAddress_Host = IPAddress.Parse(string_DstHost);
						string_DstHost = ipAddress_Host.ToString();

					}
					catch(FormatException exception)
					{	
						try
						{
							ipAddress_Host = Dns.Resolve(string_DstHost).AddressList[0];
							string_DstHost = ipAddress_Host.ToString();
						}
						catch(SocketException exception_Socket)
						{							
							throw new UnableToResolveHostName();
						}
					}

			
				string_HTTPSConnectionRequest = "CONNECT " + string_DstHost.ToString() + ":" + int_DstPort.ToString() + 
					" HTTP/1.0\n" + "Proxy-Authorization: Basic ";

				byteArray_HTTPSAuthData = System.Text.Encoding.ASCII.GetBytes(string_UserName + ":" + string_Password);

				string_Base64HTTPSAuthData = System.Convert.ToBase64String(byteArray_HTTPSAuthData, 0, byteArray_HTTPSAuthData.Length);
 
				string_HTTPSConnectionRequest += string_Base64HTTPSAuthData + "\n\n";
	
				byteArray_HTTPSConnectionRequest = System.Text.Encoding.ASCII.GetBytes(string_HTTPSConnectionRequest);
					


				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}

				try
				{
					ipAddress_Host = IPAddress.Parse(string_ProxyHost);

					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_Host, int_ProxyPort);
				}
				catch(FormatException exception)
				{	
					try
					{
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}

				if(socket_Link == null) socket_Link = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					socket_LinkToCloseByTimeOut = socket_Link;

					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					socket_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					socket_Link.Close();
				
					throw new ProxyConnectionException();
				}
	
				if(SendingHTTPSConnectionRequest != null)
				{
					SendingHTTPSConnectionRequest();	
				}

				if(SendingHTTPSConnectionRequest != null) SendingHTTPSConnectionRequest();

				if(SendingHTTPSAuthenticationRequest != null) SendingHTTPSAuthenticationRequest();

				socket_Link.Send(byteArray_HTTPSConnectionRequest);		
	
				if(WaitingForReplyToHTTPSConnectionRequest != null) WaitingForReplyToHTTPSConnectionRequest();

				if(WaitingForReplyToHTTPSAuthenticationRequest != null) WaitingForReplyToHTTPSAuthenticationRequest();

				int int_InternalTimeOutCount = 0;			
				while(socket_Link.Available <= 0 && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}				

				if(socket_Link.Available <= 0)
				{
					socket_Link.Close();

					throw new TimeOutException();
				}
				else 
				{
					byteArray_HTTPSConnectionResponse = new byte[socket_Link.Available];
					
					socket_Link.Receive(byteArray_HTTPSConnectionResponse);
				}

				string_HTTPSConnectionResponse = System.Text.Encoding.ASCII.GetString(byteArray_HTTPSConnectionResponse);

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 200", 8, 11) != -1)
				{				
					return;
				}

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 407", 8, 11) != -1)
				{				
					throw new AuthenticationFailureException();
				}
			}
	
		
			/// <summary> 
			/// Connect input TcpClient object to selected Server through HTTPS Proxy Server with Basic authentication method. 
			/// </summary>
			/// 
			/// <param name="tcpClient_Link">  
			/// Reference to TcpClient object, which will be connected to the selected Host through necessary HTTPS Proxy Server.
			/// </param> 
			/// 	
			/// <param name="string_DstHost">
			/// Parameter string_DstHost are used for the indication of Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 		
			/// <param name="int_DstPort">
			/// Parameter int_DstPort are used for the indication of Port of the Host address to which one should connect through HTTPS Proxy Server.
			/// </param>
			/// 
			/// <param name="string_ProxyHost">
			/// Parameter string_ProxyHost are used for the indication of HTTPS Proxy Server Host address.
			/// </param>
			/// 
			/// <param name="int_ProxyPort">
			/// Parameter int_DstPort are used for the indication of Port of HTTPS Proxy Server Host to which one should connect.
			/// </param>
			/// 
			/// <param name="string_UserName">
			/// Parameter string_UserName are indicate User Name used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="string_Password">
			/// Parameter string_Password are indicate Password used for the Basic authorization to connect to necessary Proxy Server.
			/// </param>
			/// 
			/// <param name="bool_UseProxyToResolveHostnames">
			/// Parameter bool_UseProxyToResolveHostnames are used for the indication of domain name resolve mode: Resolve name to IP address by client or send domain address to Proxy Server to resolve.
			/// </param>
			/// 
			/// <param name="int_TimeOutMS">
			/// Parameter int_TimeOutMS are used for the indication that how many time the client must wait for response to any sent request.
			/// </param>
			/// 
			/// <example> This sample shows how to connect Socket to neccessary Server through HTTPS Proxy Server version 4 
			/// <code>
			/// 
			/// TcpClient tcpClient_Link = new TcpClient();
			/// 
			/// JurikSoft.Proxy.ProxyProvider ProxyProvider_obj = new JurikSoft.Proxy.ProxyProvider();
			/// 
			/// try
			/// {
			///		ProxyProvider_obj.ConnectThroughHTTPSProxy(ref tcpClient_Link, “10.0.0.1”, 80,  “10.0.0.5”, 1080, "testLogin", "testPass", false, 10000);
			///	}
			///	catch(JurikSoft.Proxy.Exceptions.ProxyProviderException exception)
			///	{
			///		MessageBox.Show(exception.Message);
			///		return;
			///	}
			/// </code>
			/// </example>
			/// 
			public void ConnectThroughHTTPSProxy(ref TcpClient tcpClient_Link, string string_DstHost, int int_DstPort,  string string_ProxyHost, int int_ProxyPort, string string_UserName, string string_Password,  bool bool_UseProxyToResolveHostnames, int int_TimeOutMS)
			{
				CheckSN();

				byte [] byteArray_HTTPSConnectionResponse = null, byteArray_HTTPSConnectionRequest = null, byteArray_HTTPSAuthData = null;

				string string_HTTPSConnectionResponse, string_HTTPSConnectionRequest, string_Base64HTTPSAuthData;


				IPAddress ipAddress_Host;
				IPEndPoint ipEndPoint_ProxyAddress;
		

				if(bool_UseProxyToResolveHostnames == true)
					try
					{
						ipAddress_Host = IPAddress.Parse(string_DstHost);
						string_DstHost = ipAddress_Host.ToString();
					}
					catch(FormatException exception)
					{
						try
						{
							ipAddress_Host = Dns.Resolve(string_DstHost).AddressList[0];
							string_DstHost = ipAddress_Host.ToString();
						}
						catch(SocketException exception_Socket)
						{							
							throw new UnableToResolveHostName();
						}
					}


						
				string_HTTPSConnectionRequest = "CONNECT " + string_DstHost.ToString() + ":" + int_DstPort.ToString() + 
					" HTTP/1.0\n" + "Proxy-Authorization: Basic ";

				byteArray_HTTPSAuthData = System.Text.Encoding.ASCII.GetBytes(string_UserName + ":" + string_Password);

				string_Base64HTTPSAuthData = System.Convert.ToBase64String(byteArray_HTTPSAuthData, 0, byteArray_HTTPSAuthData.Length);
 
				string_HTTPSConnectionRequest += string_Base64HTTPSAuthData + "\n\n";
	
				byteArray_HTTPSConnectionRequest = System.Text.Encoding.ASCII.GetBytes(string_HTTPSConnectionRequest);
					



				MemoryStream memoryStream_ReceivedData = new MemoryStream();

				if(int_DstPort > IPEndPoint.MaxPort || int_DstPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("DstPort", "Specified argument was out of the range of valid values.");
				}
				
				if(int_ProxyPort > IPEndPoint.MaxPort || int_ProxyPort < IPEndPoint.MinPort )
				{
					throw new ArgumentOutOfRangeException("ProxyPort", "Specified argument was out of the range of valid values.");
				}


				try
				{
					ipAddress_Host = IPAddress.Parse(string_ProxyHost);
					ipEndPoint_ProxyAddress = new IPEndPoint(ipAddress_Host, int_ProxyPort);
				}
				catch(FormatException exception)
				{	
					try
					{
						ipEndPoint_ProxyAddress = new IPEndPoint(Dns.Resolve(string_ProxyHost).AddressList[0], int_ProxyPort);
					}
					catch(SocketException exception_Socket)
					{							
						throw new UnableToResolveHostName();
					}
				}			

				if(tcpClient_Link == null) tcpClient_Link = new TcpClient();


				try
				{
					tcpClient_LinkToCloseByTimeOut = tcpClient_Link;
					int_GlobalTimeOutMS = int_TimeOutMS;

					Thread thread_ConnectionTimeOutWatcher = new Thread(new ThreadStart(ConnectionTimeOutWatcher));
				
					thread_ConnectionTimeOutWatcher.Start();

					tcpClient_Link.Connect(ipEndPoint_ProxyAddress);

					thread_ConnectionTimeOutWatcher.Abort();
				}

				catch(Exception exception)
				{
					tcpClient_Link.Close();
				
					throw new ProxyConnectionException();
				}
	
				NetworkStream networkStream_Link = tcpClient_Link.GetStream();
			
				if(SendingHTTPSConnectionRequest != null) SendingHTTPSConnectionRequest();

				if(SendingHTTPSAuthenticationRequest != null) SendingHTTPSAuthenticationRequest();

				networkStream_Link.Write(byteArray_HTTPSConnectionRequest, 0, byteArray_HTTPSConnectionRequest.Length);
			
				if(WaitingForReplyToHTTPSConnectionRequest != null) WaitingForReplyToHTTPSConnectionRequest();

				if(WaitingForReplyToHTTPSAuthenticationRequest != null) WaitingForReplyToHTTPSAuthenticationRequest();
			
				int int_InternalTimeOutCount = 0;			
				while(!networkStream_Link.DataAvailable && int_InternalTimeOutCount <= int_TimeOutMS)
				{					
					Thread.Sleep(10);
					int_InternalTimeOutCount += 10;
				}

				if(!networkStream_Link.DataAvailable)
				{
					networkStream_Link.Close();
				
					tcpClient_Link.Close();

					throw new TimeOutException();
				}
				else 
				{			
					while(networkStream_Link.DataAvailable)
					{
						memoryStream_ReceivedData.WriteByte((byte)networkStream_Link.ReadByte());			
					}
				
					byteArray_HTTPSConnectionResponse = memoryStream_ReceivedData.ToArray();				
				}

				string_HTTPSConnectionResponse = System.Text.Encoding.ASCII.GetString(byteArray_HTTPSConnectionResponse);

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 200", 8, 11) != -1)
				{
					return;
				}		

				if(string_HTTPSConnectionResponse.Length > 34
					&& string_HTTPSConnectionResponse.IndexOf(" 407", 8, 11) != -1)
				{				
					throw new AuthenticationFailureException();
				}
		
			}	

		}
	}
}

