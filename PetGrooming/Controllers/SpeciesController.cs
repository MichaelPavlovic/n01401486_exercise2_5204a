using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {

        //Controller provided by Christine Bittle https://github.com/christinebittle/PetGroomingMVC

        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        // List
        public ActionResult List()
        {
            //modify to have search functionality
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();
            return View(myspecies);
        }

        //URL: /Species/Add
        //GOTO Views -> Species -> Add.cshtml
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {
            //STEP 1: gather user input data for pet species
            Debug.WriteLine("I am gathering species name of " + SpeciesName);
            //STEP 2: create query
            string query = "insert into species (Name) values (@SpeciesName)";
            SqlParameter sqlparams = new SqlParameter("@SpeciesName", SpeciesName);
            //STEP 3: run query
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //STEP 4: go back to list of species
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            //create query
            string query = "delete from species where speciesid=@id";
            SqlParameter sqlparam = new SqlParameter("@id", id);

            //execute query
            db.Database.ExecuteSqlCommand(query, sqlparam);
            //go back to list of species
            return RedirectToAction("List");
        }

        public ActionResult Show(int id)
        {
            //create query
            string query = "select * from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id", id);

            Species selectedspecies = db.Species.SqlQuery(query, sqlparam).FirstOrDefault();

            //return species
            return View(selectedspecies);
        }

        public ActionResult Update(int id)
        {
            //create query
            string query = "select * from species where speciesid = @id";
            SqlParameter sqlparam = new SqlParameter("@id", id);

            Species selectedSpecies = db.Species.SqlQuery(query, sqlparam).FirstOrDefault();

            //return species
            return View(selectedSpecies);
        }

        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            //debug line
            Debug.WriteLine("Editing species name to " + SpeciesName);

            // create query
            string query = "update species set Name=@SpeciesName where speciesid = @id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);
            sqlparams[1] = new SqlParameter("@id", id);
            //execute query
            db.Database.ExecuteSqlCommand(query, sqlparams);
            //go back to list of species
            return RedirectToAction("List");
        }
    }
}