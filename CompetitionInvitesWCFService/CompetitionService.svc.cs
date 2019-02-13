using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompetitionInvitesWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompetitionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CompetitionService.svc or CompetitionService.svc.cs at the Solution Explorer and start debugging.
    public class CompetitionService : ICompetitionService
    {
        private StudentCompetitionDBEntities entities = new StudentCompetitionDBEntities();

        public List<Student> findStudentId(int id)
        {
            return entities.Students.Where(s => s.StudentId == id).ToList();
        }

        public List<Student> findAllStudent()
        {
            return entities.Students.ToList();
        }

        public List<Attend> findAttendId(int id)
        {
            return entities.Attends.Where(a => a.Student == id).ToList();
        }

        public List<Attend> findAllAttend()
        {
            return entities.Attends.ToList();
        }

        public void InsertIntoDB(Student student, Attend attend)
        {
            entities.Students.Add(student);
            entities.Attends.Add(attend);
            entities.SaveChanges();
        }
    }
}
