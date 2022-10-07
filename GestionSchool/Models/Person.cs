using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool.Models
{
    public abstract class Person 
    {
        /// <summary>
        /// nombre representant  la premiere option choisi
        /// </summary>
        public static int Nbr { get; set; }

        /// <summary>
        /// nombre representant  la deuxieme option choisi
        /// </summary>
        public static int Nbr1 { get; set; }

        /// <summary>
        /// prend et retourne le nom d'une personne
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///prend et retourne le prenom d'une personne
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// prend et retourne la date de naissnce  d'une personne
        /// </summary>
        public DateTime DateNaissance { get; set; }

        /// <summary>
        /// retourne l'age d'une personne
        /// </summary>
        /// <returns></returns>
        public int Age
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - DateNaissance;
                double hour = timeSpan.TotalHours;
                double year = hour / 24 / 365;
                return (int)year;
            }
        }


        /// <summary>
        /// affiche l'age d'une person
        /// </summary>
        


        /// <summary>
        /// constructeur vide
        /// </summary>
        public Person() { }

        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prenom"></param>
        /// <param name="dateNaissance"></param>
        public Person(string name, string prenom, DateTime dateNaissance)
        {
            Name = name;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }


        /// <summary>
        /// liste de tout les personnes
        /// </summary>
       // public static List<Person> Persons { get; set; }
        public static List<Person> Persons = new List<Person>();


        /// <summary>
        /// donne les options choisi par utilisateur 
        /// </summary>
        public static void Attribuer(int nbr1 , int nbr2)
        {
            Nbr = nbr1;
            Nbr1 = nbr2;
        }


        /// <summary>
        /// Enregistre une personne et retourne la personne enregistre
        /// </summary>
        /// <returns></returns>
       


    }
}
