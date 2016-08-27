using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleChatAPI.Models
{
    public class Chat
    {
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        //TODO: Foreign Key to Users
        public int UserIdFrom { get; set; }

        //TODO: Foreign Key to Users
        public int UserIdTo { get; set; }

        public DateTime Created { get; set; }

    }
}