using SimpleChatAPI.Models;
using SimpleChatAPI.Repository;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleChatAPI.Controllers
{
    public class ChatsController : ApiController
    {
        private IChatRepository chatRepository = null;

        public ChatsController()
        {
            chatRepository = new ChatRepository();
        }

        public ChatsController(IChatRepository chatRepository)
        {
            this.chatRepository = chatRepository;
        }

        // GET api/users/{userId}/chats
        [Route("users/{userId}/chats")]
        [AuthenticateFilter]
        public IEnumerable<Chat> Get(int userId)
        {
            return chatRepository.GetChats(userId);
        }

        // POST api/users/{userId}/chats
        [Route("users/{userId}/chats")]
        [AuthenticateFilter]
        public HttpResponseMessage Post(int userId, Chat chat)
        {
            chatRepository.Create(userId, chat);
            chat.Created = DateTime.Now;
            chatRepository.Save();
            var response = Request.CreateResponse<Chat>(HttpStatusCode.Created, chat);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            chatRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}