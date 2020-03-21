using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModelLibrary
{
    public class BookingModel
    {
        string roomName, timeSlot, statusOfRoom;
        bool checkedIn;
        int userId;

        public string RoomName { get => roomName; set => roomName = value; }
        public string TimeSlot { get => timeSlot; set => timeSlot = value; }
        public string StatusOfRoom { get => statusOfRoom; set => statusOfRoom = value; }
        public bool CheckedIn { get => checkedIn; set => checkedIn = value; }
        public int UserId { get => userId; set => userId = value; }
    }
}
