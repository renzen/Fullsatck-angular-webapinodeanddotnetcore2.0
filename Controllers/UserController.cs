
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using contact_app.Models;
//using Microsoft.AspNetCore.Mvc;


namespace contact_app.Controllers
{
    // set route attribute to make request as 'api/User'
  
    public class UserController : Controller
    {
        private readonly ContactAppContext _context;

        // initiate database context
        public UserController(ContactAppContext context)
        {
            _context = context;
        }
        
         // GET api/values
        [HttpGet]
        [Route("Users")]
         public async Task<IActionResult> GetAll()  {  
            // fetch all contact records  
            var userlist = await _context.Users.Include(u => u.UserDetails).ThenInclude(a => a.Address).ThenInclude(g => g.GeoLoc).ToListAsync(); 

            return Ok(userlist);
        }  
       

        // GET api/values/id
        [HttpGet("{id}")]
        [Route("User/{id}")]
      public IActionResult GetById(Int64 id) {  
            // filter contact records by contact id  
            var user = _context.Users.Include(u => u.UserDetails).ThenInclude(a => a.Address).ThenInclude(g => g.GeoLoc).FirstOrDefault(t => t.Id == id);  
            if (user == null) {  
                return NotFound();  
            }  
            return new ObjectResult(user);  
        }  
    
        
        // POST api/values
        [HttpPost]
        [Route("addUser")]
            public async Task<IActionResult> Post([FromBody]Users users)
            {
            if(ModelState.IsValid){

            await _context.AddAsync(users).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            else
            return BadRequest(ModelState);

            //return Ok(users);
            return Ok( new { message= "User successfully added."});
            }



        // PUT api/values/5
        [HttpPut("{id}")]  
        [Route("updateUser/{id}")]  
    public async Task<IActionResult> Update(long id, [FromBody] Users item) {  
            // set bad request if contact data is not provided in body  
            if (item == null || id == 0) {  
                return BadRequest();  
            }  
             
            var details = await _context.Users.Include(u => u.UserDetails).ThenInclude(a => a.Address).ThenInclude(g => g.GeoLoc).SingleOrDefaultAsync(t => t.Id == id);
            
            if (details == null) {  
                return NotFound();  
            }  

            details.UserName = item.UserName; 
            details.Password = item.Password; 
            details.Active = item.Active;
            details.UserDetails.FirstName = item.UserDetails.FirstName; 
            details.UserDetails.LastName = item.UserDetails.LastName;   
            details.UserDetails.Email = item.UserDetails.Email;
            details.UserDetails.Address.Street = item.UserDetails.Address.Street;
            details.UserDetails.Address.Suite = item.UserDetails.Gender; 
            details.UserDetails.Address.City = item.UserDetails.Address.City; 
            details.UserDetails.Address.ZipCode = item.UserDetails.Address.ZipCode; 
            details.UserDetails.Address.GeoLoc.Lat = item.UserDetails.Address.GeoLoc.Lat;
            details.UserDetails.Address.GeoLoc.Lng = item.UserDetails.Address.GeoLoc.Lng;
            details.UserDetails.Birth = item.UserDetails.Birth;  
            details.UserDetails.Phone = item.UserDetails.Phone;  
            details.UserDetails.Website = item.UserDetails.Website; 
            details.UpdatedAt= DateTime.Now; 


            // try
            // { await _context.SaveChangesAsync();
            //     return Ok(new {  
            //     message = "Renzen User Details is updated successfully." 
            // });
            // }
            // catch (Exception ex)
            // {
            //     return NotFound(ex.Message);
            // }           

            if(await _context.SaveChangesAsync()> 0)
            {
                return Ok(new {  
                message = "Hi Renzen User Details is updated successfully." 
            });
            }
            

            return Ok(new {  
                message = "failed." 
            });
            
            // _context.Users.Update(details);  
            // _context.SaveChanges();  

            // return Ok(new {  
            //     message = "User Details is updated successfully." 
            // });  
        }  

         // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("deleteUser/{id}")]
        public IActionResult Delete(long id)
     
        {
            var users = _context.Users.FirstOrDefault(t => t.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            _context.SaveChanges();
            return Ok( new { message= "User is deleted successfully."});
        }

    //     // GET: api/authors/search?namelike=th
    // [HttpGet("Search")]
    // public IActionResult Search(string namelike)
    // {
    //     var result = _authorRepository.GetByNameSubstring(namelike);
    //     if (!result.Any())
    //     {
    //         return NotFound(namelike);
    //     }
    //     return Ok(result);
    // }

        
 }
}