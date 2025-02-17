using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class RailwaysException : Exception
    {
      
        public RailwaysException(string message) : base(message)
        {
        }
        public RailwaysException(string message,  Exception innerExeption) : base(message,innerExeption)
        {
          
        }
    }
}
