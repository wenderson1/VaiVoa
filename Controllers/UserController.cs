using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaiVoa.Data;
using VaiVoa.Models;

namespace VaiVoa.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> GetById([FromServices] DataContext context, int id)
        {
            var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        [HttpGet]
        [Route("{email:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}")]
        public async Task<ActionResult<User>> GetByEmail([FromServices] DataContext context, string email)
        {

            try
            {
                var user = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);

                return user;
            }
            catch
            {
                return BadRequest("This email doesn't exist");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody] User model)
        {


            if (ModelState.IsValid)
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();

                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
