using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DestinoWebApi.Models;
namespace DestinoWebApi.Controllers
{
    public class BusController : ApiController
    {
        //List of objects related to class type Bus and assigning values to the members
        IList<Bus> busStops = new List<Bus>()
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

        //Method to generate response of all bus stops in XML format
        public IList<Bus> GetAllBusStops()
        {
            //Return list of all bus stops  
            return busStops;
        }

        //Method to generate response of a single bus stop in  XML format, that is searched by the user
        public Bus GetBusStopDetails(String name)
        {
            //Return a single bus stop detail  
            var busstop = busStops.FirstOrDefault(e => e.BusStopName == name);
            if (busstop == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return busstop;
        }
    }
}
