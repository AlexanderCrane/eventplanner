/*
* File: Program.cs | Program Class
* Author: Jacob Wulf-eck
* Date Created: September 9, 2017
* Brief: Main starting point for the program
*        Enables visual styles
*        Sets text rendering
*        Makes a call to LoginPopop
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// ** Pre: All application files exists
        /// ** Post: 1. Visual Styles enabled
        ///          2. Set Text Rendering
        ///          3. Calls the first form/dialog box - LoginPopup
        /// </summary>
        /// 
        //calendar icon credit - https://icons8.com/icon/22/Calendar
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();//Enables visual styles such as colors, fonts, and other visual elements
            Application.SetCompatibleTextRenderingDefault(false); //Sets the application-wide default for the UseCompatibleTextRendering property defined on certain controls.
            Application.Run(new LoginPopup());
        }
    }
}
