using SimpleChatAPI.Repository.Interface;
using SimpleChatAPI.Models;
using SimpleChatAPI.Repository;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleChatAPI.Controllers
{
    public class UsersController : ApiController
    {

        private IUserRepository userRepository = null;

        public UsersController()
        {
            userRepository = new UserRepository();
        }

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET api/users
        public IEnumerable<User> Get()
        {
            return userRepository.GetUsers();
        }

        // GET api/users/5
        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        // POST api/users
        public HttpResponseMessage Post(User user)
        {
            //Check for user existence
            if (user.Password.Equals(user.Confirm))
            {
                userRepository.Add(user);
                userRepository.Save();
                var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);

                return response;
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/users/5
        public HttpResponseMessage Put(int id, User user)
        {
            user.Id = id;
            userRepository.Update(user);
            userRepository.Save();
            var response = Request.CreateResponse<User>(HttpStatusCode.OK, user);

            return response;
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
            userRepository.Delete(id);
            userRepository.Save();
        }

        protected override void Dispose(bool disposing)
        {
            userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}