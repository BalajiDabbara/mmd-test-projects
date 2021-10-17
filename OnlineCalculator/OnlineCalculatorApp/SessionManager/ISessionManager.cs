using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public interface ISessionManager
    {
        public void UpdateSessionData(string userId, CalculatorMemory sessionData);

        public CalculatorMemory GetSessionData(string userId);
    }
}
