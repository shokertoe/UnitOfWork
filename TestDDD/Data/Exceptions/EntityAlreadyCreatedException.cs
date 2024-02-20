using System.Runtime.Serialization;

namespace TestDDD.Data.Exceptions
{
    public class EntityAlreadyCreatedException : Exception
    {
        public EntityAlreadyCreatedException()
        {
        }
    }
}
