using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IInvoiceDetailService : IGenericService<Invoice_Detail>
    {
        Invoice_Detail MaxAmountByCusID(int cusID);
        int CurrentDebt(int cusID);


    }
}
