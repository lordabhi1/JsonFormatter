using JsonFormatterProject.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace JsonFormatterProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JsonFormatterController : Controller
    {
        private readonly IJsonFormatter jsonFormatter;


        public JsonFormatterController(IJsonFormatter jsonFormatter)
        {
            this.jsonFormatter = jsonFormatter;
        }


        [HttpPost]
        public IActionResult Index(string data)
        {
            var result = jsonFormatter.formatJson(data);

            //string output=JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);

            string output = JToken.Parse(result).ToString();

            //string output = JsonConvert.SerializeObject(tbl, Newtonsoft.Json.Formatting.Indented);
            return Ok(output);
        }
    }
}
