using Grpc.Core;
using GrpcService.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService
{
	public class GreeterService : Greeter.GreeterBase
	{
		public override Task<PntInfoResponce> GetPatientInfoByPntID(PntInfoRequest request, ServerCallContext context)
		{
			PntInfoResponce output = new PntInfoResponce();

			var EF = new EntityFrameworkCore();

			output = EF.GetPatientInfo(request);

			return Task.FromResult(output);
		}

		public override Task<SaveCheck> SavePatientInfo(PntInfoResponce request, ServerCallContext context)
		{
			SaveCheck saveCheck = new SaveCheck();

			saveCheck.Check = false;

			var EF = new EntityFrameworkCore();

			if (false == EF.AddTable(request))
				return Task.FromResult(saveCheck);

			saveCheck.Check = true;

			return Task.FromResult(saveCheck);
		}

		public override Task<UpdateCheck> UpdatePatientInfo(PntInfoResponce request, ServerCallContext context)
		{
			UpdateCheck updateCheck = new UpdateCheck();

			updateCheck.Check = false;

			var EF = new EntityFrameworkCore();

			if (false == EF.UpdateTable(request))
				return Task.FromResult(updateCheck);

			updateCheck.Check = true;

			return Task.FromResult(updateCheck);
		}

		public override Task<DeleteCheck> DeletePatientInfo(PntInfoRequest request, ServerCallContext context)
		{
			DeleteCheck deleteCheck = new DeleteCheck();

			deleteCheck.Check = false;

			var EF = new EntityFrameworkCore();

			if (false == EF.DeleteTable(request))
				return Task.FromResult(deleteCheck);

			deleteCheck.Check = true;

			return Task.FromResult(deleteCheck);
		}
	}
}
