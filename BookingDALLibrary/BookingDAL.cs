using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookingModelLibrary;

namespace BookingDALLibrary
{
    public class BookingDAL
    {
        SqlConnection conn;
        SqlCommand cmdGetRoomAvailability, cmdPostDetails;
        public BookingDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connBooking"].ConnectionString);
        }

        public void CheckIn(BookingModel details)
        {
            conn.Open();
            cmdPostDetails = new SqlCommand("InsertUserBookingData", conn);
            cmdPostDetails.CommandType = CommandType.StoredProcedure;

            cmdPostDetails.Parameters.AddWithValue("@UserId", details.UserId);
            cmdPostDetails.Parameters.AddWithValue("@RoomName", details.RoomName);
            cmdPostDetails.Parameters.AddWithValue("@TimeSlot", details.TimeSlot);
            if (cmdPostDetails.ExecuteNonQuery() > 0)
            {
                details = null;
            }
            conn.Close();
        }
        public List<BookingModel> CheckAvailability(string timeSlot)
        {
            cmdGetRoomAvailability = new SqlCommand("GetAvailability", conn);
            cmdGetRoomAvailability.Parameters.AddWithValue("@TimeSlot", timeSlot);
            cmdGetRoomAvailability.CommandType = CommandType.StoredProcedure;
            conn.Open();
            List<BookingModel> availableRooms = new List<BookingModel>();
            SqlDataReader dataReader = cmdGetRoomAvailability.ExecuteReader();
            BookingModel bookingModel = null;
            while (dataReader.Read())
            {
                bookingModel = new BookingModel();
                bookingModel.RoomName = dataReader[0].ToString();
                bookingModel.StatusOfRoom = dataReader[1].ToString();
                availableRooms.Add(bookingModel);
            }
            conn.Close();
            return availableRooms;

            //cmdGetAllDetails = new SqlCommand("proc_GetPersonalDetails", conn);
            //cmdGetAllDetails.CommandType = CommandType.StoredProcedure;
            //List<DetailModel> detailsList = new List<DetailModel>();
            //DetailModel detailModel;
            //SqlDataReader dataReader = cmdGetAllDetails.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    detailModel = new DetailModel();
            //    detailModel.FirstName = dataReader[0].ToString();
            //    detailModel.LastName = dataReader[1].ToString();
            //    detailModel.Age = Convert.ToInt32(dataReader[2]);
            //    detailModel.Gender = dataReader[3].ToString();
            //    detailModel.Nationality = dataReader[4].ToString();
            //    detailsList.Add(detailModel);

            //}
            //conn.Close();
            //return detailsList;

        }
        public void CheckOut(BookingModel details)
        {
            conn.Open();
            cmdPostDetails = new SqlCommand("CheckOutAnUser", conn);
            cmdPostDetails.CommandType = CommandType.StoredProcedure;

            cmdPostDetails.Parameters.AddWithValue("@UserId", details.UserId);
            cmdPostDetails.Parameters.AddWithValue("@RoomName", details.RoomName);
            cmdPostDetails.Parameters.AddWithValue("@TimeSlot", details.TimeSlot);
            if (cmdPostDetails.ExecuteNonQuery() > 0)
            {
                details = null;
            }
            conn.Close();
        }
    }
}
