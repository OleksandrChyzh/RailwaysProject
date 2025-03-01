using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class EntityNotFoundException : RailwaysException
    {
        public EntityNotFoundException(string entityName, int id)
            : base($"{entityName} with id {id} was not found.")
        {
        }

        public EntityNotFoundException(string entityName, string propertyName, string propertyValue)
            : base($"{entityName} with {propertyName} {propertyValue} was not found.")
        {
        }

    }
}
