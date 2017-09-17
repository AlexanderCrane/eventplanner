using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;



namespace WindowsFormsApplication1
{
    /// <summary>
    /// An overloaded TextBox which is associated with a DateTime and a list of events.
    /// </summary>
    class AgendaTextBox : TextBox
    {
        public List<Event> associatedEvents;
        public DateTime associatedDateTime;
        public AgendaTextBox()
        {
            this.associatedEvents = new List<Event>();
        }
    }
}