using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task11.Models;
using task11.Util;
using static task11.Models.Event;

namespace task11.Repositorty
{
    internal class BookingSystemRepository : IBookingSystemRepository
    {


        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public BookingSystemRepository()
        {

            sqlconnection = new SqlConnection(DBConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }


        public bool create_event(Event newEvent)
        {
            cmd.Connection = sqlconnection;
            sqlconnection.Open();




            cmd.CommandText = "INSERT INTO Event(event_id, event_name, event_date, event_time, Venue_id, Total_seats, Ticket_price, Event_type) VALUES (@event_id, @event_name, @event_date, @event_time, @Venue_id, @Total_seats, @Ticket_price, @Event_type)";
            {
                cmd.Parameters.AddWithValue("@event_id", newEvent.EventId);
                cmd.Parameters.AddWithValue("@event_name", newEvent.EventName);
                cmd.Parameters.AddWithValue("@event_date", newEvent.EventDate);
                cmd.Parameters.AddWithValue("@event_time", newEvent.EventTime);
                cmd.Parameters.AddWithValue("@Venue_id", newEvent.VenueId);
                cmd.Parameters.AddWithValue("@Total_seats", newEvent.TotalSeats);
                cmd.Parameters.AddWithValue("@Ticket_price", newEvent.TicketPrice);
                cmd.Parameters.AddWithValue("@Event_type", newEvent.EventType.ToString());


                cmd.ExecuteNonQuery();

                return true;

            }
        }


        public int calculate_booking_cost(int numTickets)
        {
            throw new NotImplementedException();
        }
        public Dictionary<int, int> getAvailableNoOfTickets()
        {
            Dictionary<int, int> availableSeatsDictionary = new Dictionary<int, int>();

            cmd.CommandText = "SELECT event_id, available_seats FROM Event";
            cmd.Connection = sqlconnection;
            sqlconnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int eventId = (int)reader["event_id"];
                int availableSeats = reader.IsDBNull(reader.GetOrdinal("available_seats")) ? 0 : (int)reader["available_seats"];

                availableSeatsDictionary.Add(eventId, availableSeats);
            }

            sqlconnection.Close();

            return availableSeatsDictionary;
        }

        public List<Event> getEventDetails()
        {
            List<Event> eventDetails = new List<Event>();


            {
                try
                {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "select * from Event";
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Event newEvent = new Event();
                        newEvent.EventId = (int)reader["event_id"];
                        newEvent.EventName = (string)reader["event_name"];
                        newEvent.EventDate = (DateTime)reader["event_date"];
                        newEvent.EventTime = (TimeSpan)reader["event_time"];
                        newEvent.VenueId = (int)reader["venue_id"];
                        newEvent.TotalSeats = (int)reader["total_seats"];
                        newEvent.AvailableSeats = reader.IsDBNull(reader.GetOrdinal("available_seats")) ? 0 : (int)reader["available_seats"];
                        newEvent.TicketPrice = (decimal)reader["ticket_price"];
                        newEvent.EventType = (eventType)Enum.Parse(typeof(eventType), (string)reader["event_type"]);
                        eventDetails.Add(newEvent);

                    }
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
                finally { sqlconnection.Close(); }
                return eventDetails;
            }

        }


        public bool bookTicket(string eventName, int numTickets, Customer newCustomer)
        {
            try
            {

                {
                    sqlconnection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sqlconnection;

                        // Get the CustomerId from the newCustomer object
                        int customerId = newCustomer.customerID;

                        // Retrieve EventId based on EventName
                        cmd.CommandText = "SELECT EventId FROM Event WHERE EventName = @EventName";
                        cmd.Parameters.AddWithValue("@EventName", eventName);

                        int eventId = 0;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                eventId = (int)reader["EventId"];
                            }
                        }

                        // Check if EventId was found
                        if (eventId == 0)
                        {
                            Console.WriteLine($"Event with name {eventName} not found.");
                            return false;
                        }

                        // Calculate total cost manually
                        cmd.CommandText = "SELECT TicketPrice FROM Event WHERE EventId = @EventId";
                        cmd.Parameters.AddWithValue("@EventId", eventId);

                        decimal ticketPrice = 0;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ticketPrice = (decimal)reader["TicketPrice"];
                            }
                        }

                        decimal totalCost = numTickets * ticketPrice;

                        // Execute SQL code to book tickets
                        cmd.CommandText = "INSERT INTO Booking (EventId, NumTickets, TotalCost, BookingDate, CustomerId) VALUES (@EventId, @NumTickets, @TotalCost, @BookingDate, @CustomerId)";

                        // Add parameters
                        cmd.Parameters.AddWithValue("@EventId", eventId);
                        cmd.Parameters.AddWithValue("@NumTickets", numTickets);
                        cmd.Parameters.AddWithValue("@TotalCost", totalCost);
                        cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);

                        // Execute the SQL command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if any rows were affected
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"{numTickets} ticket(s) booked successfully for event {eventName}. Total cost: {totalCost:C}");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Booking failed. No rows were affected.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

        }

        public bool cancelBooking(int bookingID)
        {


            

                {
                    sqlconnection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sqlconnection;

                        // Retrieve booking details including associated event details
                        cmd.CommandText = "SELECT b.*, e.Total_Seats, e.Available_Seats FROM Booking b " +
                                          "INNER JOIN Event e ON b.Event_Id = e.Event_Id " +
                                          "WHERE b.Booking_Id = @Booking_Id";
                        cmd.Parameters.AddWithValue("@Booking_Id", bookingID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int eventId = (int)reader["Event_Id"];
                                int numTickets = (int)reader["Num_Tickets"];

                                // Update available seats for the associated event
                                int availableSeats = (int)reader["Available_Seats"];
                                availableSeats += numTickets;

                                reader.Close();
                                cmd.Parameters.Clear();
                                cmd.CommandText = "UPDATE Event SET Available_Seats = @Available_Seats WHERE Event_Id = @Event_Id";
                                cmd.Parameters.AddWithValue("@Available_Seats", availableSeats);
                                cmd.Parameters.AddWithValue("@Event_Id", eventId);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Check if available seats were updated successfully
                                if (rowsAffected > 0)
                                {
                                    // Delete the booking record from the database
                                    cmd.Parameters.Clear();
                                    cmd.CommandText = "DELETE FROM Booking WHERE Booking_Id = @Booking_Id";
                                    cmd.Parameters.AddWithValue("@Booking_Id", bookingID);

                                    rowsAffected = cmd.ExecuteNonQuery();

                                    // Check if booking was canceled successfully
                                    return rowsAffected > 0;
                                }
                                else
                                {
                                    Console.WriteLine($"Error updating available seats for event {eventId}. No rows were affected.");
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Booking with ID {bookingID} not found.");
                                return false;
                            }
                        }
                    }
                }
            
            
        }

        public Booking bookingDetail(int bookingID)
        {
           

                {
                    sqlconnection.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sqlconnection;

                        // Retrieve booking details including associated event and customer details
                        cmd.CommandText = "SELECT b.*, e.Event_Name, e.Total_Seats, e.Ticket_Price, " +
                                          "c.Customer_Id, c.Customer_Name, c.Email, c.Phone_Number " +
                                          "FROM Booking b " +
                                          "INNER JOIN Event e ON b.Event_id = e.Event_id " +
                                          "INNER JOIN Booking cb ON b.Booking_id = cb.Booking_id " +
                                          "INNER JOIN Customer c ON cb.Customer_Id = c.Customer_Id " +
                                          "WHERE b.Booking_Id = @BookingId";
                        cmd.Parameters.AddWithValue("@BookingId", bookingID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Booking bookingDetails = new Booking
                                {
                                    BookingId = (int)reader["Booking_Id"],
                                    Event = new Event
                                    {
                                        EventId = (int)reader["Event_Id"],
                                        EventName = (string)reader["Event_Name"],
                                        TotalSeats = (int)reader["Total_Seats"],
                                        TicketPrice = (decimal)reader["Ticket_Price"]
                                        // Add more event properties as needed
                                    },
                                    NumTickets = (int)reader["num_tickets"],
                                    TotalCost = (decimal)reader["Total_Cost"],
                                    BookingDate = (DateTime)reader["Booking_Date"],
                                    Customers = new Customer[]
                                    {
                                new Customer
                                {
                                    customerID = (int)reader["Customer_Id"],
                                    CustomerName = (string)reader["Customer_Name"],
                                    Email = (string)reader["Email"],
                                    PhoneNumber = (string)reader["Phone_Number"]
                                    // Add more customer properties as needed
                                }
                                    }
                                    // Add more properties as needed
                                };

                                // Handle multiple customers if necessary
                                while (reader.Read())
                                {
                                    Customer additionalCustomer = new Customer
                                    {
                                        customerID = (int)reader["CustomerId"],
                                        CustomerName = (string)reader["CustomerName"],
                                        Email = (string)reader["Email"],
                                        PhoneNumber = (string)reader["PhoneNumber"]
                                        // Add more customer properties as needed
                                    };

                                    bookingDetails.Customers = bookingDetails.Customers.Concat(new[] { additionalCustomer }).ToArray();
                                }

                                return bookingDetails;
                            }
                            else
                            {
                                return null; // Booking with specified ID not found
                            }
                        }
                    }
                
            }
            
            
        }
    }
    
}
