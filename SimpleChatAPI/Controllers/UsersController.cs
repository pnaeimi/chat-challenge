using SimpleChatAPI.Repository.Interface;
using SimpleChatAPI.Models;
using SimpleChatAPI.Repository;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System;

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
        [AuthenticateFilter]
        public IEnumerable<User> Get()
        {
            return userRepository.GetUsers();
        }

        // GET api/users/5
        [AuthenticateFilter]
        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        // POST api/users
        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage Register(User user)
        {
            if(userRepository.CheckByEmail(user.EmailAddress))
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ModelState);

            if (user.Password.Equals(user.Confirm))
            {
                userRepository.Add(user);
                userRepository.Save();
                return Request.CreateResponse<User>(HttpStatusCode.Created, user);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // PUT api/users/5
        [AuthenticateFilter]
        public HttpResponseMessage Put(int id, User user)
        {
            user.Id = id;
            userRepository.Update(user);
            userRepository.Save();
            var response = Request.CreateResponse<User>(HttpStatusCode.OK, user);

            return response;
        }

        // DELETE api/users/5
        [AuthenticateFilter]
        public void Delete(int id)
        {
            userRepository.Delete(id);
            userRepository.Save();
        }
        
        // Login api/users/login
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage Login(User user)
        {
            var existingUser = userRepository.Authenticate(user);
            if (existingUser == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ModelState);

            string token = Guid.NewGuid().ToString();
            existingUser.BearerToken = token;
            userRepository.Update(existingUser);
            userRepository.Save();
            return Request.CreateResponse<User>(HttpStatusCode.Created, existingUser);
        } 

        protected override void Dispose(bool disposing)
        {
            userRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}