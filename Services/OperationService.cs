using ioc_container.Interfaces;

namespace ioc_container.Services
{
    public class OperationService
    {
        public ITransientOperation TransientOperation {get; private set;}
        public IScopedOperation ScopedOperation {get; private set;} 
        public ISingletonOperation SingletonOperation {get; private set;}
        public ISingletonInstanceOperation SingletonInstanceOperation {get; private set;}
        public Guid Id {get; private set;}

        public OperationService(
            ITransientOperation transientOperation,
            IScopedOperation scopedOperation,
            ISingletonOperation singletonOperation,
            ISingletonInstanceOperation singletonInstanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = singletonInstanceOperation;
            Id = Guid.NewGuid();
        }
    }
}