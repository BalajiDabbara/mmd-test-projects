using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public class UserContext : IUserContext
    {
        public string UserName { get; set; }
        public string SessionId { get; set; }

        public UserContext(string userName, string sessionId)
        {
            this.UserName = userName;
            this.SessionId = sessionId;
        }
    }
}
