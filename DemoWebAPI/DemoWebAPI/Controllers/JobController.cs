using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoWebAPI.Models;
using System.Collections;
using System.Web.UI.WebControls;

namespace DemoWebAPI.Controllers
{
    public class JobController : ApiController
    {
        Entities db = new Entities();

        //Post
        public string Post(api_emp emp)
        {
            db.api_emp.Add(emp);
            db.SaveChanges();
            return "Data Added";
        }

        //Get All Records
        public IEnumerable<api_emp> Get()
        {
            return db.api_emp.ToList();
        }

        //Get Single Record
        public api_emp Get(int id)
        {
            api_emp emp = db.api_emp.Find(id);
            return emp;
        }

        //Update the record
        public string Put(int id, api_emp emp)
        {
            var emp_ = db.api_emp.Find(id);
            emp_.title = emp.title;
            emp_.location = emp.location;
            emp_.department = emp.department;

            db.SaveChanges();

            return "Updated";
        }

        //Delete the record
        public string Delete(int id)
        {
            api_emp emp = db.api_emp.Find(id);
            db.api_emp.Remove(emp);
            db.SaveChanges();
            return "deleted";
        }
    }
}
