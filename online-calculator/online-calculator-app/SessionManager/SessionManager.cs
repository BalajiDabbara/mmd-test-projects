using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    class SessionManager : ISessionManager
    {
        private static SessionManager sessionInstance = null;
        private static readonly object padLock = new object();
        private Dictionary<string, CalculatorMemory> UserSessions;
        public static string UserId { get; set; }

        SessionManager()
        {
            UserSessions = new Dictionary<string, CalculatorMemory>();
        }

        public static SessionManager Instance
        {
            get
            {
                lock (padLock)
                {
                    if (sessionInstance == null)
                    {
                        sessionInstance = new SessionManager();
                    }
                    return sessionInstance;
                }
            }
        }

        public CalculatorMemory GetSessionData(string userId)
        {
            if (UserSessions.ContainsKey(userId))
                return UserSessions[userId];
            else
                return null;
        }

        public void UpdateSessionData(string userId, CalculatorMemory sessionData)
        {
            UserSessions[userId] = sessionData;
        }
    }
}