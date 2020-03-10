using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DestinoWebApi.Models
{
    // A class named "Train" having followoing members:TrainStopId,TrainStopName,TrainStopTime & TrainStopLine
    public class Train
    {
        public string TrainStopId
        {
            get;
            set;
        }
        public string TrainStopName
        {
            get;
            set;
        }
        public string TrainStopTime
        {
            get;
            set;
        }
        public string TrainStopLine
        {
            get;
            set;
        }
    }
}