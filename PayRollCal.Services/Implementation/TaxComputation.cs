using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCal.Services.Implementation
{
    public class TaxComputation:ITaxService
    {
        private decimal taxRate;
        private decimal taX;
        public decimal TaxAmount(decimal totalAmount)
        {
            if (totalAmount <= 18200.00m)
            {
                //tax free rate
                taxRate = 0.0m;
                taX = totalAmount * taxRate;
            }
            else if (totalAmount >= 18201.00m && totalAmount <= 37000.00m)
            {
                taxRate = 0.19m;
                taX = (totalAmount - 18201.00m) * taxRate;
            }
            else if (totalAmount >= 37001.00m && totalAmount <= 90000.00m)
            {
                taxRate = 0.325m;
                taX = ((totalAmount - 37001.00m) * taxRate) + 3572.00m;
            }
            else if (totalAmount >= 90001.00m && totalAmount <= 180000.00m)
            {
                taxRate = 0.37m;
                taX = ((totalAmount - 90001.00m) * taxRate) + 20797.00m;
            }
            else if (totalAmount >= 180001.00m)
            {
                taxRate = 0.45m;
                taX = ((totalAmount - 180001.00m) * taxRate) + 54097.00m;
            }
            return taX;
        }
    }
}
