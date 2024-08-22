using BusinessLayer.Concrete;
using DataAccessLayer.Conrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using U_G_Danismanlik_Test_Case.Models;

namespace U_G_Danismanlik_Test_Case.Controllers
{
    public class InvoiceController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        InvoiceDetailManager InvoiceDetailManager = new InvoiceDetailManager(new EfInvoicesDal());
        
        [HttpGet]
        public IActionResult Index()
        {
            InvoiceViewModels ınvoiceViewModels = new InvoiceViewModels()
            {
                Customers = customerManager.GetList(),
                Invoices = InvoiceDetailManager.GetList(),
            };

            return View(ınvoiceViewModels);
        }
        [HttpPost]
        public IActionResult Index(int cusID)
        {
            if (cusID > 0)
            {
                var model = new InvoiceViewModels()
                {
                    Customers = customerManager.GetList(),
                    Invoices = InvoiceDetailManager.GetList()
                        .Where(i => i.CustomerId == cusID)
                        .ToList()
                };

                ViewBag.SelectedCustomerID = cusID;
                ViewBag.MaxPaymentAmountDate = InvoiceDetailManager.MaxAmountByCusID(cusID).InvoiceDate;
                ViewBag.MaxPaymentAmount = InvoiceDetailManager.MaxAmountByCusID(cusID).InvoiceAmount;
                ViewBag.RemaingDebt = InvoiceDetailManager.CurrentDebt(cusID);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public IActionResult UpdateInvoice(int id)
        {
            var updateVal = InvoiceDetailManager.GetByID(id);
            updateVal.PaymentDate = DateTime.Now;
            InvoiceDetailManager.Update(updateVal);
            return RedirectToAction("Index");
        }

    }
}
