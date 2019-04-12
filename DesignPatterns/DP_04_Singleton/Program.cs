using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DP_04_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            var mario = new Person { Name = "Mario" };
            var luigi = new Person { Name = "Luigi" };

            PersonRepository.Instance.Add(mario);
            PersonRepository.Instance.Add(luigi);


            Console.ReadKey();
        }
    }

    class PersonRepository
    {
        private List<Person> _items;

        #region Singleton        
        /// 
        /// Implementazione primitiva non thread-safe
        /// 
        //static PersonRepository _instance = null;
        //public static PersonRepository Instance {
        //    get {
        //        if (_instance == null)
        //            _instance = new PersonRepository();

        //        return _instance;
        //    }
        //}

        ///Il costruttore statico è thread-safe
        ///questa è quindi l'implementazione più corretta per la gestione dei singleton
        static PersonRepository()
        {
            Instance = new PersonRepository();
        }
        public static PersonRepository Instance { get; }

        private PersonRepository()
        {
            _items = new List<Person>();
        }
        #endregion Singleton

        public void Add(Person p)
        {
            if (p.ID != 0) {
                throw new ArgumentException("Id già valorizzato!", nameof(Person));
            }

            var newId = _items.Count == 0
                ? 1
                : _items.Max(x => x.ID) + 1;

            p.ID = newId;

            _items.Add(p);
        }

        public void Update(Person p)
        {
            if (p.ID == 0)
                throw new ArgumentException("Id 0!", nameof(Person));
            
            var index = _items.FindIndex(x => x.ID == p.ID);
            if (index == -1)
                throw new ArgumentException("Person not registerd!", nameof(Person));

            _items[index] = p;
        }

        public Person Get(int id)
        {
            var p = _items.FirstOrDefault(x => x.ID == id);
            if (p == null)
                throw new ArgumentException("Person not registerd!", nameof(Person));

            return p;
        }

        public IEnumerable<Person> GetAll()
        {
            return _items.ToList();
        }

        public void Remove(int id)
        {
            var p = _items.FirstOrDefault(x => x.ID == id);
            if (p == null)
                throw new ArgumentException("Person not registerd!", nameof(p));

            _items.Remove(p);
        }
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
