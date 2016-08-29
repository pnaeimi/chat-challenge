using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleChatAPI.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public int Direction { get; set; }

        public DateTime Created { get; set; }

        public int ChatId { get; set; }

        public virtual Chat Chat { get; set; }
    }
}