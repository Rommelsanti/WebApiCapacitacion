using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiCapacitacion.Models.Entities
{
	public class EMPLEADOS
	{

		[Key]
		public int EMP_ID { get; set; }
		public string EMP_NOMBRE { get; set; }
		public string EMP_DIRECCION { get; set; }
		public string EMP_TELEFONO { get; set; }
		public string EMP_CEDULA { get; set; }

		public virtual ICollection<CARGAS_FAMILIARES> CARGAS_FAMILIARES { get; set; }
	}
}