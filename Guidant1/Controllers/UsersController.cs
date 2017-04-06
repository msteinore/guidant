using System;
using System.Collections.Generic;
using System.Linq;
using Guidant1.Models;
using System.Web.Http;

namespace Guidant1.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {

        // GET: api/Users
        // Return an array of json objects representing all users
        public IEnumerable<UserModel.User> Get()
        {
            return UserModel.Users.ToArray();
        }

        // GET: api/Users/name
        // Return json object of user with case-sensitive name match or reasonable error message
        public IHttpActionResult Get(string id)
        {
            var user = UserModel.Users.FirstOrDefault((u) => string.Compare(u.Name, id, false) == 0);
            if (user == null)
            {
                return Json("user '" + id + "' not found");
            }

            return Ok(user);
        }


        // POST: api/Users
        // Accepts Json User object
        // If well-formed, and unique name, add to users list and return name, otherwise return error message.
        [HttpPost]
        public IHttpActionResult Post([FromBody] UserModel.User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                return Json("Error: malformed user object");
            }

            var foundUser = UserModel.Users.FirstOrDefault((u) => string.Compare(u.Name, user.Name, false) == 0);
            if (foundUser == null)
            {
                UserModel.Users.Add(new UserModel.User { Name = user.Name, Points = user.Points });
                return Ok(" user '" + user.Name + "' saved.");
            }

            return Json("user '" + user.Name + "' not saved.");
        }
    }
}
