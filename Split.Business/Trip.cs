using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Split.Business
{
    public class Trip
    {
        public IList<Member> Members { get; set; }

        public Trip()
        {
            Members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void CaculateAmountDue()
        {
            // Calculate average amount by members
            decimal average = Members.Average(o => o.TotalAmount);
            // Loop by members to calculate amount due
            foreach (Member member in Members)
            {
                member.CaculateAmountDue(average);
            }
        }

        public void Output(StreamWriter streamWriter)
        {
            foreach (Member member in Members)
            {
                string memberOutput = member.OutputString();
                streamWriter.WriteLine(memberOutput);
            }
        }
    }
}
