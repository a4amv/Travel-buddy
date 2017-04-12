using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBuddyDatabase.Entities
{
    public class Messages
    {
        public virtual int Id { get; set; }
        public virtual string SentFrom { get; set; }
        public virtual string SentTo { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual string ThisMessage { get; set; }
        public virtual DateTime MessageTime { get; set; }
    }
}
