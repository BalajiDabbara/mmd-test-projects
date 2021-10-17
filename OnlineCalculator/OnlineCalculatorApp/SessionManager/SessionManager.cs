using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The SessionManager.
    /// </summary>
    class SessionManager : ISessionManager
    {
        private static SessionManager sessionInstance = null;
        private static readonly object padLock = new object();
        private Dictionary<string, CalculatorMemory> UserSessions;
        public static string UserId { get; set; }

        /// <summary>
        /// The constructor.
        /// </summary>
        SessionManager()
        {
            UserSessions = new Dictionary<string, CalculatorMemory>();
        }
        
        /// <summary>
        /// Singleton instance of SessionManager.
        /// </summary>
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

        /// <summary>
        /// Get CalculatorMemory from user session.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>CalculatorMemory object</returns>
        public CalculatorMemory GetSessionData(string userId)
        {
            if (UserSessions.ContainsKey(userId))
                return UserSessions[userId];
            else
                return null;
        }

        /// <summary>
        /// Update user session
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sessionData"></param>
        public void UpdateSessionData(string userId, CalculatorMemory sessionData)
        {
            UserSessions[userId] = sessionData;
        }
    }
}