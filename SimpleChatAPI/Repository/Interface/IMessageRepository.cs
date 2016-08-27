using SimpleChatAPI.Models;
using System;
using System.Collections.Generic;

namespace SimpleChatAPI.Repository.Interface
{
    public interface IMessageRepository : IDisposable
    {
        IEnumerable<Message> GetMessages(int chatId);
        void Create(int chatId, Message message);
        void Save();
    }
}