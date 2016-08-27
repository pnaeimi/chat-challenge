using SimpleChatAPI.Models;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SimpleChatAPI.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private AppContext appContext = null;
        private bool disposed = false;

        public MessageRepository()
        {
            appContext = new AppContext();
        }

        public MessageRepository(AppContext appContext)
        {
            this.appContext = appContext; 
        }
        
     
        public IEnumerable<Message> GetMessages(int chatId)
        { 
            return appContext.Messages.Where(m => m.ChatId == chatId).ToList();
        }

        public void Create(int chatId, Message message)
        {
            message.ChatId = chatId;
            message.Created = DateTime.Now;
            appContext.Messages.Add(message);
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