using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataLibrary
{
    public class StudentRepository
    {
        private readonly SqlConnection _sqlProvider;

        public StudentRepository()
        {
            var myConnection = "data source= (localdb)\\mssqllocaldb; database= TrainingDatabase;";

            _sqlProvider = new SqlConnection(myConnection);
        }

        public IEnumerable<StudentProperties> GetDetails()
        {
            try
            {
                _sqlProvider.Open();

                var myCommand = new SqlCommand("select * from StudentDetails", _sqlProvider);

                var myOperation = myCommand.ExecuteReader();

                var studentList = new List<StudentProperties>();

                while(myOperation.Read())
                {
                    studentList.Add(new StudentProperties
                    {
                        StudentID=(int)myOperation["StudentID"],
                        StudentName=(string)myOperation["StudentName"],
                        StudentAge=(int)myOperation["StudentAge"],
                        StudentCourse=(string)myOperation["StudentCourse"],
                    });
                }
                return studentList;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                _sqlProvider.Close();
            }
        }

        public IEnumerable<StudentProperties> viewDetails(int id)
        {
            try
            {
                _sqlProvider.Open();

                var myCommand = new SqlCommand("select * from StudentDetails where StudentID = @id", _sqlProvider);

                
                myCommand.Parameters.AddWithValue("id",id);

                var viewCommand = myCommand.ExecuteReader();

                var studentlist = new List<StudentProperties>();

                while (viewCommand.Read())
                {
                    studentlist.Add(new StudentProperties
                    {
                        StudentID = (int)viewCommand["StudentID"],
                        StudentName=(string)viewCommand["StudentName"],
                        StudentAge=(int)viewCommand["StudentAge"],
                        StudentCourse=(string)viewCommand["StudentCourse"],
                    });
                }

                return studentlist;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                _sqlProvider.Close();
            }
        }

        public bool InsertDetails(StudentProperties projects)
        {
            try
            {
                _sqlProvider.Open();

                var myCommand = new SqlCommand("insert into StudentDetails values (@name, @age, @course); ", _sqlProvider);

                myCommand.Parameters.AddWithValue("name", projects.StudentName);
                myCommand.Parameters.AddWithValue("age", projects.StudentAge);
                myCommand.Parameters.AddWithValue("course", projects.StudentCourse);

                var insertCommand = myCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlProvider.Close();
            }

        }

        public bool UpdateDetails(StudentProperties projects)
        {
            try
            {
                _sqlProvider.Open();

                var updateConnect = new SqlCommand("update StudentDetails set StudentName=@name where StudentID=@id", _sqlProvider);

                updateConnect.Parameters.AddWithValue("name", projects.StudentName);
                updateConnect.Parameters.AddWithValue("id", projects.StudentID);

                var updateData = updateConnect.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlProvider.Close();
            }
        }

        public bool DeleteDetails(int id)
        {
            try
            {
                _sqlProvider.Open();

                var deleteDetails = new SqlCommand("delete StudentDetails where StudentID=@id", _sqlProvider);

                deleteDetails.Parameters.AddWithValue("id", id);

                var deleteData = deleteDetails.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlProvider.Close();
            }
        }
    }
}
