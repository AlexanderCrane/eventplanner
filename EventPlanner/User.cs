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
    /// A class representing user related information to be saved to a JSON File
    /// </summary>
    /// 

    public class User
    {
        /// <summary>
        /// Constructor for User
        /// Assigns the accepted name and ID to userName and userId.
        /// ** Pre: A valid name and ID is passed in
        /// ** Post: Global variables userName and userId are initialized with the values passed in
        /// </summary>
        public string userName = "";
        /// <summary>
        /// A unique user ID
        /// </summary>
        public int userID = 0;
        /// <summary>
        /// The user's password.
        /// </summary>
        public string userPassword = "";
        /// <summary>
        /// The list of events created by a user.
        /// </summary>
        public List<string> userCreatedEvents = new List<string>();
        /// <summary>
        /// The list of events a user is attending.
        /// </summary>
        public List<string> userAttendingEvents = new List<string>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\userSaveFile.json";
        private JsonSerializer serializer = new JsonSerializer();

        //as user is checked here, we will also do all file checking/creation here.
        /// <summary>
        /// The constructor for the User object.
        /// </summary>
        /// <param name="name">the user's chosen name.</param>
        /// <param name="ID">a unique user ID</param>
        /// <param name="password">The user's chosen password</param>
        /// <param name="attending">A list of names of events the user is attending.</param>
        /// <param name="created">A list of names of events the user has created.</param>
        public User(string name, int ID, string password, List<string> attending, List<string> created)
        {
            userName = name;
            userID = ID;
            userPassword = password;
            userCreatedEvents = created;
            userAttendingEvents = attending;
        }

        /// <summary>
        /// A method to handle the user login process.
        /// </summary>
        /// <param name="checker"></param>
        public void Login(User checker, LoginPopup login)
        {
            try
            {
                //file never exists so will create new lists and add user.
                if (!File.Exists(path))
                {
                    MessageBox.Show("No data found for users or events, please load file to 'my documents' or create an account.");
                }

                //search for user, if exists welcome and pull data, if not create and welcome.
                else
                {
                    Boolean exists = false;
                    List<User> usr = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));

                    foreach (User item in usr)
                    {
                        if (item.userName == checker.userName && item.userPassword == checker.userPassword)
                        {
                            exists = true;
                            checker.userID = item.userID;
                            //TODO: OTHER LOG IN STUFF
                            //Loading profile?
                            MessageBox.Show("Welcome back, " + checker.userName + "!");
                            closeLogin(login);
                        }
                    }

                    //user does not exist
                    if (exists == false)
                    {
                        MessageBox.Show("username or password does not match, try again or create account.");
                        //TODO clear text box
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


        /// <summary>
        /// Method to handle the creation of new user accounts.
        /// </summary>
        /// <param name="checker"></param>
        public void createAccount(User checker, LoginPopup login)
        {
            try
            {

                //file never exists so will create new lists and add user/event.
                if (!File.Exists(path))
                {
                    List<Event> evts = new List<Event>();
                    List<User> usr = new List<User>();

                    using (StreamWriter file = new StreamWriter(path, append: true))
                    {
                        usr.Add(checker);
                        serializer.Serialize(file, usr);
                    }
                    MessageBox.Show("You are the first User!");
                    closeLogin(login);
                }

                //search for user, if exists asks for new username.
                else
                {
                    Boolean exists = false;
                    List<User> usr = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(path));

                    foreach (User item in usr)
                    {
                        if (item.userName == checker.userName)
                        {
                            exists = true;
                            MessageBox.Show("Username " + checker.userName + " already exists, please try again or login.");
                            //TODO clear textboxes
                        }
                    }

                    //list exists, user does not.
                    if (exists == false)
                    {
                        checker.userID = usr.Count();
                        usr.Add(checker);
                        //saving info
                        //TODO add pop up to double check user's password, block out letters in both.
                        using (StreamWriter file = new StreamWriter(path, append: false))
                        {
                            serializer.Serialize(file, usr);
                        }
                        closeLogin(login);
                        MessageBox.Show("successfully created account!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File write failed with exception." + ex.ToString());
            }


        }

        /// <summary>
        /// Close the login popup.
        /// </summary>
        private void closeLogin(LoginPopup login)
        {
            //Call to Main Window which gives the option to create event, check availability, and attend event
            login.Hide();
            MainWindow main = new MainWindow(userName);
            main.Closed += (s, args) => login.Close();
            main.ShowDialog();
        }





    }
}
