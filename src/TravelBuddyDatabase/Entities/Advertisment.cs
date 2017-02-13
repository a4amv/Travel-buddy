using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBuddyDatabase.Entities
{
    public class Advertisment
    {
        public virtual string Location { get; set; }
        public virtual decimal GpsLatitude { get; set; }
        public virtual decimal GpsLongitude { get; set; }
        public virtual DateTime Since { get; set; }
        public virtual DateTime Until { get; set; }
        public virtual string Details { get; set; }
    }
}
