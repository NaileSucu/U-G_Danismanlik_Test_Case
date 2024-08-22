using DataAccessLayer.Abstract;
using DataAccessLayer.Conrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfInvoicesDal : GenericRepository<Invoice_Detail>, IInvoiceDal
    {
        public int CurrentDebt(int cusID)
        {
            using var context = new Context();
            var invoices= context.Set<Invoice_Detail>().ToList().Where(x => x.CustomerId == cusID);
            var sumDebt = invoices.Sum(x => x.InvoiceAmount);
            var paidDebt = invoices.Where(x => x.PaymentDate != null).Sum(x => x.InvoiceAmount);
            return (int)(sumDebt - paidDebt);
        }

        public Invoice_Detail MaxAmountByCusID(int cusID)
        {
            using var context = new Context();
            var maxAmount = context.Set<Invoice_Detail>().ToList().Where(x => x.CustomerId == cusID).Max(x=> x.InvoiceAmount);
            return context.Set<Invoice_Detail>()
                                 .Where(i => i.CustomerId == cusID && i.InvoiceAmount == maxAmount).First();
        }

    }
}
