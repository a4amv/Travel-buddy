using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.ComponentModel.DataAnnotations;

namespace TravelBuddy.Models.Messages
{
    public class MessagesViewModel
    {
        //public IList<User> Users { get; set; }
        public int Id { get; set; }

        public string SentFrom { get; set; }

        public string SentTo { get; set; }

        public bool IsRead { get; set; }

        public string ThisMessage { get; set; }

        [DataType(DataType.Date)]
        public DateTime MessageTime { get; set; }

    }
}
