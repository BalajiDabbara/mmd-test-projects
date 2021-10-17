using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public interface ISessionManager
    {
        public void UpdateSessionData(string userId, CalculatorMemory sessionData);

        public CalculatorMemory GetSessionData(string userId);
    }
}
