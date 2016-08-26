using SimpleChatAPI.Models;
using System.Data.Entity;

namespace SimpleChatAPI.Repository
{
    public class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}