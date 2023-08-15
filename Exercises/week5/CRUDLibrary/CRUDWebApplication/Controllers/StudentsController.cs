using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDLibrary;


namespace CRUDWebApplication.Controllers
{
    //StudentsController -> /api/Students endpoint
    public class StudentsController : ApiController
    {
        //Creates the db context
        CollegeEntities OE = new CollegeEntities();


        /// <summary>
        ///..api/Students/1 -> Get all student rows in db 
        /// </summary>
        /// <returns>Array of Students</returns>
        public IQueryable<Student> Get()
        {
            return OE.Students;
        }

        /// <summary>
        /// ..api/Students/1 -> get single student from db
        /// </summary>
        /// <param name="id">Id of student to fetch</param>
        /// <returns>single student</returns>
        public Student Get(int id)
        {
            Student student = OE.Students.Find(id);
            return student;
        }

        /// <summary>
        ///    ../api/Students/{id} -> update an existing student in db
        /// </summary>
        /// <param name="id">id of student to update</param>
        /// <param name="student">json obj of student data, m</param>
        public void Put(int id, Student student)
        {
            OE.Entry(student).State =
            System.Data.Entity.EntityState.Modified
            ;
            OE.SaveChanges();
        }


        /// <summary>
        /// ../api/Student{id} remove a student from the db with a given id
        /// </summary>
        /// <param name="id">id of student to remove</param>
        public void Delete(int id)
        {
            Student student = OE.Students.Find(id);
            OE.Students.Remove(student);
            OE.SaveChanges();
        }
        /// <summary>
        /// ..api/Students/{id} -> add a studnet tot he database 
        /// </summary>
        /// <param name="student">json obj of studnet to add</param>
        public void Post(Student student)
        {
            OE.Students.Add(student);
            OE.SaveChanges();
        }
    }
}
