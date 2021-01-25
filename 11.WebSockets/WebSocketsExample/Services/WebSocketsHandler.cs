using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocketsExample.Services
{
    public class WebSocketsHandler
    {
        public ConcurrentDictionary<string, WebSocket> websocketConnections = new ConcurrentDictionary<string, WebSocket>();
               

        public async Task HandleAsync(string username, WebSocket webSocket)
        {
            websocketConnections.TryAdd(username, webSocket);

            await SendMessageToSockets($"User with id <b>{username}</b> has joined the chat");

            while (webSocket.State == WebSocketState.Open)
            {
                var message = await ReceiveMessage(username, webSocket);
                if (message != null)
                    await SendMessageToSockets(message);
            }
        }

        private async Task<string> ReceiveMessage(string username, WebSocket webSocket)
        {
            var arraySegment = new ArraySegment<byte>(new byte[4096]);
            var receivedMessage = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);
            if (receivedMessage.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.Default.GetString(arraySegment).TrimEnd('\0');
                if (!string.IsNullOrWhiteSpace(message))
                    return $"<b>{username}</b>: {message}";
            }
            return null;
        }

        private async Task SendMessageToSockets(string message)
        {
            foreach (var connection in websocketConnections.Values)
            {
                var arraySegment = new ArraySegment<byte>(Encoding.Default.GetBytes(message));
                await connection.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
