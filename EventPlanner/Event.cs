using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
* File: Event.cs | Event Class
* Author: Austin A. Irvine
* Date Created: September 14, 2017
* Brief: Holds information about an real-life event
*        The event info will be added to a json file for later consumption
*/

#region Table of Contents Notes
/*
    TABLE OF CONTENTS
    -name of event
    -unique event id (eventually for duplicate)
    -host
    -location
    -brief
    -start
    -end
    -capacity
    -attendees
*/
#endregion

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Event class. Serializable to JSON.
    /// </summary>
    public class Event
    {
        #region Private Variables and Properties

        /// <summary>
        /// The event's name.
        /// </summary>
        public string nameOfEvent = "";
        /// <summary>
        /// The creator of the event.
        /// </summary>
        public string host = "";
        /// <summary>
        /// The location of the event.
        /// </summary>
        public string location = "";
        /// <summary>
        /// A description of the event.
        /// </summary>
        public string brief = "";


        /// <summary>
        /// A list of tuples containing two DateTimes. 
        /// These represent the start and end times of each contiguous block of scheduled event time.
        /// </summary>
        public List<Tuple<DateTime, DateTime>> dateTimes;

        /// <summary>
        /// A list representing the attendess of the event.
        /// Tuples contain a string representing the user's name and a list of available time slots.
        /// </summary>
        public List<Tuple<String, List<DateTime>>> attendees;

        /// <summary>
        /// The maximum number of attendees for each time slot before users can no longer add themselves as attendees.
        /// </summary>
        public int capacity;

        /// <summary>
        /// The number of attendees for an event.
        /// </summary>
        public int numberOfAttendees = 0;
        #endregion

        /// <summary>
        /// Constructor for the event class
        /// </summary>
        /// <param name="eventName">The name of the event. User specified.</param>
        /// <param name="hostName">The name of the host. Passed in from LoginPopup.</param>
        /// <param name="description">A brief description of the event. User specified, optional.</param>
        /// <param name="dateTimes">List of datetimes representing the user's selections</param>
        /// <param name="loc">The event's location</param>
        /// <param name="attending">Number attending the event</param>
        /// <param name="cap">The event's capacity.</param>
        public Event(string eventName, string hostName, string description, List<Tuple<DateTime, DateTime>> dateTimes, string loc, int attending, int cap)
        {
            nameOfEvent = eventName;
            host = hostName;
            location = loc;
            brief = description;
            this.dateTimes = dateTimes;
            numberOfAttendees = attending;
            this.capacity = cap;
            Console.WriteLine("WTFFFFF " + this.capacity);

            this.attendees = new List<Tuple<string, List<DateTime>>>();

            //saveToFile(eventName, capacity, brief, start, end);
        }

        //SETTERS
        #region Public Method Setters
        /// <summary>
        /// Set the event name.
        /// </summary>
        /// <param name="name">New name.</param>
        public void setName(string name)
        {
            nameOfEvent = name;
        }
        /// <summary>
        /// Set the host name.
        /// </summary>
        /// <param name="hostName">new host name.</param>
        public void setHost(string hostName)
        {
            host = hostName;
        }
        /// <summary>
        /// New location.
        /// </summary>
        /// <param name="loc">New location.</param>
        public void setLocation(string loc)
        {
            location = loc;
        }
        /// <summary>
        /// Set the description.
        /// </summary>
        /// <param name="msg">New description message.</param>
        public void setBrief(string msg)
        {
            brief = msg;
        }
        /// <summary>
        /// Set the capacity.
        /// </summary>
        /// <param name="cap">New capacity</param>
        public void setCapacity(int cap)
        {
            if (cap != 0)
            {
                this.capacity = cap;
            }
        }
        /// <summary>
        /// Set the number of attendees
        /// </summary>
        /// <param name="att">New number.</param>
        public void setAttendees(int att)
        {
            numberOfAttendees += att;
        }
        #endregion
        /*
        NOTE:Maybe we'll eventually show everyone who is going to said event?
        */
        /// <summary>
        /// Add an attendee to the event
        /// </summary>
        /// <param name="name">The attendee's name</param>
        /// <param name="availableSlots">The available time slots for an attendee to attend.</param>
        public void addAttendee(String name, List<DateTime> availableSlots)
        {
            foreach (Tuple<String, List<DateTime>> x in attendees)
            {
                if (x.Item1 == name)
                {
                    attendees.Remove(x);
                    break;
                }
            }
            if (availableSlots.Count != 0)
            {
                attendees.Add(new Tuple<string, List<DateTime>>(name, availableSlots));
            }
            this.numberOfAttendees = attendees.Count;
        }

        /*
        NOTE: WIP Random Event ID
        */

        //GETTERS
        #region Public Method Getters
        public string getName()
        {
            return (nameOfEvent);
        }
        public string getHost()
        {
            return (host);
        }
        public string getLocation()
        {
            return (location);
        }
        public string getBrief()
        {
            return (brief);
        }
        public int getCapacity()
        {
            return (this.capacity);
        }
        public int getAttendeeCount()
        {
            return (numberOfAttendees);
        }
        public List<Tuple<String, List<DateTime>>> getAttendees()
        {
            return (attendees);
        }
        #endregion

        /// <summary>
        /// ToString overload for Event.cs. 
        /// </summary>
        /// <returns>Returns the event followed by number of attendees for use in UserWindow.</returns>
        public override string ToString()
        {
            return (this.nameOfEvent + "(" + this.numberOfAttendees + ")");
        }
    }
}