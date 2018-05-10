using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Student
    {
        private static List<Student> studentList;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidName { get; set; }

        public static List<Student> getStudentList()
        {
            if (studentList == null)
            {
                studentList = new List<Student>();
                return studentList;
            }
            else return studentList;
        }
        public static Student addStudent(Student std)
        {
            if (studentList.Count == 0) std.ID = 1;
            else
            {
                std.ID = studentList[studentList.Count - 1].ID + 1;
            }
            if (std.FirstName == "" || std.FirstName == null) return null;
            studentList.Add(std);
            return std;
        }
        public static bool DeleteStudent(int id)
        {
            Student itemToRemove = studentList.Single(r => r.ID == id);
            if(itemToRemove != null) {
                studentList.Remove(itemToRemove);
                return true;
            }
            return false;
        }

        public static Student Get(int id)
        {
            return studentList.Single(r => r.ID == id); ;
        }

    }
}
