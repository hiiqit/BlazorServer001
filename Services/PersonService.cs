using System;
using System.Collections.Generic;
using System.Linq;
using BlazorServer001.Data;

namespace BlazorServer001.Services
{
    public class PersonService
    {
        private List<Person> _persons;

        public PersonService()
        {
            _persons = new List<Person>();
            // Add some initial data for demonstration purposes
            for (int i = 1; i < 1234; i++)
            {
                _persons.Add(new Person { Id = i, Name = $@"John{i} Doe{i}", Age = 30, Email = $@"johnd{i}@example.com" });
            }
        }

        public PersonResult GetPersons(int page, int pageSize)
        {
            var result = new PersonResult();
            result.Items = _persons
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            result.TotalCount = _persons.Count;
            return result;
        }

        public Person GetPersonById(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }

        public void AddPerson(Person person)
        {
            // Assign a new unique ID to the person
            person.Id = GetNextPersonId();
            _persons.Add(person);
        }

        public void UpdatePerson(Person person)
        {
            var existingPerson = _persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.Age = person.Age;
                existingPerson.Email = person.Email;
            }
        }

        public void DeletePerson(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _persons.Remove(person);
            }
        }

        private int GetNextPersonId()
        {
            int maxId = _persons.Any() ? _persons.Max(p => p.Id) : 0;
            return maxId + 1;
        }
    }

    public class PersonResult
    {
        public List<Person> Items { get; set; }
        public int TotalCount { get; set; }
    }
}

