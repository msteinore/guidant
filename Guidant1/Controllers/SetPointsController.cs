using System.Linq;
using Guidant1.Models;
using System.Web.Http;

namespace Guidant1.Controllers
{
    public class SetPointsController : ApiController
    {
        // POST: api/Setpoints
        // Accepts Json User object
        // If well-formed, and name is in list, update points for user, otherwise return error message.
        [HttpPost]
        public IHttpActionResult SetPoints([FromBody] UserModel.User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                return Json("Error: malformed user object");
            }

            var foundUser = UserModel.Users.FirstOrDefault((u) => string.Compare(u.Name, user.Name, false) == 0);
            if (foundUser != null)
            {
                foundUser.Points = user.Points;
                return Ok("user '" + user.Name + "' points updated.");
            }

            return Json("user '" + user.Name + "' points not updated.");
        }
    }
}
