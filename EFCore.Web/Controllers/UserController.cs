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

            tb_File photoFile = new tb_File();
            photoFile.fl_Guid = user.usr_Guid;
            photoFile.fl_Name = "Test Photo";
            photoFile.fl_IsPrimary = true;
            photoFile.fl_Description = "Test Photo";
            photoFile.fl_ftyp_fk = 1;
            photoFile.fl_Path = "http://scontent.cdninstagram.com/t51.2885-19/s150x150/14676616_1190167017693926_8193516699786412032_a.jpg";

            
            userService.Add(user,null);

            return Ok();
        }
    }
}
