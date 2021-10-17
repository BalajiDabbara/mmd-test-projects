using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    public interface IUserContext
    {
        public string UserName { get; set; }
        public string SessionId { get; set; }

    }
}
