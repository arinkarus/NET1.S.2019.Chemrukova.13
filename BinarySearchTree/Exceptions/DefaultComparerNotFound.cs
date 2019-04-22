using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Exceptions
{
    public class DefaultComparerNotFound : Exception
    {
        public DefaultComparerNotFound()
        {
        }

        public DefaultComparerNotFound(string message) : base(message)
        {
        }

        public DefaultComparerNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DefaultComparerNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
