﻿using System;
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
        /// <summary>
        /// Constructor for User
        /// Assigns the accepted name and ID to userName and userId.
        /// ** Pre: A valid name and ID is passed in
        /// ** Post: Global variables userName and userId are initialized with the values passed in
        /// </summary>
        public string userName = "";
        public int userID = 0;
        public string userPassword = "";
        public List<string> userCreatedEvents = new List<string>();
        public List<string> userAttendingEvents = new List<string>();
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\userSaveFile.json";
        private JsonSerializer serializer = new JsonSerializer();

        //as user is checked here, we will also do all file checking/creation here.
        public User(string name, int ID, string password, List<string> attending, List<string> created)
        {
            userName = name;
            userID = ID;
            userPassword = password;
            userCreatedEvents = created;
            userAttendingEvents = attending;
        }

        public void Login(User checker)
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
                            closeLogin();
                        }
                    }

                    //user does not exist
                    if (exists == false)
                    {
                        MessageBox.Show("username or password does not match, try again or create account.");
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


        //user is trying to create new account.
        public void createAccount(User checker)
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
                    closeLogin();
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
                        }
                    }

                    //list exists, user does not.
                    if (exists == false)
                    {
                        // double check password
                        checker.userID = usr.Count();
                        usr.Add(checker);
                        //saving info
                        using (StreamWriter file = new StreamWriter(path, append: false))
                        {
                            serializer.Serialize(file, usr);
                        }
                        closeLogin();
                        MessageBox.Show("successfully created account!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("File write failed with exception." + ex.ToString());
            }


        }

        private void closeLogin()
        {
            //Call to Main Window which gives the option to create event, check availability, and attend event
            LoginPopup.ActiveForm.Hide();
            MainWindow main = new MainWindow(userName);
            main.Closed += (s, args) => LoginPopup.ActiveForm.Close();
            main.ShowDialog();
        }





    }
}
