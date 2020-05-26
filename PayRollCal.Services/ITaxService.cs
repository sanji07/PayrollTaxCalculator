using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCal.Services
{
    public interface ITaxService
    {
        decimal TaxAmount(decimal totalAmount);
    }
}
