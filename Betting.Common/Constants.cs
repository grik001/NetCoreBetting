using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Common
{
    public static class Constants
    {
        public enum CacheKey
        {
            GameList,
            ClientList
        }

        public enum SocketMessageType
        {
            SingleGame
        }
    }
}
