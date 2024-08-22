using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IInvoiceDal : IGenericDal<Invoice_Detail>
    {
        Invoice_Detail MaxAmountByCusID(int cusID);

        int CurrentDebt(int cusID);

    }
}
