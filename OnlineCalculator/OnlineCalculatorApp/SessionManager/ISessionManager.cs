using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The SessionManager interface
    /// </summary>
    public interface ISessionManager
    {
        /// <summary>
        /// Update user session
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sessionData"></param>
        public void UpdateSessionData(string userId, CalculatorMemory sessionData);

        /// <summary>
        /// Get CalculatorMemory from user session.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>CalculatorMemory object</returns>
        public CalculatorMemory GetSessionData(string userId);
    }
}
