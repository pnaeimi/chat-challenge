using SimpleChatAPI.Models;
using System;
using System.Collections.Generic;

namespace SimpleChatAPI.Repository.Interface
{
    public interface IChatRepository : IDisposable
    {
        IEnumerable<Chat> GetChats(int userId);
        Chat GetChat(int userId, int chatId);
        void Create(int userId, Chat chat);
        void Save();
    }
}
