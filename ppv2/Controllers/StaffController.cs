using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppv2.Models;
using System;

namespace ppv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet(template:"List")]
        public string ListStaff()
        {
            return "Hello";
        }
    }
}
