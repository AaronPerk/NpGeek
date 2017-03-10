using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Survey
    {
        [Required]
        public string ParkCode { get; set; }
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string EmailAddress { get; set; }
        
        public string State { get; set; }
       
        public string ActivityLevel { get; set; }
        public List<SelectListItem> ParkList { get; set; }

        public static List <string> StateList
        {
            get
            {
                return new List<string>()
                {
                    "AL",
                    "AK",
                    "AZ",
                    "CA",
                    "CO",
                    "CT",
                    "DE",
                    "FL",
                    "GA",
                    "HI",
                    "ID",
                    "IL",
                    "IN",
                    "IA",
                    "KS",
                    "KY",
                    "LA",
                    "ME",
                    "MD",
                    "MA",
                    "MI",
                    "MN",
                    "MS",
                    "MO",
                    "MT",
                    "NE",
                    "NV",
                    "NH",
                    "NJ",
                    "NM",
                    "NY",
                    "NC",
                    "ND",
                    "OH",
                    "OK",
                    "OR",
                    "PA",
                    "RI",
                    "SC",
                    "SD",
                    "TN",
                    "TX",
                    "UT",
                    "VT",
                    "VA",
                    "WA",
                    "WV",
                    "WI",
                    "WY"
                };
                
            }
            
        }
        public static List<string> ActivityLevelList
        {
            get
            {
                return new List<string>()
                {
                   "Inactive",
                   "Sedentary",
                   "Active",
                   "Extremely Active"
                };

            }

        }
    }
}