using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculator
{
    public interface IUserContext
    {
        public string UserName { get; set; }
        public string SessionId { get; set; }

    }
}
