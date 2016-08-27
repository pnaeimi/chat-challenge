using SimpleChatAPI.Models;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleChatAPI.Repository
{
    public class ChatRepository : IChatRepository
    {

        private AppContext appContext = null;
        private bool disposed = false;

        public ChatRepository()
        {
            appContext = new AppContext();
        }

        public ChatRepository(AppContext appContext)
        {
            this.appContext = appContext; 
        }

        [Route("users/{userId}/chats")]
        public IEnumerable<Chat> GetChats(int userId)
        {
            return appContext.Chats.Where(c => c.UserIdFrom == userId).ToList();
        }

        [Route("users/{userId}/chats")]
        public void Create(int userId, Chat chat)
        {
            chat.UserIdFrom = userId;
            appContext.Chats.Add(chat);
        }

        public void Save()
        {
            appContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    appContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}