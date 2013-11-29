using System;
using System.ComponentModel;
using System.Collections.Generic;
using Restcoration;
using RestSharp;
using Newtonsoft.Json; 
namespace BluePOCO 
{		
		
    

	[Rest(Resource = "/users/register",Method = Method.POST, OK = typeof(UsersRegister200), Conflict = typeof(UsersRegister409))]
	        public class UsersRegisterRequest
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

    }

    		    public class UsersRegister200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


		    public class UsersRegister409
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }


			
		
    

	[Rest(Resource = "/users/login",Method = Method.POST, OK = typeof(UsersLogin200), NotFound = typeof(UsersLogin404), Conflict = typeof(UsersLogin409))]
	        public class UsersLoginRequest
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }

    		    public class UsersLogin200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("lastlogin")]
        public DateTime Lastlogin { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

    }


		    public class UsersLogin404
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }


		    public class UsersLogin409
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }


			
		
    

	[Rest(Resource = "/users/changepassword",Method = Method.POST, OK = typeof(UsersChangepassword200), NotFound = typeof(UsersChangepassword404))]
	        public class UsersChangepasswordRequest
    {

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

    }

    		    public class UsersChangepassword200
    {

    }


		    public class UsersChangepassword404
    {

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }


			
		
    

	[Rest(Resource = "/customer/{customerid}/range/",Method = Method.GET, OK = typeof(CustomerCustomeridRange200))]
	    
        public class CustomerCustomeridRangeRequest
        {
            public CustomerCustomeridRangeRequest(string customerid)
            {
                                CustomerId = customerid;
                            }
            
                        [JsonProperty("customerid")]
public string CustomerId { get; set; }
                    }
    
    		    public class CustomerCustomeridRange200
    {
        public class Issue
        {

            [JsonProperty("IssueNo")]
            public string IssueNo { get; set; }

            [JsonProperty("CopyNo")]
            public string CopyNo { get; set; }

            [JsonProperty("PublicationDate")]
            public DateTime PublicationDate { get; set; }

            [JsonProperty("PackStatus")]
            public string PackStatus { get; set; }

            [JsonProperty("DemandQty")]
            public int DemandQty { get; set; }

            [JsonProperty("ExtrasOrderable")]
            public bool ExtrasOrderable { get; set; }
        }

        public class Variant
        {

            [JsonProperty("VariantType")]
            public string VariantType { get; set; }

            [JsonProperty("StdOrdQty")]
            public int StdOrdQty { get; set; }

            [JsonProperty("issues")]
            public IList<Issue> Issues { get; set; }
        }

        public class Title
        {

            [JsonProperty("TitleNo")]
            public string TitleNo { get; set; }

            [JsonProperty("Mandatory")]
            public bool Mandatory { get; set; }

            [JsonProperty("variants")]
            public IList<Variant> Variants { get; set; }
        }

        public class Range2
        {

            [JsonProperty("titles")]
            public IList<Title> Titles { get; set; }

            [JsonProperty("titleCount")]
            public int TitleCount { get; set; }
        }


        [JsonProperty("range")]
        public Range2 Range { get; set; }

        [JsonProperty("messages")]
        public IList<object> Messages { get; set; }

    }


			
		
    

	[Rest(Resource = "/customer/{customerid}/range/{titleid}",Method = Method.GET, OK = typeof(CustomerCustomeridRangeTitleid200))]
	    
        public class CustomerCustomeridRangeTitleidRequest
        {
            public CustomerCustomeridRangeTitleidRequest(string customerid, string titleid)
            {
                                CustomerId = customerid;
                                TitleId = titleid;
                            }
            
                        [JsonProperty("customerid")]
public string CustomerId { get; set; }
                        [JsonProperty("titleid")]
public string TitleId { get; set; }
                    }
    
    		    public class CustomerCustomeridRangeTitleid200
    {
        public class Issue
        {

            [JsonProperty("IssueNo")]
            public string IssueNo { get; set; }

            [JsonProperty("CopyNo")]
            public string CopyNo { get; set; }

            [JsonProperty("PublicationDate")]
            public DateTime PublicationDate { get; set; }

            [JsonProperty("PackStatus")]
            public string PackStatus { get; set; }

            [JsonProperty("DemandQty")]
            public int DemandQty { get; set; }

            [JsonProperty("ExtrasOrderable")]
            public bool ExtrasOrderable { get; set; }
        }

        public class Variant
        {

            [JsonProperty("VariantType")]
            public string VariantType { get; set; }

            [JsonProperty("StdOrdQty")]
            public int StdOrdQty { get; set; }

            [JsonProperty("issues")]
            public IList<Issue> Issues { get; set; }
        }

        public class Title
        {

            [JsonProperty("TitleNo")]
            public string TitleNo { get; set; }

            [JsonProperty("Mandatory")]
            public bool Mandatory { get; set; }

            [JsonProperty("variants")]
            public IList<Variant> Variants { get; set; }
        }

        public class Range2
        {

            [JsonProperty("titles")]
            public IList<Title> Titles { get; set; }

            [JsonProperty("titleCount")]
            public int TitleCount { get; set; }
        }


        [JsonProperty("range")]
        public Range2 Range { get; set; }

        [JsonProperty("messages")]
        public IList<object> Messages { get; set; }

    }


			
		
    

	[Rest(Resource = "/customer/{customerid}/range/{productType}",Method = Method.GET, OK = typeof(CustomerCustomeridRangeProductType200))]
	    
        public class CustomerCustomeridRangeProductTypeRequest
        {
            public CustomerCustomeridRangeProductTypeRequest(string customerid, string productType)
            {
                                CustomerId = customerid;
                                ProductType = productType;
                            }
            
                        [JsonProperty("customerid")]
public string CustomerId { get; set; }
                        [JsonProperty("productType")]
public string ProductType { get; set; }
                    }
    
    		    public class CustomerCustomeridRangeProductType200
    {
        public class Issue
        {

            [JsonProperty("IssueNo")]
            public string IssueNo { get; set; }

            [JsonProperty("CopyNo")]
            public string CopyNo { get; set; }

            [JsonProperty("PublicationDate")]
            public DateTime PublicationDate { get; set; }

            [JsonProperty("PackStatus")]
            public string PackStatus { get; set; }

            [JsonProperty("DemandQty")]
            public int DemandQty { get; set; }

            [JsonProperty("ExtrasOrderable")]
            public bool ExtrasOrderable { get; set; }
        }

        public class Variant
        {

            [JsonProperty("VariantType")]
            public string VariantType { get; set; }

            [JsonProperty("StdOrdQty")]
            public int StdOrdQty { get; set; }

            [JsonProperty("issues")]
            public IList<Issue> Issues { get; set; }
        }

        public class Title
        {

            [JsonProperty("TitleNo")]
            public string TitleNo { get; set; }

            [JsonProperty("Mandatory")]
            public bool Mandatory { get; set; }

            [JsonProperty("variants")]
            public IList<Variant> Variants { get; set; }
        }

        public class Range2
        {

            [JsonProperty("titles")]
            public IList<Title> Titles { get; set; }

            [JsonProperty("titleCount")]
            public int TitleCount { get; set; }
        }


        [JsonProperty("range")]
        public Range2 Range { get; set; }

        [JsonProperty("messages")]
        public IList<object> Messages { get; set; }

    }


			
		
    

	[Rest(Resource = "/titles",Method = Method.GET, OK = typeof(Titles200))]
	    
        public class TitlesRequest
        {
            public TitlesRequest()
            {
                            }
            
                    }
    
    		    public class Titles200
    {

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleText")]
        public string TitleText { get; set; }

        [JsonProperty("productType")]
        public string ProductType { get; set; }

    }


			
		
    

	[Rest(Resource = "/titles/{id}",Method = Method.GET, OK = typeof(TitlesId200))]
	    
        public class TitlesIdRequest
        {
            public TitlesIdRequest(string id)
            {
                                Id = id;
                            }
            
                        [JsonProperty("id")]
public string Id { get; set; }
                    }
    
    		    public class TitlesId200
    {

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("titleText")]
        public string TitleText { get; set; }

        [JsonProperty("productType")]
        public string ProductType { get; set; }

    }


			
		
    

	[Rest(Resource = "/admin/orders/contracts",Method = Method.GET, OK = typeof(AdminOrdersContracts200))]
	    
        public class AdminOrdersContractsRequest
        {
            public AdminOrdersContractsRequest()
            {
                            }
            
                    }
    
    		    public class AdminOrdersContracts200
    {
        public class Customer2
        {

            [JsonProperty("id")]
            public int Id { get; set; }
        }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("customer")]
        public Customer2 Customer { get; set; }

    }


			
		
    

	[Rest(Resource = "/admin/search/orders/contracts/{search}",Method = Method.GET, OK = typeof(AdminSearchOrdersContractsSearch200))]
	    
        public class AdminSearchOrdersContractsSearchRequest
        {
            public AdminSearchOrdersContractsSearchRequest(string search)
            {
                                Search = search;
                            }
            
                        [JsonProperty("search")]
public string Search { get; set; }
                    }
    
    		    public class AdminSearchOrdersContractsSearch200
    {
        public class Customer2
        {

            [JsonProperty("id")]
            public int Id { get; set; }
        }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("customer")]
        public Customer2 Customer { get; set; }

    }


			
		
    

	[Rest(Resource = "/admin/orders/contracts/{id}",Method = Method.GET, OK = typeof(AdminOrdersContractsId200))]
	    
        public class AdminOrdersContractsIdRequest
        {
            public AdminOrdersContractsIdRequest(string id)
            {
                                Id = id;
                            }
            
                        [JsonProperty("id")]
public string Id { get; set; }
                    }
    
    		    public class AdminOrdersContractsId200
    {
        public class Customer2
        {

            [JsonProperty("id")]
            public int Id { get; set; }
        }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("customer")]
        public Customer2 Customer { get; set; }

    }


			
		
    

	[Rest(Resource = "/orders/contracts",Method = Method.DELETE, NoContent = typeof(OrdersContracts204))]
	    
        public class OrdersContractsRequest
        {
            public OrdersContractsRequest()
            {
                            }
            
                    }
    
    		public class OrdersContracts204{}

			
		
    

	[Rest(Resource = "/orders/contracts/{id}",Method = Method.POST, Created = typeof(OrdersContractsId201))]
	        public class OrdersContractsIdRequest
    {

        [JsonProperty("title")]
        public string Title { get; set; }

    }

    		    public class OrdersContractsId201
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

    }


			
		
    

	[Rest(Resource = "/orders/standing",Method = Method.DELETE, NoContent = typeof(OrdersStanding204))]
	    
        public class OrdersStandingRequest
        {
            public OrdersStandingRequest()
            {
                            }
            
                    }
    
    		public class OrdersStanding204{}

			
		
    

	[Rest(Resource = "/orders/demand",Method = Method.GET, OK = typeof(OrdersDemand200))]
	    
        public class OrdersDemandRequest
        {
            public OrdersDemandRequest()
            {
                            }
            
                    }
    
    		    public class OrdersDemand200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/orders/changing",Method = Method.GET, OK = typeof(OrdersChanging200))]
	    
        public class OrdersChangingRequest
        {
            public OrdersChangingRequest()
            {
                            }
            
                    }
    
    		    public class OrdersChanging200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/claims/deliveries",Method = Method.GET, OK = typeof(ClaimsDeliveries200))]
	    
        public class ClaimsDeliveriesRequest
        {
            public ClaimsDeliveriesRequest()
            {
                            }
            
                    }
    
    		    public class ClaimsDeliveries200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/claims/deliveries/{id}",Method = Method.POST, Created = typeof(ClaimsDeliveriesId201))]
	        public class ClaimsDeliveriesIdRequest
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }

    		    public class ClaimsDeliveriesId201
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/claims/returns",Method = Method.DELETE, NoContent = typeof(ClaimsReturns204))]
	    
        public class ClaimsReturnsRequest
        {
            public ClaimsReturnsRequest()
            {
                            }
            
                    }
    
    		public class ClaimsReturns204{}

			
		
    

	[Rest(Resource = "/claims/returns/{id}",Method = Method.POST, Created = typeof(ClaimsReturnsId201))]
	        public class ClaimsReturnsIdRequest
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }

    		    public class ClaimsReturnsId201
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/documents/deliveries",Method = Method.DELETE, NoContent = typeof(DocumentsDeliveries204))]
	    
        public class DocumentsDeliveriesRequest
        {
            public DocumentsDeliveriesRequest()
            {
                            }
            
                    }
    
    		public class DocumentsDeliveries204{}

			
		
    

	[Rest(Resource = "/documents/credits",Method = Method.GET, OK = typeof(DocumentsCredits200))]
	    
        public class DocumentsCreditsRequest
        {
            public DocumentsCreditsRequest()
            {
                            }
            
                    }
    
    		    public class DocumentsCredits200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/documents/allocations",Method = Method.GET, OK = typeof(DocumentsAllocations200))]
	    
        public class DocumentsAllocationsRequest
        {
            public DocumentsAllocationsRequest()
            {
                            }
            
                    }
    
    		    public class DocumentsAllocations200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/documents/finaldeliveries",Method = Method.GET, OK = typeof(DocumentsFinaldeliveries200))]
	    
        public class DocumentsFinaldeliveriesRequest
        {
            public DocumentsFinaldeliveriesRequest()
            {
                            }
            
                    }
    
    		    public class DocumentsFinaldeliveries200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


			
		
    

	[Rest(Resource = "/documents/invoices",Method = Method.GET, OK = typeof(DocumentsInvoices200))]
	    
        public class DocumentsInvoicesRequest
        {
            public DocumentsInvoicesRequest()
            {
                            }
            
                    }
    
    		    public class DocumentsInvoices200
    {

        [JsonProperty("id")]
        public int Id { get; set; }

    }


		
}