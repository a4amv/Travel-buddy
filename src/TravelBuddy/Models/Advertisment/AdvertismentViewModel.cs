using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBuddy.Models.Advertisment
{
    public class AdvertismentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Since { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Until { get; set; }

        public string Details { get; set; }

        /// <summary>
        /// User can edit or remove
        /// </summary>
        public bool CanByEditedByUser { get; set; }
    }
}
