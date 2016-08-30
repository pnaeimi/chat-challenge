using Microsoft.AspNet.Identity.EntityFramework;
using SimpleChatAPI.Models;
using System.Data.Entity;

namespace SimpleChatAPI.Repository
{
    public class AppContext : IdentityDbContext
    {
        public DbSet<User> CUsers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}