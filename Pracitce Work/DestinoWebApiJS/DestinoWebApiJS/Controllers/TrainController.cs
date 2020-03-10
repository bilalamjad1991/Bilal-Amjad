using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DestinoWebApiJS.Models;

namespace DestinoWebApiJS.Controllers
{
    public class TrainController : Controller
    {
        //List of objects related to class type Train and assigning values to the members
        List<Train> trainStops = new List<Train>()
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

        //Method to generate response of all train stops in JSON format
        public JsonResult AllTrainStopsData()
        {
            return Json(trainStops, JsonRequestBehavior.AllowGet);
        }

        //Method to generate response of a single train stop in  JSON format, that is searched by the user
        public JsonResult TrainStopData(String name)
        {
            var trainstop = trainStops.FirstOrDefault(e => e.TrainStopName == name);

            return Json(trainstop, JsonRequestBehavior.AllowGet);
        }
    }
}