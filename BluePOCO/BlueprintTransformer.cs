using System.ComponentModel;
using Restcoration;
using RestSharp;
namespace BluePOCO 
{

	
	

	[Rest(Method = Method.POST)]
	public class UsersRegisterRequest
	{
	}

	public class UsersRegister200 
	{
	}
	public class UsersRegister409 
	{
	}
		
	

	[Rest(Method = Method.POST)]
	public class UsersLoginRequest
	{
	}

	public class UsersLogin200 
	{
	}
	public class UsersLogin404 
	{
	}
	public class UsersLogin409 
	{
	}
		
	

	[Rest(Method = Method.POST)]
	public class UsersChangepasswordRequest
	{
	}

	public class UsersChangepassword200 
	{
	}
	public class UsersChangepassword404 
	{
	}
		
}