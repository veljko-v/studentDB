using DataLayerS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerS
{
    public class StudentRepository
    {
        private string connString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();

            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = "SELECT * FROM StudentS";


                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Student student = new Student();
                    student.Id = dataReader.GetInt32(0);
                    student.StudentName = dataReader.GetString(1);
                    student.IndexNumber = dataReader.GetString(2);
                    student.PointsESPB = dataReader.GetInt32(3);
                    student.StudyYear = dataReader.GetInt32(4);
                    student.AverageMark = dataReader.GetDecimal(5);
                    student.IsBudget = dataReader.GetBoolean(6);
                    studentList.Add(student);
                }
            }
            return studentList;
        }
        public int InsertStudent(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandText = string.Format("INSERT INTO Students VALUES ('{0}', '{1}', '{2}', '{3}','{4}','{5}')",
                    student.StudentName, student.IndexNumber, student.PointsESPB, student.StudyYear, student.AverageMark, student.IsBudget);

                return command.ExecuteNonQuery();
            }
        }
    }
}
