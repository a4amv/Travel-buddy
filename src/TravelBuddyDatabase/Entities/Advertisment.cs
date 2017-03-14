using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBuddyDatabase.Entities
{
    public class Advertisment
    {
        public virtual int Id { get; set; }
        public virtual string Location { get; set; }
        public virtual DateTime Since { get; set; }
        public virtual DateTime Until { get; set; }
        public virtual string Details { get; set; }
    }
}
