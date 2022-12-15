namespace ExceptionHandling.Domain.DomainException
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }

    public class NotFoundException : DomainException
    {
        public NotFoundException(string message) : base(message) 
        {

        }
    }
}