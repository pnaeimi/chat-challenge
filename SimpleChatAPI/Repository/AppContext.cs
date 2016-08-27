using SimpleChatAPI.Models;
using System.Data.Entity;

namespace SimpleChatAPI.Repository
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}