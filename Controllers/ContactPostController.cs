using e4_ContactsProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace e4_ContactsProject.Views.Home
{
    public class ContactPostController : Controller
    {
        // GET: ContactPost
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactPost/Create
        public ActionResult Create()
        {
            return View();
        }

        public class Serializer
        {
            public T Deserialize<T>(string input) where T : class
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

                using (StringReader sr = new StringReader(input))
                {
                    return (T)ser.Deserialize(sr);
                }
            }

            public string Serialize<T>(T ObjectToSerialize)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                    return textWriter.ToString();
                }
            }
        }

        // POST: ContactPost/readXML
        [HttpGet]
        public JsonResult readXML(string ID)
        {
            string directory = Server.MapPath("/XMLFile");
            string filename = "XMLFile1.xml";
            string path = Path.Combine(directory, filename);
            var xmlStr = System.IO.File.ReadAllText(path);
            var xmlElmnts = XElement.Parse(xmlStr);

            if (ID != null)
            {
                var result = xmlElmnts.Elements("Contact").Where(x => x.Element("ContactID").Value.Equals(ID)).ToList();
                Serializer ser = new Serializer();
                List<Contact> ContactList = new List<Contact>();
                foreach (System.Xml.Linq.XElement itm in result)
                {
                    Contact contact = ser.Deserialize<Contact>(itm.ToString());
                    ContactList.Add(contact);
                }
                return Json(ContactList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = xmlElmnts.Elements("Contact").ToList();

                Serializer ser = new Serializer();
                List<Contact> ContactList = new List<Contact>();
                foreach (System.Xml.Linq.XElement itm in result)
                {
                    Contact contact = ser.Deserialize<Contact>(itm.ToString());
                    ContactList.Add(contact);
                }
                return Json(ContactList, JsonRequestBehavior.AllowGet);
            }
        }

        

        public string UpdateContact(string ID,string title, string firstname, string lastname, string email,string gender, string cellnumber,string contactnumber,string birthdate)
        {
            string directory = Server.MapPath("/XMLFile");
            string filename = "XMLFile1.xml";
            string path = Path.Combine(directory, filename);

            XElement root = XElement.Load(path);
            IEnumerable<XElement> contacts =
                from el in root.Elements("Contact")
                where (string)el.Element("ContactID") == ID
                select el;
            foreach (XElement el in contacts)
            {
                el.Element("Title").Value = title;
                el.Element("Firstname").Value = firstname;
                el.Element("Lastname").Value = lastname;
                el.Element("EmailAddress").Value = email;
                el.Element("Gender").Value = gender;
                el.Element("CellNumber").Value = cellnumber;
                el.Element("ContactNumber").Value = contactnumber;
                el.Element("BirthDate").Value = birthdate;
                Console.WriteLine(el);
            }

            root.Save(path);
            return "success";
        }


        public string AddContact(Models.Contact contact)
        {
            string directory = Server.MapPath("/XMLFile");
            string filename = "XMLFile1.xml";
            string path = Path.Combine(directory, filename);

            XElement myElement = new XElement("Contact",
                new XElement("ContactID", contact.ContactID),
                new XElement("Title", contact.Title),
                new XElement("Firstname", contact.Firstname),
                new XElement("Lastname", contact.Lastname),
                new XElement("EmailAddress", contact.EmailAddress),
                new XElement("Gender", contact.Gender),
                new XElement("CellNumber", contact.CellNumber),
                new XElement("ContactNumber", contact.ContactNumber),
                new XElement("BirthDate", contact.BirthDate.ToString())
            );

            XDocument doc = XDocument.Load(path);
            doc.Element("Contacts").Add(myElement);
            doc.Save(path);

            return "Saved Contact";
        }


        

        // POST: ContactPost/Create
        [HttpPost]
        public bool Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Contact contact = new Contact();
                // Retrieve form data using form collection
                contact.ContactID = new Guid(collection["ContactID"]);
                contact.Title = collection["Title"];
                contact.Firstname = collection["Firstname"];
                contact.Lastname = collection["Lastname"];
                contact.EmailAddress = collection["EmailAddress"];
                contact.Gender = collection["Gender"];
                contact.CellNumber = collection["CellNumber"];
                contact.ContactNumber = collection["ContactNumber"];
                contact.BirthDate = collection["BirthDate"];
                AddContact(contact);
            }
            catch
            {
                return false;
            }
            return true;
        }

        

        // POST: ContactPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
