using SimpleChatAPI.Models;
using SimpleChatAPI.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace SimpleChatAPI.Repository
{
 public class UserRepository : IUserRepository
    {

        private AppContext appContext = null;
        private bool disposed = false;

        public UserRepository()
        {
            appContext = new AppContext();        
        }

        public UserRepository(AppContext appContext)
        {
            this.appContext = appContext;
        }
        
        public IEnumerable<User> GetUsers()
        {
            return appContext.CUsers.ToList();
        }

        public User Get(int id)
        {
            return appContext.CUsers.Find(id);
        }

        public bool GetByEmail(string emailAddress)
        {
            return appContext.CUsers.Any(u => u.EmailAddress == emailAddress);
        }
   
        public void Add(User user)
        {
            appContext.CUsers.Add(user);
        }

        public void Delete(int id)
        {
            User user = appContext.CUsers.Find(id);
            appContext.CUsers.Remove(user);
        }

        public void Update(User user)
        {
            appContext.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            appContext.SaveChanges();
        }

        public User Authenticate(User user)
        {

            return appContext.CUsers.Where(u => u.EmailAddress == user.EmailAddress && 
                                               u.Password == user.Password)
                                    .FirstOrDefault();
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