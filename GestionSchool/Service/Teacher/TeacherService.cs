using System;
using GestionSchool.Models;
using GestionSchool.Service.Person;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool.Service.Teacher
{
    public class TeacherService : PersonService<Models.Teacher>
    {
        /// <summary>
        /// redefinition de ToString()
        /// </summary>
        /// <returns></returns>
        //public override string ToString()
        //{
        //    return $" hello i am TeacherService mon nom est {Name} . {Explain("commencer")}";
        //}



        /// <summary>
        /// Retourne la liste des enseignants
        /// </summary>
        /// <returns></returns>
        public ICollection<Models.Teacher> GetTeahers()
        {
            PersonService<Models.Teacher> dataBaseStudents = new PersonService<Models.Teacher>("Database",
                 "Teacher.json");
            var t = dataBaseStudents.GetAll();
            return t;
        }



        /// <summary>
        /// Retourne l'enseignant ayant le plus gros salaire
        /// </summary>
        /// <returns></returns>
        //public Person GetBestTeacher()
        //{
        //    List<TeacherService> Teachers = new List<TeacherService>();
        //    Teachers = GetTeahers();
        //    List<double> Salaires = new List<double>();
        //    double bestsalaire = 0;
        //    Person bestTeacher = new TeacherService();
        //    foreach (TeacherService pe in Teachers)
        //    {
        //        Salaires.Add(pe.Salaire);
        //    }
        //    for (int i = 0; i < Salaires.Count; i++)
        //    {
        //        if (Salaires[i] > bestsalaire)
        //        {
        //            bestsalaire = Salaires[i];
        //        }
        //    }
        //    foreach (TeacherService pe in Teachers)
        //    {
        //        if (bestsalaire == pe.Salaire)
        //        {
        //            bestTeacher = pe;
        //        }
        //    }
        //    return bestTeacher;
        //}
    }
}
