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
        private IWebSocketHandler _notificationsMessageHandler { get; set; }

        public SocketPushHelper(IWebSocketHandler notificationsMessageHandler)
        {
            this._notificationsMessageHandler = notificationsMessageHandler;
        }

        public async Task SendMessageToAll<T>(SocketMessageType type, T data)
        {
            var message = new { type = type.ToString(), data = data };
            var json = JsonConvert.SerializeObject(message);
            await _notificationsMessageHandler.SendMessageToAllAsync(json);

        }

        public async Task SendMessageToSingle<T>(SocketMessageType type, string id, T data)
        {
            var message = new { type = type.ToString(), data = data };
            var json = JsonConvert.SerializeObject(message);
            await _notificationsMessageHandler.SendMessageAsync(id, json);
        }
    }
}
