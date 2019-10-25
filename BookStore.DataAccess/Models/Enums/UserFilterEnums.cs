using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Enums
{
    public partial class Enums
    {
        public class UserFilterEnums
        {
            public enum SortBy
            {
                UserName = 1,
                Email = 2
            }

            public enum SortingDirection
            {
                LowToHigh = 1,
                HighToLow = 2
            }

            public enum UserStatus
            {
                All = 1,
                Active = 2,
                Blocked = 3
            }
        }
    }
}
