using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APIApplication.Controllers
{
    [ApiController] // This attribute indicates that the class is an API controller, which means it will handle HTTP requests and return responses in a web API context.
    [Route("api/[controller]")] // This attribute defines the route for the controller. The [controller] token will be replaced with the name of the controller, which is "Student" in this case.
    public class StudentController : ControllerBase
    {

    }
}