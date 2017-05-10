using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Services.Interfaces;
using EFCore.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = userService.GetAll();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No users where found");
            }

            
        }

        [HttpPost]
        public IActionResult Post([FromBody]tb_User user)
        {
            if (user == null)
                return BadRequest($"User object is null");

            user.usr_Guid = Guid.NewGuid();
            userService.Add(user);

            return Ok();
        }
    }
}
