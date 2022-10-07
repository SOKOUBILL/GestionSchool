using System;
using GestionSchool.Models;
using GestionSchool.Service.Person;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool.Service.Teacher
{
    public interface ITeacherService : IPersonService<Models.Teacher>
    {
        /// <summary>
        /// Retourne la liste des enseignants
        /// </summary>
        /// <returns></returns>
        List<Models.Teacher> GetTeahers();

        /// <summary>
        /// Retourne l'enseignant ayant le plus gros salaire
        /// </summary>
        /// <returns></returns>
        Models.Teacher GetBestTeacher();
    }
}
