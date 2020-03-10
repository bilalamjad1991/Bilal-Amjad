using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DestinoWebApiJS.Models;

namespace DestinoWebApiJS.Controllers
{
    public class BusController : Controller
    {
        //List of objects related to class type Bus and assigning values to the members
        List<Bus> busStops = new List<Bus>()
        {
            new Bus()
                {
                    BusStopId = "NSR:StopPlace:27249", BusStopName = "Stavanger politistasjon", BusStopLongitude = "5.735578", BusStopLatitude = "58.963231"
                },
                new Bus()
                {
                    BusStopId = "NSR:StopPlace:27252", BusStopName = "Stavanger stadion", BusStopLongitude = "5.713007", BusStopLatitude = "58.964989"
                },
                new Bus()
                {
                    BusStopId = "NSR:StopPlace:27258", BusStopName = "Stavanger turnhall", BusStopLongitude = "5.691968", BusStopLatitude = "58.954365"
                },
                new Bus()
                {
                    BusStopId = "NSR:StopPlace:27261", BusStopName = "Stavangergata", BusStopLongitude = "5.285832", BusStopLatitude = "59.41025"
                },
                new Bus()
                {
                    BusStopId = "NSR:StopPlace:27576", BusStopName = "Stavanger legevakt", BusStopLongitude = "5.729164", BusStopLatitude = "58.953242"
                },
        };

        //Method to generate response of all bus stops in JSON format
        public JsonResult AllBusStopsData()
        {
            return Json(busStops, JsonRequestBehavior.AllowGet);
        }

        //Method to generate response of a single bus stop in  JSON format, that is searched by the user
        public JsonResult BusStopData(String name)
        {
            var busstop = busStops.FirstOrDefault(e => e.BusStopName == name);

            return Json(busstop, JsonRequestBehavior.AllowGet);
        }
    }
}