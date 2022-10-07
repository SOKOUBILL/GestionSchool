using System;
using GestionSchool.Models;
using GestionSchool.Service.Person;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace GestionSchool.Service.Student
{
    public class StudentService : PersonService<Models.Student> 
    {
        /// <summary>
        /// Retourne la liste des etudiants
        /// </summary>
        /// <returns></returns>

        public ICollection<Models.Student> GetStudents()
        {
            PersonService<Models.Student> dataBaseStudents = new PersonService<Models.Student>("Database",
                 "Student.json");
            var t = dataBaseStudents.GetAll();
            return t;

        }


        ///// <summary>
        ///// retourne une prhase indiquant l'age d'un etudiant
        ///// </summary>
        ///// <returns></returns>
        //public string DisplayAge()
        //{
        //    return $"My age is: {SetAge(Age)} ";
        //}
    }
}
