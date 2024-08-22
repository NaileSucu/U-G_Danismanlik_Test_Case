using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class InvoiceDetailManager : IInvoiceDetailService
    {
        IInvoiceDal invoiceDal;

        public InvoiceDetailManager(IInvoiceDal invoiceDal)
        {
            this.invoiceDal = invoiceDal;
        }

        public int CurrentDebt(int cusID)
        {
            return invoiceDal.CurrentDebt(cusID);
        }

        public Invoice_Detail GetByID(int id)
        {
            return invoiceDal.GetByID(id);
        }

        public List<Invoice_Detail> GetList()
        {
            return invoiceDal.GetList();
        }
        public Invoice_Detail MaxAmountByCusID(int userID)
        {
            return invoiceDal.MaxAmountByCusID(userID);    
        }

        public void Update(Invoice_Detail t)
        {
            invoiceDal.Update(t);
        }

    }
}
