using SimpleChatAPI.Models;
using System;
using System.Collections.Generic;

namespace SimpleChatAPI.Repository.Interface
{
    public interface IChatRepository : IDisposable
    {
        IEnumerable<Chat> GetChats(int userId);
        void Create(int userId, Chat chat);
        void Save();
    }
}
