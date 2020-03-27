using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiCapacitacion.Models.Entities
{
	public class CARGAS_FAMILIARES
	{
		[Key]
		public int CARFAM_ID {get; set; }
		public String CARFAM_NOMBRE { get; set; }
		public int EMP_ID { get; set; }


		public virtual EMPLEADOS EMPLEADOS { get; set; }
	}
}