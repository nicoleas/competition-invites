using CompetitionInvitesWCF.CompetitionService;
using CompetitionInvitesWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompetitionInvitesWCF.Controllers
{
    public class HomeController : Controller
    {

        private CompetitionServiceClient client = new CompetitionServiceClient();
        /// <summary>
        /// Method to retrieve the current date and time and display to the user
        /// </summary>
        /// <returns>MyView type->View</returns>
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            ViewBag.listStudents = client.findAllStudent();
            Student student = new Student();
            return View("MyView");
        }
        [HttpGet]
        public ActionResult RsvpForm()
        {
            return View("RsvpForm");
        }

        /// <summary>
        /// Method to handle the POST request sent from the browser
        /// after the user fills out the form.
        /// </summary>
        /// <param name="studentResponse"></param>
        /// <returns>Thanks type->View</returns>
        [HttpPost]
        public ActionResult RsvpForm(StudentResponse studentResponse)
        {
            int attendId = 3;
            int studentId = 3;

            if (ModelState.IsValid)
            {

                String sender = Request.Form["submit"]; //store retrieved values from form

                //to determine the value of the submit button (Will/Won't Attend)
                switch (sender)
                {
                    case "true": //student will attend party
                        studentResponse.WillAttend = true;
                        break;
                    case "false": // student cannot attend party
                        studentResponse.WillAttend = false;
                        break;
                    default:
                        studentResponse.WillAttend = false;
                        break;
                }

                Repository.AddResponse(studentResponse); //change the student's response

                Student student = new Student();

                student.StudentId = studentId + 1;
                student.Name = studentResponse.Name;
                student.Email = studentResponse.Email;
                student.Phone = studentResponse.Phone;
                student.Address = studentResponse.Address;
                student.TechnicalInterest = studentResponse.TechnicalInterest.ToString();
                student.SocialNetworkInterest = studentResponse.SocialNetworkInterest;

                Attend attend = new Attend();

                attend.Id = attendId + 1;
                attend.Student = student.StudentId;
                switch (studentResponse.WillAttend)
                {
                    case true:
                        attend.AcceptRegret = "Accept";
                        break;
                    case false:
                        attend.AcceptRegret = "Regret";
                        break;
                    default:
                        attend.AcceptRegret = "Regret";
                        break;
                }

                client.InsertIntoDB(student, attend);

                return View("Thanks", studentResponse);

            }
            else
            {
                //there is a validation error
                return View();
            }

        }

        /// <summary>
        /// Method to redirect to the list of responses page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult ListResponse()
        {
            //only returns the students who can make it
            ViewBag.listStudents = client.findAllStudent();
            return View("ListResponse");
        }
        /*
        [HttpGet]
        public ViewResult Search()
        {
            return View();
        }
        */
        [HttpPost]
        public ActionResult Search(String keyword)
        {
            ViewBag.listStudents = client.findStudentId(Convert.ToInt32(keyword));
            return View("ListResponse");
        }
        
    }
}