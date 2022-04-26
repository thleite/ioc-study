using ioc_container.Interfaces;

namespace ioc_container.Services
{
    public class Operation : ITransientOperation, IScopedOperation, ISingletonOperation, ISingletonInstanceOperation
    {
        public Operation() : this(Guid.NewGuid())
        {}
            
        public Operation(Guid id)
        {
            Id = id;
        }
        public Guid Id {get; private set;}
    }
}