using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMKYRS.Models;
using Dapper;


namespace DMKYRS.Models
{
    static class Repository
    {
        static string connectionString = @"Data Source=DESKTOP-AVCRPLB\SQLEXPRESS;Initial Catalog=ZadKyrs;Integrated Security=True";
        public static void RegisterUSER(string Login,string Password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               db.Execute($"INSERT INTO Users (Login, Password) VALUES ('{Login}', '{Password}')");
            }
        }
        public static void GetAnswer(string Login, string Title,string About,string Answer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"INSERT INTO StudentAnswer (TaskID, Login,Answer) VALUES ({db.Query<DataModels.Task>($"SELECT * FROM Task WHERE Title='{Title}' AND About='{About}'").First().TaskID}, '{Login}','{Answer}')");
            }
        }
        public static List<DataModels.Group> GetGroups(string Login, string Password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               return db.Query<DataModels.Group>($"SELECT * FROM Groups").ToList();
            }
        }
        public static bool StudentAnswerQWZ(string Login,string Title,string About)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if(db.Query<DataModels.StudentAnswer>($"SELECT * FROM StudentAnswer WHERE Login='{Login}' AND TaskID={ db.Query<DataModels.Task>($"SELECT * FROM Task WHERE Title='{Title}' AND About='{About}'").First().TaskID}").Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static string GetGroupOrSpeciality(string Login,int Mode)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                switch (Mode)
                {
                    case 0:
                        return  db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupId={db.Query<DataModels.Students>($"SELECT * FROM Students WHERE Login='{Login}'").First().GroupId}").First().GroupNum;
                        

                    case 1:
                        return db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE SpecialityId={db.Query<DataModels.Teachers>($"SELECT * FROM Teachers WHERE Login='{Login}'").First().SpecialityID}").First().Title;
                        
                }
            }

            return null;
        }
            public static List<DataModels.TaskS> GetTasks(string GroupNum,int Mode)
            {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                switch (Mode) {
                    case 0:
                        if (db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupNum='{GroupNum}'").Count() > 0)
                        {
                            List<DataModels.GroupTask> list = db.Query<DataModels.GroupTask>($"SELECT * FROM Task WHERE GroupId={db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupNum='{GroupNum}'").First().GroupId}").ToList();
                            List<DataModels.TaskS> listS = new List<DataModels.TaskS>();
                            foreach (DataModels.GroupTask l in list)
                            {
                                DataModels.TaskS ts = new DataModels.TaskS
                                {
                                    Title = db.Query<DataModels.Task>($"SELECT * FROM Task WHERE TaskID={l.TaskId}").First().Title,
                                    About = db.Query<DataModels.Task>($"SELECT * FROM Task WHERE TaskID={l.TaskId}").First().About,
                                    Speciality = db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE SpecialityId={db.Query<DataModels.Task>($"SELECT * FROM Task WHERE TaskID={l.TaskId}").First().SpecialityId}").First().Title
                                };
                                listS.Add(ts);
                            }
                            return listS;
                        }
                        break;
                    case 1:
                        if (db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{GroupNum}'").Count() > 0)
                        {
                            List<DataModels.Task> listT = db.Query<DataModels.Task>($"SELECT * FROM Task WHERE SpecialityId={db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{GroupNum}'").First().SpecialityId}").ToList();
                            List<DataModels.TaskS> listST = new List<DataModels.TaskS>();
                            foreach (DataModels.Task l in listT)
                            {
                                DataModels.TaskS ts = new DataModels.TaskS
                                {
                                    Title = db.Query<DataModels.Task>($"SELECT * FROM Task WHERE TaskID={l.TaskID}").First().Title,
                                    About = db.Query<DataModels.Task>($"SELECT * FROM Task WHERE TaskID={l.TaskID}").First().About,
                                    Speciality = db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{GroupNum}'").First().Title
                                };
                                listST.Add(ts);
                            }
                            return listST;
                        }
                        break;
                }
            }
            return null;
            }
        public static void RegTeacherBD(string FirstName,string SecondName,string FamalyName,string Speciality,string Login)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"INSERT INTO Teachers (FirstName, SecondName,FamalyName,SpecialityID,Login) VALUES ('{FirstName}', '{SecondName}', '{FamalyName}', {db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{Speciality}'").First().SpecialityId }, '{Login}')");
            }
        }
        public static void RegStudentBD(string FirstName, string SecondName, string FamalyName, string GroupNum, string Login)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"INSERT INTO Students (FirstName, SecondName,FamalyName,GroupId,Login) VALUES ('{FirstName}', '{SecondName}', '{FamalyName}', {db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupNum='{GroupNum}'").First().GroupId }, '{Login}')");
            }
        }
        public static void AddSpeciality(string Name)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if(db.Query<DataModels.Speciality>($"SELECT * FROM Speciality").Count() > 0)
                {
                    db.Execute($"INSERT INTO Speciality (SpecialityId,Title ) VALUES ({db.Query<DataModels.Speciality>($"SELECT * FROM Speciality").Last().SpecialityId + 1}, '{Name}')"); ;
                }
                else
                {
                    db.Execute($"INSERT INTO Speciality (SpecialityId,Title ) VALUES ({0}, '{Name}')"); ;
                }
            }
        }
        public static void AddGroup(string Name)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.Query<DataModels.Group>($"SELECT * FROM Groups").Count() > 0)
                {
                    db.Execute($"INSERT INTO Groups (GroupId,GroupNum ) VALUES ('{db.Query<DataModels.Group>($"SELECT * FROM Groups").Last().GroupId + 1}', '{Name}')"); ;
                }
                else
                {
                    db.Execute($"INSERT INTO Groups (GroupId,GroupNum ) VALUES ('{0}', '{Name}')"); ;
                }
            }
        }
        public static void AddTask(string Title,string About, string Speciality,string GroupNum,string RightAnswer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.Query<DataModels.Group>($"SELECT * FROM Task").Count() > 0)
                {
                    int id = db.Query<DataModels.Task>($"SELECT * FROM Task").Last().TaskID + 1;
                    db.Execute($"INSERT INTO Task (TaskID,Title,About,SpecialityId,RightAnswer,GroupId ) VALUES ('{id}', '{Title}','{About}','{db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{Speciality}'").First().SpecialityId}','{RightAnswer}',{db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupNum='{GroupNum}'").First().GroupId})");
                }
                else
                {
                    db.Execute($"INSERT INTO Task (TaskID,Title,About,SpecialityId,RightAnswer,GroupId ) VALUES ('{0}', '{Title}','{About}','{db.Query<DataModels.Speciality>($"SELECT * FROM Speciality WHERE Title='{Speciality}'").First().SpecialityId}','{RightAnswer}',{db.Query<DataModels.Group>($"SELECT * FROM Groups WHERE GroupNum='{GroupNum}'").First().GroupId})");
                }
            }
        }
        public static bool AuthUSER(string Login, string Password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if (db.Query($"SELECT * FROM Users WHERE Login='{Login}' AND Password='{Password}'").Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static int IsRegUser(string Login)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                if ((db.Query($"SELECT * FROM Students WHERE Login='{Login}'").Count() > 0)||(db.Query($"SELECT * FROM Teachers WHERE Login='{Login}'").Count() > 0))
                {
                    if((db.Query($"SELECT * FROM Students WHERE Login='{Login}'").Count() > 0))
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }
        public static List<DataModels.Speciality> GetSpecialities()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
              return  db.Query<DataModels.Speciality>($"SELECT * FROM Speciality").ToList();
            }
        }
        public static List<DataModels.Group> GetGroups()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
              return db.Query<DataModels.Group>($"SELECT * FROM Groups").ToList();
            }
        }
    }
}
