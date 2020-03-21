using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookingModelLibrary;
using BookingBLLibrary;
using System.Web.Http.Cors;
namespace RoomBookingWebAPI.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]

    public class BookingController : ApiController
    {

        BookingBL bl = new BookingBL();
        // GET: api/Booking
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Booking/5
        public List<BookingModel> Get(string timeSlot)
        {
            return bl.CheckAvailability(timeSlot);
        }

        // POST: api/Booking
        [HttpPost]
         public void Post([FromBody]BookingModel Details)
        {
            bl.CheckIn(Details);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete([FromBody]BookingModel Details)
        {
            bl.CheckOut(Details);
        }
    }
}
