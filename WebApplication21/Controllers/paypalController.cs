using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication21.Models;

namespace WebApplication21.Controllers
{
    public class paypalController : Controller
    {
        context c = new context();
        // GET: paypal
        public ActionResult Index()
        {
            return View();
        }

        private PayPal.Api.Payment payment;
        private Payment CreatePayment(APIContext apicontext, string redirectUrl)
        {
            var mail = (string)Session["customermail"];
            var id1 = c.Customers.Where(x => x.customermail == mail.ToString()).Select(y => y.customerid).FirstOrDefault();
            var value = c.Salemoves.FirstOrDefault(x => x.customerid == id1);

            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = value.products.productsname,
                currency = "USD",
                price = value.saleallprice.ToString(),
                quantity = value.salecount.ToString()


                //name = "Item Name comes here",
                //currency = "USD",
                //price = "1",
                //quantity = "1",
                //sku = "sku"


                //name = c.Salemoves.Where(x => x.customerid == id1).ToList().Select(y => y.products.productsname).FirstOrDefault().ToString(),
                //price = c.Salemoves.Where(x => x.customerid == id1).ToList().Select(y => y.saleallprice).FirstOrDefault().ToString(),
                //quantity = c.Salemoves.Where(x => x.customerid == id1).ToList().Select(y => y.salecount).FirstOrDefault().ToString()

            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                //subtotal = value.saleallprice.ToString()
                subtotal="1"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = details.subtotal, // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            
            // Create a payment using a APIContext  
            return payment.Create(apicontext);
        }
        private Payment ExecutePayment(APIContext apicontext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment()
            {
                id = paymentId
            };
            return this.payment.Execute(apicontext, paymentExecution);
        } 
        public ActionResult PaymentWithPaypal(string Cancel = null)
        {
            //getting the apiContext  
            APIContext aPIContext = paypalconfig.GetAPIContext();
            try
            {
                //A resource representing a Payer that funds a payment Payment Method as paypal  
                //Payer Id will be returned when payment proceeds or click to pay  
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //this section will be executed first because PayerID doesn't exist  
                    //it is returned by the create function call of the payment class  
                    // Creating a payment  
                    // baseURL is the url on which paypal sendsback the data.  
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPal?"; ;
                    //here we are generating guid for storing the paymentID received in session  
                    //which will be used in the payment execution  
                    var guid = Convert.ToString((new Random()).Next(100000));
                    //CreatePayment function gives us the payment approval url  
                    //on which payer is redirected for paypal account payment  
                    var createdPayment = CreatePayment(aPIContext, baseURI + "guid=" + guid);
                    //get links returned from paypal in response to Create function call  
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = null;
                    while (links.MoveNext())
                    {
                        Links lnk = links.Current;
                        if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            //saving the payapalredirect URL to which user will be redirected for payment  
                            paypalRedirectUrl = lnk.href;
                        }
                    }
                    // saving the paymentID in the key guid  
                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    // This function exectues after receving all parameters for the payment  
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(aPIContext, payerId, Session[guid] as string);
                    //If executed payment failed then we will show payment failure message to user  
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("failure");
                    }
                }
            }
            catch (Exception ex)
            {
                //paypalconfiguration.Log("Error:" + ex.Message);
                return View("failure");
            }
            //on successful payment, show success page to user.  
            return View("SuccessView");
        }
        
        
       
        
        public ActionResult SuccessView()
        {
            return View();
        }
        public ActionResult failure()
        {
            return View();
        }
    }
}