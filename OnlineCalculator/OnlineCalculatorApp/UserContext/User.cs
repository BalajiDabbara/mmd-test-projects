using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCalculatorApp
{
    /// <summary>
    /// The user object
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user name
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The User contructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userId"></param>
        public User(string userName, string userId)
        {
            this.UserName = userName;
        }

    }

}
