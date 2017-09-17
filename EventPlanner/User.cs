using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    /// <summary>
    /// Saving user related information in a JSON File
    /// Window: None
    /// Global Variables: 
    ///     1. string userName - to store the userName
    ///     2. int    userId - for faster searching each user has an id for linking to other events, starting at 0 to var limit.
    /// </summary>
    /// 
    public class User
    {

        string userName = "";
        int userID = 0;

        /// <summary>
        /// Constructor for User
        /// Assigns the accepted name and ID to userName and userId.
        /// ** Pre: A valid name and ID is passed in
        /// ** Post: Global variables userName and userId are initialized with the values passed in
        /// </summary>
        public User(string name, int ID)
        {
            userName = name;
            userID = ID;
        }

        public void Login(User checker)
        {
            //
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\eventSaveFile.json";
            JsonSerializer serializer = new JsonSerializer();

            try
            {

                //file never exists so will create new lists and add user.
                if (!File.Exists(path))
                {
                    List<Event> evts = new List<Event>();
                    List<User> usr = new List<User>();

                    using (StreamWriter file = new StreamWriter(path, append: true))
                    {
                        usr.Add(checker);
                        MessageBox.Show(checker.userName + ", " + usr[0].userName + ", " + usr[0].userID);
                        serializer.Serialize(file, usr);
                    }
                    MessageBox.Show("You are the first User!");
                }

                //search for user, if exists welcome and pull data, if not create and welcome.
                else
                {
                    Boolean exists = false;
                    List<User> usr = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));
                    //usr.ForEach(x => { if (x.userName == checker.userName) MessageBox.Show("Welcome back!"); }); 

                    foreach (User item in usr)
                    {
                        MessageBox.Show("number: " + item.userID);
                        MessageBox.Show(checker.userName + ", " + usr[item.userID].userName);
                        if (item.userName == checker.userName)
                        {
                            exists = true;
                            MessageBox.Show("Welcome Back");
                        }
                    }

                    //list exists, user does not.
                    if (exists == false)
                    {
                        checker.userID = usr.Count();
                        usr.Add(checker);
                        MessageBox.Show("successfully created account! " + checker.userName + ", " + checker.userID + ", " + usr[checker.userID].userName); //shown working with checker.id
                    }
                    //saving info
                    using (StreamWriter file = new StreamWriter(path, append: false))
                    {
                        serializer.Serialize(file, usr);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File write failed with exception." + ex.ToString());
            }


        }





    }
}
