using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPConfigValues.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ASPConfigValues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppParametersController : ControllerBase
    {
        private ApplicationParameters applicationParameters;
        private ApplicationParameters applicationParametersSnapshot;
        public AppParametersController(IOptions<ApplicationParameters> options, IOptionsSnapshot<ApplicationParameters> optionsSnap)
        {
            applicationParameters = options.Value;
            applicationParametersSnapshot = optionsSnap.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            StringBuilder response = new StringBuilder();
            response.AppendLine("IOptions ==>");
            response.AppendLine(JsonConvert.SerializeObject(applicationParameters));
            response.AppendLine("");
            response.AppendLine("IOptionsSnapshot ==>");
            response.AppendLine(JsonConvert.SerializeObject(applicationParametersSnapshot));
            return Content(response.ToString());
        }
    }
}