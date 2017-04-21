using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace TravelBuddy.Models.FinderViewModel
{
    public class FinderViewModel
    {
        public string Name { get; set; }
        public string city { get; set; }
        public string tags { get; set; }


    }
}
