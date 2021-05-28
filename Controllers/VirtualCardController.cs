using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using VaiVoa.Data;
using VaiVoa.Models;
using VaiVoa.Services;

namespace VaiVoa.Controllers
{
    [ApiController]
    [Route("v1/virtualcard")]
    public class VirtualCardController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<VirtualCard>>> GetByEmail([FromServices] DataContext context, [FromBody] string email)
        {
            try
            {
                var user = await context.Users
                    .AsNoTracking()
                    .FirstAsync(x => x.Email == email);

                var virtualcard =  context.VirtualCards
                .Include(x => x.User)    
                .Select(x =>
                new
                {
                    Id = x.Id,
                    CardNumber = x.CardNumber,
                    UserId = x.UserId,
                    Email = x.User.Email
                }
                )
                .Where(x => x.UserId == user.Id);

                return Ok(virtualcard);
            }
            catch
            {
                return BadRequest("This email doesn't exist");
            }


        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<VirtualCard>> Post(
           [FromServices] DataContext context,
           [FromBody] string email)
        {
            try
            {
                var user = await context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email == email);

                var virtualCard = new VirtualCard();
                virtualCard.UserId = user.Id;
                context.VirtualCards.Add(virtualCard);
                await context.SaveChangesAsync();

                return Ok(virtualCard);
            }
            catch
            {
                return BadRequest("This email doesn't exist");
            }

        }
    }
}
