using System;
using GestionSchool.Models;
using GestionSchool.Service.Person;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool.Service.Student
{
    public interface IStudentService : IPersonService<Models.Student>
    {
        /// <summary>
        /// Retourne la liste des etudiants
        /// </summary>
        /// <returns></returns>
        List<Models.Student> GetStudents();
    }
}
