using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDALLibrary;
using BookingModelLibrary;

namespace BookingBLLibrary
{
    public class BookingBL
    {
        BookingDAL dal;
        public BookingBL()
        {
            dal = new BookingDAL();
        }
        public void CheckIn(BookingModel details)
        {
            dal.CheckIn(details);
        }
        public void CheckOut(BookingModel details)
        {
            dal.CheckOut(details);
        }
        public List<BookingModel> CheckAvailability(string timeSlot)
        {
            return dal.CheckAvailability(timeSlot);
        }
    }
}
