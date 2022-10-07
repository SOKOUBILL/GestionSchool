using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool.Service.Person
{
    public interface IPersonService<T>
    {
        /// <summary>
        /// Enregistre une personne et retourne la personne enregistre
        /// </summary>
        /// <returns></returns>
        T Add(T data);

        /// <summary>
        /// Modifie les proprites d'une personne et retourne la personne modifie 
        /// </summary>
        /// <returns></returns>
        T Update(string name, T data);

        /// <summary>
        /// cherche le nom correspondant a une personne et retourne cette personne 
        /// </summary>
        /// <returns></returns>
        T FindByName(string name);

        /// <summary>
        /// supprime une personne et return true si elle a ete supprime 
        /// et false dans le cas ccontraire
        /// </summary>
        /// <returns></returns>
        bool Remove(string name);

        /// <summary>
        /// retourne la personne la moins age 
        /// </summary>
        /// <returns></returns>
        T GetYoung();

        /// <summary>
        /// retourne la liste des personnes contenue dans la base de données  
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetAll(int? skip = null, int? take = null);
    }
}
