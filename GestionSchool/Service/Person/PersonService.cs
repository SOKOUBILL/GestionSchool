using System;
using GestionSchool.Models;
using GestionSchool.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace GestionSchool.Service.Person
{
    public class PersonService<T> : IPersonService<T>
        where T : Models.Person
    {
        #region(properties)
        private string fileLocation;
        private List<T> list = new List<T>();
        #endregion

        #region(constructor)
        public PersonService(string storageDirectory)
        {
            var fileName = $"{typeof(T).Name}.json";

            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if (!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);
            
            fStream?.Close();
            Deserialize();

        }

        public PersonService(string storageDirectory, string fileName)
        {
            //var fileName = $"{typeof(T).Name}.json";

            fileLocation = Path.Combine(storageDirectory, fileName);
            FileStream fStream = null;
            if (!File.Exists(fileName))
                File.Create(fileName);
            if (!Directory.Exists(storageDirectory))
                Directory.CreateDirectory(storageDirectory);

            if (!File.Exists(fileLocation))
                fStream = File.Create(fileLocation);

            fStream?.Close();
            Deserialize();
        }

        public PersonService() { }

        #endregion

        #region(public methods)
        

        
        
        

        /// <summary>
        /// Ajouter une personne et retourne la personne ajoute
        /// </summary>
        /// <returns></returns>
        public T Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException("data: is not reference as instance " +
                    "of an object");
            list.Add(data);
            Serialize();
            return data;
        }



        /// <summary>
        /// cherche le nom correspondant a une personne et retourne cette personne 
        /// </summary>
        /// <returns></returns>
        public T FindByName(string name)
        {
            var result = list.FirstOrDefault(x => x.Name == name);
            
            if (result == null)
                throw new ArgumentNullException("\n\t  Cette personne  n'existe " +
                    "pas !");

            return result;
        }



        /// <summary>
        /// Modifie les proprites d'une personne et retourne la personne modifie 
        /// </summary>
        /// <returns></returns>
        

        public T Update(string name, T data)
        {
            try
            {
                if (data == null)
                    throw new ArgumentNullException("Desole nous ne pouvons pas effectuer" +
                        " cette operation.");
                var result = list.FirstOrDefault(x => x.Name == name);
                if (result == null)
                    throw new ArgumentNullException("\n\t  Cette personne  n'existe " +
                        "pas !");
                var index = list.IndexOf(result);
                list[index] = data;
                Serialize();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return data;
        }


        /// <summary>
        /// supprime une personne et return true si elle a ete supprime 
        /// et false dans le cas ccontraire
        /// </summary>
        /// <returns></returns>
        public bool Remove(string name)
        {
            bool decision = false;
            try
            {
                var result = list.FirstOrDefault(x => x.Name == name);
                if (result == null)
                    throw new ArgumentNullException("Cette personne  n'existe " +
                        "pas !");
                decision = list.Remove(result);
                Serialize();
                
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
            if (decision)
                return true;
            return false;
        }


        /// <summary>
        /// retourne la personne la moins age 
        /// </summary>
        /// <returns></returns>
        public T GetYoung()
        {

            try
            {
                var min = list.FirstOrDefault(x => x.Age == (list.Min(i => i.Age)));
                return min;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// retourne la liste des personnes contenue dans la base de données  
        /// </summary>
        /// <returns></returns>
        public ICollection<T> GetAll(int? skip=null,int? take=null) =>
            list.Skip(skip ?? 0).Take(take ?? list.Count).ToList();


        

        #endregion


        #region(private methods)

        private void Deserialize()
        {
            var json = File.ReadAllText(fileLocation);
            list = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }
        private void Serialize()
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(list);
                File.WriteAllText(fileLocation, jsonData);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        
        #endregion

    }
}
