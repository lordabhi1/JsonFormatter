using ExceptionHandling.Domain.DomainException;

namespace JsonFormatterProject.Services
{
    public class JsonFormatter : IJsonFormatter
    {
        public string formatJson(string json)
        {
            
            if (json != null)
            {
                return json;
            }
            else
                throw new NotFoundException("data is null");
        }

        public int greet()
        {
            return 1;
        }
    }
}
