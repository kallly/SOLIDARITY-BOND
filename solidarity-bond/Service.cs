using System;
using System.Net;  
using System.Net.Sockets;  
using System.Text;  
using System.Threading;
using Newtonsoft.Json;

namespace solidarity_bond
{

    public class StateObject {  
    public Socket workSocket = null;  
    public const int BufferSize = 1024;  
    public byte[] buffer = new byte[BufferSize];  
    public StringBuilder sb = new StringBuilder();
    }
    

    class Service
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);  

        private ConnectionComptoir connectionComptoir;
        private StockComptoir stockComptoir;
        private ReservationComptoir reservationComptoir;

        public Service()
        {
            
        }

        private STR_MSG Operation(STR_MSG str_msg)
        {
            str_msg.data["error"] = string.Empty;
            str_msg.data["success"] = "The connection operation has been authorized.";

            
            switch (str_msg.data["operation"])
            {
                case "connection":
                    if (connectionComptoir == null) connectionComptoir = new ConnectionComptoir();
                    str_msg = connectionComptoir.Connection(str_msg);
                    break;
                case "get_stock":
                    if (connectionComptoir == null) stockComptoir = new StockComptoir();
                    str_msg = stockComptoir.Get_stock(str_msg);
                    break;
                case "update_stock":
                    if (connectionComptoir == null) stockComptoir = new StockComptoir();
                    str_msg = stockComptoir.Update_stock(str_msg);
                    break;
                case "get_reservations":
                    if (connectionComptoir == null) reservationComptoir = new ReservationComptoir();
                    str_msg = reservationComptoir.Get_reservations(str_msg);
                    break;
                case "get_reservations_by_user":
                    if (connectionComptoir == null) reservationComptoir = new ReservationComptoir();
                    str_msg = reservationComptoir.Get_reservations_by_user(str_msg);
                    break;
                case "add_reservation":
                    if (connectionComptoir == null) reservationComptoir = new ReservationComptoir();
                    str_msg = reservationComptoir.Add_reservation(str_msg);
                    break;
                default:
                    str_msg.data["success"] = string.Empty;
                    // unknown or not alloed op
                    str_msg.data["error"] = str_msg.data["operation"] + " operation is not allowed for " + str_msg.application + " application.";
                    break;
            }

            return str_msg;
        }

        public void StartListening() { 
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());  
        IPAddress ipAddress = ipHostInfo.AddressList[0];  
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);  
        Console.WriteLine(ipAddress);
        // Create a TCP/IP socket.  
        Socket listener = new Socket(ipAddress.AddressFamily,  
            SocketType.Stream, ProtocolType.Tcp );  
  
        // Bind the socket to the local endpoint and listen for incoming connections.  
        try {  
            listener.Bind(localEndPoint);  
            listener.Listen(100);  
  
            while (true) {  
                // Set the event to nonsignaled state.  
                allDone.Reset();  
  
                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");  
                listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),  
                    listener );  
  
                // Wait until a connection is made before continuing.  
                allDone.WaitOne();  
            }  
  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }
  
    }  
        public void AcceptCallback(IAsyncResult ar) {  
        // Signal the main thread to continue.  
        allDone.Set();  
  
        // Get the socket that handles the client request.  
        Socket listener = (Socket) ar.AsyncState;  
        Socket handler = listener.EndAccept(ar);  
  
        // Create the state object.  
        StateObject state = new StateObject();  
        state.workSocket = handler;  
        handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,  
            new AsyncCallback(ReadCallback), state);  
    }  
  
        public void ReadCallback(IAsyncResult ar) {  
        String content = String.Empty;  
  
        // Retrieve the state object and the handler socket  
        // from the asynchronous state object.  
        StateObject state = (StateObject) ar.AsyncState;  
        Socket handler = state.workSocket;  
  
        // Read data from the client socket.
        int bytesRead = handler.EndReceive(ar);  
  
        if (bytesRead > 0) {  
            // There  might be more data, so store the data received so far.  
            state.sb.Append(Encoding.ASCII.GetString(  
                state.buffer, 0, bytesRead));  
  
            // Check for end-of-file tag. If it is not there, read
            // more data.  
            content = state.sb.ToString();  
            if (content.IndexOf("<EOF>") > -1) {  
                // All the data has been read from the
                // client. Display it on the console.  
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",  
                    content.Length, content );  
                // Echo the data back to the client.  

                STR_MSG result = new STR_MSG();
                try{
                    
                    result = (STR_MSG)JsonConvert.DeserializeObject<STR_MSG>(content.Substring(0,content.Length-6));
                }catch(Exception e){
                    Console.WriteLine(e);
                }
                
                result = Operation(result);

                String resultJSON = "";
                try{
                    
                    resultJSON = JsonConvert.SerializeObject(result);
                }catch(Exception e){
                    Console.WriteLine(e);
                }
            
                Send(handler, resultJSON);

            } else {  
                // Not all data received. Get more.  
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,  
                new AsyncCallback(ReadCallback), state);  
            }  
        } 
    }

        private static void Send(Socket handler, String data) {  
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);  
  
        // Begin sending the data to the remote device.  
        handler.BeginSend(byteData, 0, byteData.Length, 0,  
            new AsyncCallback(SendCallback), handler);  
    }  
  
        private static void SendCallback(IAsyncResult ar) {  
        try {  
            // Retrieve the socket from the state object.  
            Socket handler = (Socket) ar.AsyncState;  
  
            // Complete sending the data to the remote device.  
            int bytesSent = handler.EndSend(ar);  
            Console.WriteLine("Sent {0} bytes to client.", bytesSent);  
  
            handler.Shutdown(SocketShutdown.Both);  
            handler.Close();  
  
        } catch (Exception e) {  
            Console.WriteLine(e.ToString());  
        }  
    }  

    }
}