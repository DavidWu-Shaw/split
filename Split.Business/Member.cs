using System.Collections.Generic;
using System.Linq;
using System;

namespace Split.Business
{
    public class Member
    {
        private decimal? totalAmount;
        public IList<decimal> Charges { get; set; }
        public decimal AmountDue { get; private set; }

        public decimal TotalAmount
        {
            get
            {
                if (!totalAmount.HasValue)
                {
                    totalAmount = Charges.Sum();
                }

                return totalAmount.Value;
            }
        }

        public Member()
        {
            Charges = new List<decimal>();
        }

        public void AddCharge(decimal charge)
        {
            if (charge < 0.0m)
            {
                throw new ArgumentException("Invalid value.");
            }
            Charges.Add(charge);
        }

        public void CaculateAmountDue(decimal averageAmount)
        {
            AmountDue = averageAmount - TotalAmount;
        }

        public string OutputString()
        {
            return string.Format("{0:C}", AmountDue);
        }
    }
}
