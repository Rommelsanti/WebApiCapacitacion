using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiCapacitacion.Models;
using WebApiCapacitacion.Models.Entities;

namespace WebApiCapacitacion.Controllers.webApi
{
    public class EnvioEmpleadosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EnvioEmpleados
        public IHttpActionResult GetEMPLEADOS()
        {
			db.Configuration.LazyLoadingEnabled = false;
			db.Configuration.ProxyCreationEnabled = false;
            return Json(db.EMPLEADOS.ToList());
        }

        // GET: api/EnvioEmpleados/5
        [ResponseType(typeof(EMPLEADOS))]
        public IHttpActionResult GetEMPLEADOS(int id)
        {
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADOS);
        }

        // PUT: api/EnvioEmpleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLEADOS(int id, EMPLEADOS eMPLEADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADOS.EMP_ID)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADOSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EnvioEmpleados
        [ResponseType(typeof(EMPLEADOS))]
        public IHttpActionResult PostEMPLEADOS(EMPLEADOS eMPLEADOS)
        {
			int ID = eMPLEADOS.EMP_ID;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
			eMPLEADOS.EMP_ID = 0;
			foreach (var item in eMPLEADOS.CARGAS_FAMILIARES)
			{
				item.CARFAM_ID = 0;
				item.EMP_ID = 0;
			}

            db.EMPLEADOS.Add(eMPLEADOS);
            db.SaveChanges();

            return Json(ID);
        }

        // DELETE: api/EnvioEmpleados/5
        [ResponseType(typeof(EMPLEADOS))]
        public IHttpActionResult DeleteEMPLEADOS(int id)
        {
            EMPLEADOS eMPLEADOS = db.EMPLEADOS.Find(id);
            if (eMPLEADOS == null)
            {
                return NotFound();
            }

            db.EMPLEADOS.Remove(eMPLEADOS);
            db.SaveChanges();

            return Ok(eMPLEADOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADOSExists(int id)
        {
            return db.EMPLEADOS.Count(e => e.EMP_ID == id) > 0;
        }
    }
}