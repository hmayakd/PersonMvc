using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Person.Xml
{
    internal class PersonOperations : IPersonOperations
    {
        private static string fileFolder = Directory.GetDirectories(Directory.GetCurrentDirectory())[0]+ "\\Debug\\net5.0";
        private string path =Path.Combine(fileFolder, "dbPerson.xml");
        public void Create(Person.Models.Person element)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement personElem = xDoc.CreateElement("person");
            XmlElement ageElem = xDoc.CreateElement("age");
            XmlElement idElem = xDoc.CreateElement("id");
            XmlElement firstNameElem = xDoc.CreateElement("firstName");
            XmlElement lastNameElem = xDoc.CreateElement("lastName");
            XmlText idText = xDoc.CreateTextNode(element.Id.ToString());
            XmlText ageText = xDoc.CreateTextNode(element.Age.ToString());
            XmlText firstNameText = xDoc.CreateTextNode(element.FirstName);
            XmlText lastNameText = xDoc.CreateTextNode(element.LastName);
            idElem.AppendChild(idText);
            ageElem.AppendChild(ageText);
            firstNameElem.AppendChild(firstNameText);
            lastNameElem.AppendChild(lastNameText);
            personElem.AppendChild(idElem);
            personElem.AppendChild(ageElem);
            personElem.AppendChild(firstNameElem);
            personElem.AppendChild(lastNameElem);
            xRoot?.AppendChild(personElem);
            xDoc.Save(path);
        }

        public void Delete(Guid id)
        {
            XDocument xml = XDocument.Load(path);

            var personDelete = xml.Element("persons")
                            .Elements("person")
                            .Where(i => Guid.Parse(i.Element("id").Value) == id)
                            .Select(p => p)
                            .FirstOrDefault();
            if (personDelete != null)
            {
                personDelete.Remove();
                xml.Save(path);
            }
        }
        public IEnumerable<XElement> GetAll()
        {
            XDocument xml = XDocument.Load(path);
            return xml.Element("persons")
                      .Elements("person");
        }

        public void Update(Person.Models.Person person)
        {
            XDocument xml = XDocument.Load(path);

            var personUpdate = xml.Element("persons")
                            .Elements("person")
                            .Where(i => Guid.Parse(i.Element("id").Value) == person.Id)
                            .Select(p => p)
                            .FirstOrDefault();
            if (personUpdate != null)
            {
                personUpdate.Element("age").Value = person.Age.ToString();
                personUpdate.Element("firstName").Value = person.FirstName;
                personUpdate.Element("lastName").Value = person.LastName;
                xml.Save(path);
            }
        }
    }
}
