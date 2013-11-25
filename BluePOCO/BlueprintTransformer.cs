using System.ComponentModel;
using Restcoration;
using RestSharp;
using Newtonsoft.Json; 
namespace BluePOCO 
{		
		

	[Rest(Method = Method.POST, OK = typeof(UsersRegister200), Conflict = typeof(UsersRegister409))]
	