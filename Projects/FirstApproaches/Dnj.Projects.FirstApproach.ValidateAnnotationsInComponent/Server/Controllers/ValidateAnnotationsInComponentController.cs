using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Dnj.Projects.FirstApproach.ValidateAnnotationsInComponent.Server.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class ValidateAnnotationsInComponentController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Post(JsonElement obj)
        {
            Client.Pages.ValidateAnnotationsInComponent obj2 = JsonSerializer.Deserialize<Client.Pages.ValidateAnnotationsInComponent>(obj.GetString());
            bool testValidate = TryValidateModel(obj2, nameof(obj2));
            
            if (testValidate)
            {
                return Ok(testValidate);
            }
            return BadRequest($"Validation error for class {nameof(obj2)}");

 
        }

    }
}
