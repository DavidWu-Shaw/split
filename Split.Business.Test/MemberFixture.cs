using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Split.Business.Test
{
    [TestClass]
    public class MemberFixture
    {
        [TestMethod]
        public void AddCharge_ZeroCharges_AddOneCharge_ShouldReturn_1()
        {
            Member instance = new Member();

            instance.AddCharge(1.0m);

            Assert.AreEqual(1, instance.Charges.Count);
        }

        [TestMethod]
        public void AddCharge_TwoCharges_AddOneCharge_ShouldReturn_3()
        {
            Member instance = new Member();
            instance.AddCharge(1.0m);
            instance.AddCharge(1.0m);

            instance.AddCharge(4.0m);

            Assert.AreEqual(3, instance.Charges.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCharge_MinusValue_ShouldThrowArgumentException()
        {
            Member instance = new Member();
            instance.AddCharge(-1.0m);
        }

        [TestMethod]
        public void TotalAmount_ShouldReturn_Sum()
        {
            Member instance = new Member();
            instance.AddCharge(1.0m);
            instance.AddCharge(2.0m);
            instance.AddCharge(3.0m);

            decimal totalAmount = instance.TotalAmount;

            Assert.AreEqual(6.0m, totalAmount);
        }

        [TestMethod]
        public void CaculateAmountDue_ShouldReturn_DifferencesBetweenTotalAndAverage()
        {
            Member instance = new Member();
            instance.AddCharge(1.0m);
            instance.AddCharge(2.0m);
            instance.AddCharge(3.0m);

            decimal averageAmount = 8.0m;
            instance.CaculateAmountDue(averageAmount);

            Assert.AreEqual(2.0m, instance.AmountDue);
        }
    }
}
