using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompetitionInvitesWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICompetitionService" in both code and config file together.
    [ServiceContract]
    public interface ICompetitionService
    {
        [OperationContract]
        List<Student> findAllStudent();

        [OperationContract]
        List<Student> findStudentId(int id);

        [OperationContract]
        List<Attend> findAllAttend();

        [OperationContract]
        List<Attend> findAttendId(int id);

        [OperationContract]
        void InsertIntoDB(Student student, Attend attend);
    }
}
