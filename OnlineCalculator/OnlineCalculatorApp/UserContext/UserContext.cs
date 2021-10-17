using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The UserContext class
    /// </summary>
    public class UserContext : IUserContext
    {
        /// <summary>
        /// The user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The session id
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// UserContext object
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="sessionId"></param>
        public UserContext(string userName, string sessionId)
        {
            this.UserName = userName;
            this.SessionId = sessionId;
        }
    }
}
