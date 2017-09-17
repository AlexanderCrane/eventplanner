using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;


/// <summary>
/// An overloaded CheckBox which is associated with a DateTime.
/// </summary>
class AvailabilityCheckBox : CheckBox {
    public DateTime associatedDateTime;
}