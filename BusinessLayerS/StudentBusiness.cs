using DataLayerS;
using DataLayerS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerS
{
    public class StudentBusiness
    {
        readonly StudentRepository studentRepository = new StudentRepository();

        public List<Student> GetStudents()
        {
            return studentRepository.GetAllStudents().Where(student => (student.IsBudget = true && student.StudyYear * 48 < student.PointsESPB)
                || (student.IsBudget = false && student.StudyYear * 37 < student.PointsESPB)).ToList();
        }

        public bool InsertStudent(Student student)
        {
            return studentRepository.InsertStudent(student) != 0;
        }
    }
}
