using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMKYRS.Models
{
    public class DataModels
    {
        public class Group
        {
            public int GroupId { get; set; }
            public string GroupNum { get; set; }  
        }
        public class GroupStudent
        {
            public int GroupId { get; set; }
            public string Login { get; set; }
            
        }
        public class GroupTask
        {
            public int GroupId  { get; set; }
            public int TaskId  { get; set; }
            public DateTime Date   { get; set; }

        }
        public class Speciality
        {
            public int SpecialityId { get; set; }
            public string Title { get; set; }
            
        }
        public class TaskS
        {
            public string Title { get; set; }
            public string About { get; set; }
            public string Speciality { get; set; }
        }
        public class Students
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string FamalyName { get; set; }
            public int GroupId  { get; set; }
            public string Login { get; set; }
        
        }
        public class Task
        {
            public int TaskID { get; set; }
            public string Title { get; set; }
            public string About { get; set; }
            public int SpecialityId { get; set; }

        
        }
        public class Teachers
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string FamalyName { get; set; }
            public int SpecialityID { get; set; }
            public string Login { get; set; }
    
        }
        public class Users
        {
            public string Login { get; set; }
            public string Password { get; set; }
        
        }
        public class StudentAnswer
        {
            public int TaskID { get; set; }
            public string Login { get; set; }
            public string  Answer  { get; set; }
        }
    }
}
