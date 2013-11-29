using System;
using System.ComponentModel;
using System.Collections.Generic;
using Restcoration;
using RestSharp;
using Newtonsoft.Json; 
namespace BluePOCO 
{		
		
    

	[Rest(Resource = "/users/register",Method = Method.POST, OK = typeof(UsersRegister200), Conflict = typeof(UsersRegister409))]
	    