using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestinoWebApi.Models
{
    // A class named "Bus" having followoing members:BusStopId, BusStopName, BusStopLongitude & BusStopLatitude
    public class Bus
    {
        public string BusStopId
        {
            get;
            set;
        }
        public string BusStopName
        {
            get;
            set;
        }
        public string BusStopLongitude
        {
            get;
            set;
        }
        public string BusStopLatitude
        {
            get;
            set;
        }
    }
}