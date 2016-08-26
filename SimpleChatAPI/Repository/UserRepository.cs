using SimpleChatAPI.Models;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleChatAPI.Repository
{
 public class UserRepository : IUserRepository
    {

        private ChatContext chatContext = null;
        private bool disposed = false;

        public UserRepository()
        {
            chatContext = new ChatContext();        
        }

        public UserRepository(ChatContext chatContext)
        {
            this.chatContext = chatContext;
        }
        
        public IEnumerable<User> GetUsers()
        {
            return chatContext.Users.ToList();
        }

        public User Get(int id)
        {
            return chatContext.Users.Find(id);
        }
       
        public void Add(User user)
        {
            chatContext.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = chatContext.Users.Find(id);
            chatContext.Users.Remove(user);
        }

        public void Update(User user)
        {
            chatContext.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            chatContext.SaveChanges();
        }

        public User Authenticate(User user)
        {
            return chatContext.Users.Where(u => u.EmailAddress == user.EmailAddress && 
                                                u.Password == user.Password)
                                    .FirstOrDefault();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    chatContext.Dispose();
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