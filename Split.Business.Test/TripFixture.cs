using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Split.Business.Test
{
    [TestClass]
    public class TripFixture
    {
        [TestMethod]
        public void AddMember_ZeroMember_AddOneMember_ShouldReturn_1()
        {
            Trip instance = new Trip();

            instance.AddMember(new Member());

            Assert.AreEqual(1, instance.Members.Count);
        }

        [TestMethod]
        public void AddMember_TwoMembers_AddOneMember_ShouldReturn_3()
        {
            Trip instance = new Trip();
            instance.AddMember(new Member());
            instance.AddMember(new Member());

            instance.AddMember(new Member());

            Assert.AreEqual(3, instance.Members.Count);
        }

        [TestMethod]
        public void CaculateAmountDue_WithTwoMembersSpendTheSameAmount_ShouldReturnAmountDue_0()
        {
            Trip instance = new Trip();
            Member member1 = new Member() { Charges = new List<decimal> { 2.0m, 4.0m } };
            Member member2 = new Member() { Charges = new List<decimal> { 1.0m, 2.0m, 3.0m } };
            instance.AddMember(member1);
            instance.AddMember(member2);

            instance.CaculateAmountDue();

            Assert.AreEqual(0, member1.AmountDue);
            Assert.AreEqual(0, member2.AmountDue);
        }

        [TestMethod]
        public void CaculateAmountDue_ShouldReturnCorrectAmountDue()
        {
            Trip instance = new Trip();
            Member member1 = new Member() { Charges = new List<decimal> { 2.0m, 4.0m } };
            Member member2 = new Member() { Charges = new List<decimal> { 10.0m, 2.0m, 3.2m } };
            instance.AddMember(member1);
            instance.AddMember(member2);

            instance.CaculateAmountDue();

            Assert.AreEqual(4.6m, member1.AmountDue);
            Assert.AreEqual(-4.6m, member2.AmountDue);
        }
    }
}
