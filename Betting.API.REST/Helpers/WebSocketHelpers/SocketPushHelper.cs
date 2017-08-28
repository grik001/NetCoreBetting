using Betting.API.REST.Helpers.WebSocketHelpers.IWebSocketHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Betting.Common.Constants;

namespace Betting.API.REST.Helpers.WebSocketHelpers
{
    public class SocketPushHelper : ISocketPushHelper
    {
        private NotificationsMessageHandler _notificationsMessageHandler { get; set; }

        public SocketPushHelper(NotificationsMessageHandler notificationsMessageHandler)
        {
            this._notificationsMessageHandler = notificationsMessageHandler;
        }

        public async Task SendMessageToAll<T>(SocketMessageType type, T data)
        {
            var message = new { type = type.ToString(), data = data };
            var json = JsonConvert.SerializeObject(message);
            await _notificationsMessageHandler.SendMessageToAllAsync(json);

        }

        public async Task SendMessageToSingle(string id, string message)
        {
            await _notificationsMessageHandler.SendMessageToAllAsync(JsonConvert.SerializeObject(message));
        }
    }
}
