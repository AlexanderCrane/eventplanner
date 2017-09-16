using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;


//by Hans Passant - https://stackoverflow.com/users/17034/hans-passant
class AgendaTextBox : TextBox
{
    public List<Event> associatedEvents;
    public DateTime associatedDateTime;
    public AgendaTextBox()
    {
        this.associatedEvents = new List<Event>();
    }
}