using System;
using System.Collections.Generic;

namespace Person.Services
{
    public interface IPersonService
    {
        void Add(Person.Models.Person person);
        void Update(Person.Models.Person person);
        void Delete(Guid id);
        Person.Models.Person Get(Guid id);
        IEnumerable<Person.Models.Person> GetAll();
    }
}
