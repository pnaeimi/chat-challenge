using SimpleChatAPI.Models;
using SimpleChatAPI.Repository;
using SimpleChatAPI.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleChatAPI.Controllers
{
    public class MessagesController : ApiController
    {

        private IMessageRepository messageRepository = null;
        private IChatRepository chatRepository = null;
      
        public MessagesController()
        {
            messageRepository = new MessageRepository();
            chatRepository = new ChatRepository();
        }

        public MessagesController(IMessageRepository messageRepository, IChatRepository chatRepository)
        {
            this.messageRepository = messageRepository;
            this.chatRepository = chatRepository;
        }

        // GET api/users/{userId}/chats/{chatId}/messages
        [Route("users/{userId}/chats/{chatId}/messages")]
        [AuthenticateFilter]
        public IEnumerable<Message> Get(int userId, int chatId)
        {
            var chat = chatRepository.GetChat(userId, chatId);
            if (chat == null)
            {
                return Enumerable.Empty<Message>();
            }
            return messageRepository.GetMessages(chatId);
        }

        // POST api/users/{userId}/chats/{chatId}/messages
        [Route("users/{userId}/chats/{chatId}/messages")]
        [AuthenticateFilter]
        public HttpResponseMessage Post(int userId, int chatId, Message message)
        {
            var chat = chatRepository.GetChat(userId, chatId);
            if (chat == null)
            {
                return Request.CreateResponse<Message>(HttpStatusCode.NotFound, message);
            }

            messageRepository.Create(chatId, message);
            messageRepository.Save();
            var response = Request.CreateResponse<Message>(HttpStatusCode.Created, message);

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            messageRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
