using SimpleChatAPI.Models;
using System;
using System.Collections.Generic;

namespace SimpleChatAPI.Repository.Interface
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User Get(int id);
        bool CheckByEmail(string emailAddress);
        bool CheckByToken(string bearerToken);
        void Add(User user);
        void Delete(int id);
        void Update(User user);
        void Save();
        User Authenticate(User user);
    }
}
