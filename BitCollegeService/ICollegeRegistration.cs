using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BitCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// Uses LINQ-SQL to retrieve the Registration record from the database which corresponds to the method argument
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns>returns false if fails, otherwise returns true</returns>
        [OperationContract]
        bool dropCourse(int registrationId);

        /// <summary>
        /// Validates and adds a course to a Students record
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="notes"></param>
        /// <returns>0 if successful, -100, -200, or -300 if errors were encounterd</returns>
        [OperationContract]
        int registerCourse(int studentId, int courseId, string notes);

        /// <summary>
        /// Updates the grade of the course for the student
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="registrationId"></param>
        /// <param name="notes"></param>
        [OperationContract]
        void upgradeGrade(double grade, int registrationId, string notes);
    }
}
