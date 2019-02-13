using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionInvitesWCF.Models
{
    public class Repository
    {
        //create new list of responses
        private static List<StudentResponse> responses = new List<StudentResponse>();

        public static IEnumerable<StudentResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        /// <summary>
        /// Method to append responses to the list
        /// </summary>
        /// <param name="response"></param>
        public static void AddResponse(StudentResponse response)
        {
            responses.Add(response);
        }
    }
}