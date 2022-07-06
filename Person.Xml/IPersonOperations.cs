using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Person.Xml
{
    public interface IPersonOperations
    {
        void Delete(Guid id);
        IEnumerable<XElement> GetAll();
        void Create(Person.Models.Person person);
        void Update(Person.Models.Person person);
    }
}
