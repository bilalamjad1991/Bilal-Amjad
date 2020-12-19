using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DestinoWebApi.Models;
namespace DestinoWebApi.Controllers
{
    public class TrainController : ApiController
    {
        // List of objects related to class type Train and assigning values to the members
        IList<Train> trainStops = new List<Train>()
        {
            new Train()
                {
                    TrainStopId = "NSR:Quay:1146", TrainStopName = "Egersund", TrainStopTime = "2020-01-17T14:10:00+01:00", TrainStopLine = "59"
                },
                new Train()
                {
                    TrainStopId = "NSR:Quay:1145", TrainStopName = "Stavanger", TrainStopTime = "2020-01-17T14:14:00+01:00", TrainStopLine = "59"
                },
                new Train()
                {
                    TrainStopId = "NSR:Quay:1146", TrainStopName = "Skeiane", TrainStopTime = "2020-01-17T14:25:00+01:00", TrainStopLine = "59"
                },
                new Train()
                {
                    TrainStopId = "NSR:Quay:1145", TrainStopName = "Stavanger", TrainStopTime = "2020-01-17T14:29:00+01:00", TrainStopLine = "59"
                },
                new Train()
                {
                    TrainStopId = "NSR:Quay:1146", TrainStopName = "Egersund", TrainStopTime = "2020-01-17T14:40:00+01:00", TrainStopLine = "59"
                },
        };

        //Method to generate response of all train stops in XML format
        public IList<Train> GetAllTrainStops()
        {
            //Return list of all train stops  
            return trainStops;
        }

        //Method to generate response of a single train stop in  XML format, that is searched by the user
        public Train GetTrainStopDetails(String name)
        {
            //Return a single train stop detail  
            var trainstop = trainStops.FirstOrDefault(e => e.TrainStopName == name);
            if (trainstop == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return trainstop;
        }
    }
}
