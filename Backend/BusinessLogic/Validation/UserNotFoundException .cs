using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class UserNotFoundException : RailwaysException
    {
        public UserNotFoundException(string email)
            : base($"Користувача з email '{email}' не знайдено.")
        {
        }
    }
}
