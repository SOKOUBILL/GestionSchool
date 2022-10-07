using System;
using GestionSchool.Models;
using GestionSchool.Service.Person;
using GestionSchool.Service.Student;
using GestionSchool.Service.Teacher;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu();

            #region(affichage du nom de la plus petite personne)
            Person student = new Student();
            Person teacher = new Teacher();
            PersonService<Student> dataBaseStuden = new PersonService<Student>("DataBase", "Person.json");
            try
            {
                student = dataBaseStuden.GetYoung();
                Console.WriteLine($"La plus petite personne existante dans notre " +
                    $"base de données est {student.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Pas de personne dans la base de données ");
            }
            #endregion
        }


        /// <summary>
        /// Menu permettant de choisir des options et de les executer
        /// </summary>
        public static void Menu()
        {
            int nbr;
            double salaire;
            bool isvalide;
            int nbr1;
            bool isvalide1;
            bool isvalide2;
            PersonService<Student> dataBaseStudent = new PersonService<Student>("DataBase");
            PersonService<Student> dataBasePerson = new PersonService<Student>("DataBase", "Person.json");
            PersonService<Teacher> dataBasePerson1 = new PersonService<Teacher>("DataBase", "Person.json");
            PersonService<Teacher> dataBaseTeacher = new PersonService<Teacher>("DataBase");


            Console.WriteLine("\n\n\t\t\t\t****************** BIENVENUE ******************\n\n");
            Console.WriteLine("\t\t 1- Etudiant ");
            Console.WriteLine("\t\t 2- Enseignant");
            Console.WriteLine("\t\t 3- Afficher toutes les personnes ");
            do
            {
                Console.Write("\n Choisir une option : \n\n");
                string value = Console.ReadLine();
                isvalide2 = int.TryParse(value, out nbr);
            } while (isvalide2 == false);



            if (nbr == 1 || nbr == 2)
            {
                Console.WriteLine("\t\t  1- Ajouter");
                Console.WriteLine("\t\t  2- Supprimer");
                Console.WriteLine("\t\t  3- Modifier");
                Console.WriteLine("\t\t  4- Afficher la liste ");
                do
                {
                    Console.Write("\n Choisir une option : \n\n");
                    string value = Console.ReadLine();
                    isvalide1 = int.TryParse(value, out nbr1);
                } while (isvalide1 == false);

                Person.Attribuer(nbr, nbr1);


                /// <summary>
                /// Ajouter une personne etudiant
                /// </summary>
                if (nbr == 1 && nbr1 == 1)
                {
                    Console.WriteLine($"Entrer le nom de l'etudiant :");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Entrer son prenom :");
                    string prenom = Console.ReadLine();
                    Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
                    string date = Console.ReadLine();
                    DateTime dateNaissance = DateTime.Parse(date);
                    Console.WriteLine($"Entrer son matricule :");
                    string matricule = Console.ReadLine();
                    Student student = new Student(name, prenom, dateNaissance, matricule);

                    dataBaseStudent.Add((Student)student);
                    dataBasePerson.Add(student);

                    //Console.WriteLine($"l'etudiant {Name} a bien ete ajouté");
                }

                /// <summary>
                /// Ajouter une personne enseignant
                /// </summary>
                else if (nbr == 2 && nbr1 == 1)
                {
                    Console.WriteLine($"Entrer le nom de l'enseignant :");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Entrer son prenom :");
                    string prenom = Console.ReadLine();
                    Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
                    string datet = Console.ReadLine();
                    DateTime dateNaissance = DateTime.Parse(datet);

                    do
                    {
                        Console.WriteLine($"Entrer son salaire :");
                        string value = Console.ReadLine();
                        isvalide = double.TryParse(value, out salaire);
                    } while (isvalide == false);

                    Console.WriteLine($"Entrer sa date de prise de fonction suivant cette ordre(année/mois/jour): ");
                    string datet2 = Console.ReadLine();
                    DateTime datePriseFonction = DateTime.Parse(datet2);

                    Teacher teacher = new Teacher(name, prenom, dateNaissance, salaire, datePriseFonction);
                    dataBaseTeacher.Add((Teacher)teacher);
                    dataBasePerson1.Add(teacher);

                }

                /// <summary>
                /// modifier une personne etudiant
                /// </summary>
                else if (nbr == 1 && nbr1 == 3)
                {
                    Console.WriteLine(" Veiller entrer le nom de l'etudiant que vous voulez modifier ");
                    string nameStudentAModifier = Console.ReadLine();
                    Console.WriteLine($"\n\t\t Veiller renseigner les nouvelles informations");
                    Console.WriteLine($"Entrer le nom de l'etudiant :");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Entrer son prenom :");
                    string prenom = Console.ReadLine();
                    Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
                    string date = Console.ReadLine();
                    DateTime dateNaissance = DateTime.Parse(date);
                    Console.WriteLine($"Entrer son matricule :");
                    string matricule = Console.ReadLine();

                    Student student = new Student(name, prenom, dateNaissance, matricule);
                    dataBaseStudent.Update(nameStudentAModifier, student);
                    dataBasePerson.Update(nameStudentAModifier, student);
                }

                /// <summary>
                /// modifier une personne enseignant
                /// </summary>
                else if (nbr == 2 && nbr1 == 3)
                {
                    Console.WriteLine(" Veiller entrer le nom de l'enseignant que vous voulez modifier ");
                    string nameTeacherAModifier = Console.ReadLine();
                    Console.WriteLine($"\n\t\t Veiller renseigner les nouvelles informations");
                    Console.WriteLine($"Entrer le nom de l'enseignant :");
                    string namet = Console.ReadLine();
                    Console.WriteLine($"Entrer son prenom :");
                    string prenomt = Console.ReadLine();
                    Console.WriteLine($"Entrer sa date de naissance suivant cette ordre(année/mois/jour): ");
                    string datet = Console.ReadLine();
                    DateTime dateNaissancet = DateTime.Parse(datet);

                    do
                    {
                        Console.WriteLine($"Entrer son salaire :");
                        string value = Console.ReadLine();
                        isvalide = double.TryParse(value, out salaire);
                    } while (isvalide == false);

                    Console.WriteLine($"Entrer sa date de prise de fonction  suivant l'ordre(jour/mois/année: ");
                    string datet2 = Console.ReadLine();
                    DateTime datePriseFonction = DateTime.Parse(datet2);

                    Teacher teacher= new Teacher(namet, prenomt, dateNaissancet, salaire, datePriseFonction);

                    dataBaseTeacher.Update(nameTeacherAModifier, teacher);
                    dataBasePerson1.Update(nameTeacherAModifier, teacher);
                }

                /// <summary>
                /// supprimer une personne etudiant
                /// </summary>
                else if (nbr == 1 && nbr1 == 2)
                {
                    Console.WriteLine(" Veiller entrer le nom de l'etudiant que vous voulez supprime ");
                    string name = Console.ReadLine();
                    bool decisionsupprimer = dataBaseStudent.Remove(name);
                    Console.WriteLine(decisionsupprimer);
                    bool decisionsupprimer1 = dataBasePerson.Remove(name);
                    

                }

                /// <summary>
                /// supprimer une personne enseignant
                /// </summary>
                else if (nbr == 2 && nbr1 == 2)
                {
                    Console.WriteLine(" Veiller entrer le nom de l'enseignant que vous voulez supprime ");
                    string name = Console.ReadLine();
                    bool decisionsupprimer = dataBaseTeacher.Remove(name);
                    Console.WriteLine(decisionsupprimer);
                    bool decisionsupprimer1 = dataBasePerson1.Remove(name);
                    
                }


                /// <summary>
                /// Afficher la liste des etudiants
                /// </summary>
                else if (nbr == 1 && nbr1 == 4)
                {
                    Console.WriteLine(" La liste des etudiants est :");
                    StudentService studentService = new StudentService();

                    var list = studentService.GetStudents();
                    if (list.Count == 0)
                        Console.WriteLine($"\t\t La liste ne contient pas encore d'etudiant");

                    foreach (var student in list)
                    {
                        Console.WriteLine($"\t\t * {student.Name}  ");
                    }
                }


                /// <summary>
                /// Afficher la liste des enseignants
                /// </summary>
                else if (nbr == 2 && nbr1 == 4)
                {
                    Console.WriteLine(" La liste des enseignants est :");
                    TeacherService teacherService = new TeacherService();

                    var list = teacherService.GetTeahers();
                    if (list.Count == 0)
                        Console.WriteLine($"\t\t La liste ne contient pas encore d'enseignant");

                    foreach (var teacher in list)
                    {
                        Console.WriteLine($"\t\t * {teacher.Name}  ");
                    }
                }

            }
            //    /// <summary>
            //    /// Afficher la liste des personnes
            //    /// </summary>
            else if (nbr == 3)
            {
                Console.WriteLine(" La liste des personnes est :");
                PersonService<Student> dataBasePersons = new PersonService<Student>("Database",
             "Person.json");

                var list = dataBasePersons.GetAll();
                if (list.Count == 0)
                    Console.WriteLine($"\t\t La liste ne contient pas encore de person");

                foreach (Person pe in list)
                {
                    Console.WriteLine($"\t\t * {pe.Name}  ");
                }
            }

        }  
        
    }
}
    
