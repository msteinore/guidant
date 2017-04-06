using System;
using System.Collections.Generic;

namespace Guidant1.Models
{
    public class UserModel
    {
        /// <summary>
        /// static list that represents all Users
        /// </summary>
        public static List<User> Users { get; set; }

        public UserModel()
        {
            Users = new List<User>();
        }

        public class User
        {
            /// <summary>
            /// Name is considered the unique Id for a user.
            /// Name is assumed case sensitive, so the same name with different case is unique.
            /// </summary>
            public string Name { get; set; }
            public int Points { get; set; }
        }
    }
}