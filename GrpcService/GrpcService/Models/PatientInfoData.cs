using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Models
{
	[Table("PatientInfo")]
	public class PatientInfoData
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string PhoneNumber { get; set; }
	}
}