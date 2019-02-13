using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionInvitesWCF.Models
{
    /// <summary>
    /// Options for technical interest
    /// </summary>
    public enum TechnicalInterestEnum
    {
        IoT,
        MotionSensors,
        DataAnalytics,
        Programming
    }

    /// <summary>
    /// Class to hold all the variables in the students response. 
    /// 'Will Attend' is set when the student responds using the submit buttons
    /// </summary>
    public class StudentResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your perferred social network")]
        public string SocialNetworkInterest { get; set; }
        public TechnicalInterestEnum TechnicalInterest { get; set; }
        public bool? WillAttend { get; set; }
    }
}