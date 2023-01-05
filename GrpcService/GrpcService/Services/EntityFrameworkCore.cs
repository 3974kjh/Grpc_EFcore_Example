using GrpcService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
	public class EntityFrameworkCore
	{
		public EntityFrameworkCore()
		{
		}

		public PntInfoResponce GetPatientInfo(PntInfoRequest request)
		{
			MyDbContext db = new MyDbContext();
			PntInfoResponce result = new PntInfoResponce();

			var emps = db.PatientInfo.Where(p => p.ID == request.PatientID);

			foreach (var item in emps)
			{
				result.Id = item.ID;
				result.Age = item.Age;
				result.Name = item.Name;
				result.PhoneNumber = item.PhoneNumber;
			}

			return result;
		}

		public bool AddTable(PntInfoResponce responce)
		{
			bool check = false;

			try
			{
				MyDbContext db = new MyDbContext();

				PatientInfoData patientInfo = new PatientInfoData
				{
					Name = responce.Name,
					Age = responce.Age,
					PhoneNumber = responce.PhoneNumber
				};

				db.PatientInfo.Add(patientInfo);
				db.SaveChanges();

				check = true;
			}
			catch (Exception e)
			{
			}
			return check;
		}

		public bool UpdateTable(PntInfoResponce responce)
		{
			bool check = false;

			try
			{
				MyDbContext db = new MyDbContext();

				PatientInfoData patientInfo = db.PatientInfo.Where(p => p.ID == responce.Id).First();

				patientInfo.Name = responce.Name;
				patientInfo.Age = responce.Age;
				patientInfo.PhoneNumber = responce.PhoneNumber;
				//db.PatientInfo.Update(patientInfo);
				db.SaveChanges();

				check = true;
			}
			catch (Exception e)
			{
			}

			return check;
		}

		public bool DeleteTable(PntInfoRequest request)
		{
			bool check = false;

			try
			{
				MyDbContext db = new MyDbContext();

				PatientInfoData patientInfo = db.PatientInfo.Where(p => p.ID == request.PatientID).First();

				db.PatientInfo.Remove(patientInfo);
				db.SaveChanges();

				check = true;
			}
			catch (Exception e)
			{
			}

			return check;
		}
	}
}
