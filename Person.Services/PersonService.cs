using Person.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Person.Services
{
    internal class PersonService : IPersonService
    {
        private readonly IPersonOperations _personOperations;
        public PersonService(IPersonOperations personOperations)
        {
            _personOperations = personOperations;
        }

        public void Add(Models.Person person)
        {
            _personOperations.Create(person);
        }

        public void Delete(Guid id)
        {
            _personOperations.Delete(id);
        }

        public Models.Person Get(Guid id)
        {

            return _personOperations.GetAll()
                                    .Select(p => new Models.Person
                                                            {
                                                                Id = Guid.Parse(p.Element("id").Value),
                                                                Age = int.Parse(p.Element("age").Value),
                                                                FirstName = p.Element("firstName").Value,
                                                                LastName = p.Element("lastName").Value
                                                            })
                                    .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Models.Person> GetAll()
        {
            return _personOperations.GetAll()
                                    .Select(p => new Models.Person
                                    {
                                        Id = Guid.Parse(p.Element("id").Value),
                                        Age = int.Parse(p.Element("age").Value),
                                        FirstName = p.Element("firstName").Value,
                                        LastName = p.Element("lastName").Value
                                    });
        }

        public void Update(Models.Person person)
        {
            _personOperations.Update(person);
        }
    }
}
