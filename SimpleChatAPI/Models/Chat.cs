using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleChatAPI.Models
{
    public class Chat
    {
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public DateTime Created { get; set; }

        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }

    }
}