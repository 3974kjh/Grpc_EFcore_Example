using System;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
	class Program
	{
		static void Main(string[] args)
		{
			var channel = GrpcChannel.ForAddress("https://localhost:5003");
			var client = new Greeter.GreeterClient(channel);

			////[Insert]
			//var save = new PntInfoResponce() { Name = "안녕", Age = 28, PhoneNumber = "010-1234-1234" };
			//var save_response = client.SavePatientInfo(save);
			//Console.WriteLine("저장결과 : " + save_response.Check);


			////[Update]
			//var update = new PntInfoResponce() { Id = 6, Name = "안녕", Age = 28, PhoneNumber = "010-1234-1234" };
			//var update_responce = client.UpdatePatientInfo(update);
			//Console.WriteLine("수정결과 : " + update_responce.Check);


			////[Delete]
			//var delete = new PntInfoRequest() { PatientID = 3 };
			//var delete_responce = client.DeletePatientInfo(delete);
			//Console.WriteLine("삭제결과 : " + delete_responce.Check);

			//[Select]
			var select = new PntInfoRequest() { PatientID = 6 };
			var select_responce = client.GetPatientInfoByPntID(select);
			Console.WriteLine($"조회결과 : \nID = {select_responce.Id}\nName = {select_responce.Name}\nAge = {select_responce.Age}\nPhoneNuber = {select_responce.PhoneNumber}");

		}
	}
}
