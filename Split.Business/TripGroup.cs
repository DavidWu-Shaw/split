using System.Collections.Generic;
using System.IO;

namespace Split.Business
{
    public class TripGroup
    {
        private IList<Trip> Trips { get; set; }

        public TripGroup()
        {
            Trips = new List<Trip>();
        }

        public void AddTrip(Trip trip)
        {
            Trips.Add(trip);
        }

        public void Calculate()
        {
            foreach (Trip trip in Trips)
            {
                trip.CaculateAmountDue();
            }
        }

        public void Output(StreamWriter streamWriter)
        {
            foreach (Trip trip in Trips)
            {
                trip.Output(streamWriter);
                streamWriter.WriteLine();
            }
        }
    }
}
