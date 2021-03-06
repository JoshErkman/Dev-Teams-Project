﻿using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_UI
{
    class ProgramUI
    {
        // Field holding the developer Repo
        private DeveloperRepo _developerRepository = new DeveloperRepo();

        // Field holding the Developer Team Repo
        private DevTeamRepo _devTeamRepository = new DevTeamRepo();

        // This field allows new ID's to be created that do not match others
        private Random _randomID = new Random();

        // This is the method that runs the application
        public void Run()
        {
            // Seed List with developers and Teams
            SeedDeveloperList();

            // Runs Menu
            Menu();
        }

        //Menu
        private void Menu()
        {
            // Bool and loop for when the user wants to exit
            bool keepRunning = true;
            while (keepRunning)
            {
                // Dislay our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "\n1. Add New Developer\n" +
                    "2. Add New Team\n" +
                    "\n3. Update Developer Info\n" +
                    "4 Update Team Info\n" +
                    "\n5 Remove Developer\n" +
                    "6. Remove Team\n" +
                    "\n7. Assign A Developer/Multiple To A Team\n" +
                    "8. Remove A Developer From A Team\n" +
                    "\n9. View All Developers\n" +
                    "10. View All Teams\n" +
                    "\n11. Exit");



                // Get user input
                string input = Console.ReadLine();

                // Evaluate the users input and act accordingly
                switch (input)
                {
                    case "1":
                        // Add New Developer
                        AddNewDeveloper();
                        break;

                    case "2":
                        // Add New Team
                        AddNewDevTeam();
                        break;

                    case "3":
                        //Update Developer Info
                        UpdateExistingDev();
                        break;

                    case "4":
                        // Update Team Info
                        UpdateExistingDevTeam();
                        break;

                    case "5":
                        // Remove developer
                        DeleteExistingDeveloper();
                        break;

                    case "6":
                        // Remove Team
                        DeleteExistingTeam();
                        break;

                    case "7":
                        // Assign A developer to a team
                        AddMembersToTeam();
                        break;

                    case "8":
                        //Remove A developer from a team
                        RemoveMembersFromTeam();
                        break;

                    case "9":
                        // View All developers
                        DisplayAllDevelopers();
                        break;

                    case "10":
                        // view all teams
                        DisplayAllTeams();
                        break;

                    case "11":
                        // exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                        
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // 1 Add new developer
        private void AddNewDeveloper()
        {
            // clear console
            Console.Clear();

            // Create new developer
            Developer newDeveloper = new Developer();

            // Name
            Console.WriteLine("Enter the Name of the developer.");
            newDeveloper.Name = Console.ReadLine();

            // Does this developer have pluralsight access
            bool response = HasPluralsightAccess();
            newDeveloper.HasPluralsightAccess = response;

            // ID number
            Console.WriteLine("\nThis developer will automatically be assigned an ID.");
            newDeveloper.IDNumber = GenerateIDNumber();

            // Add developer to the developer repo
            _developerRepository.AddDevToList(newDeveloper);
        }

        // 2 Add new team

        private void AddNewDevTeam()
        {
            // Clear Console
            Console.Clear();

            // Create new Dev Team
            DevTeam newDevTeam = new DevTeam();

            // Title
            Console.WriteLine("What is the Title of this team?");
            newDevTeam.Title = Console.ReadLine();

            // Team ID and Project ID
            Console.WriteLine("\nThis team will automatically be assign an ID.");
            Console.WriteLine("The project this team is working on will also automatically be assigned an ID.");
            newDevTeam.TeamID = GenerateIDNumber();
            newDevTeam.ProjectID = GenerateIDNumber();

            // Project Name
            Console.WriteLine("\nWhat is the title of this teams current project.");
            newDevTeam.ProjectTitle = Console.ReadLine();

            // Department
            Console.WriteLine("\nWhat department is this team working under?");
            newDevTeam.Department = Console.ReadLine();

            // Project Status
            Console.WriteLine("\nEnter the status of this teams project\n" +
                "1. PrePhase\n" +
                "2. Pending\n" +
                "3. Complete\n");

            string statusAsString = Console.ReadLine();
            int statusAsInt = int.Parse(statusAsString);
            newDevTeam.StatusOfProject = (ProjectStatus)statusAsInt;

            _devTeamRepository.AddDevTeam(newDevTeam);

        }

        // 3 update developer info
        private void UpdateExistingDev()
        {
            // Display the developers
            DisplayAllDevelopers();

            // Ask for the ID of the developer the user would like to update
            Console.WriteLine("\nEnter the ID number of the developer you would like to update.");

            // Get the name of the developer
            string oldDeveloper = Console.ReadLine();

            // build new object for developer
            Developer newDev = new Developer();

            // get the name for the new develoer
            Console.WriteLine("\nEnter the name for the new develoer.");
            newDev.Name = Console.ReadLine();

            // check if the new developer has pluralsight access
            HasPluralsightAccess();

            // Let the user know that a new ID will automatically be generated and generate ID
            Console.WriteLine("\nAn ID will automatically be generated");
            newDev.IDNumber = GenerateIDNumber();

            // verify the update worked
            bool wasUpdated = _developerRepository.UpdateExistingDev(oldDeveloper, newDev);

            if (wasUpdated)
            {
                Console.WriteLine("\nDeveloper was successfully updated.");
            }
            else
            {
                Console.WriteLine("\nDeveloper could not be updated.");
            }
        }


        // 4 Update Team Info
        private void UpdateExistingDevTeam()
        {
            // Display the teams
            DisplayAllTeams();

            // Ask for the ID of the team you would like to update
            Console.WriteLine("\nEnter the ID for the team you would like to update");

            // Get the ID of the team
            string oldTeam = Console.ReadLine();

            // Build new object for new team
            DevTeam newDevTeam = new DevTeam();

            // Get new name for the dev team update
            Console.WriteLine("\nEnter the name for the new dev team");
            newDevTeam.Title = Console.ReadLine();

            // Generate new ID for new team
            Console.WriteLine("\nA new ID will automatically be generated for this team");
            newDevTeam.TeamID = GenerateIDNumber();

            // Get new department for new team
            Console.WriteLine("\nEnter the department for the new team");
            newDevTeam.Department = Console.ReadLine();

            // Get new project title for new team
            Console.WriteLine("\nEnter the project title for the new team");
            newDevTeam.ProjectTitle = Console.ReadLine();

            // Get new ID for new team project
            Console.WriteLine("\nA new ID will be automatically assigned to this project");
            newDevTeam.ProjectID = GenerateIDNumber();

            // Get the project status for the new teams project
            Console.WriteLine("\nEnter the status of the new teams project:\n" +
                "1. PrePhase\n" +
                "2. Pending\n" +
                "3. Complete\n");

            string statusAsString = Console.ReadLine();
            int statusAsInt = int.Parse(statusAsString);
            newDevTeam.StatusOfProject = (ProjectStatus)statusAsInt;

            // verify the update worked
            bool wasUpdated = _devTeamRepository.UpdateExistingDevTeam(oldTeam, newDevTeam);

            if (wasUpdated)
            {
                Console.WriteLine("\nThe new team was updated successfully");
            }
            else
            {
                Console.WriteLine("\nThe new team could not be updated");
            }

        }

        // 5 Delete Developer
        private void DeleteExistingDeveloper()
        {

            // Get the ID of the developer they want to remove
            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the ID number of the developer you would like to remove:");
            string input = Console.ReadLine();

            // Check to see if dev was removed from devrepo
            bool wasDeleted = _developerRepository.RemoveDevFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Developer was successfully removed.");
            }
            else
            {
                Console.WriteLine("The developer could not be removed from the list");
            }
        }

        // 6 Delete Team
        private void DeleteExistingTeam()
        {
            DisplayAllTeams();

            // Get the ID of the team they would like to remove
            DisplayAllTeams();
            Console.WriteLine("\nEnter the ID of the team you would like to remove:");
            string input = Console.ReadLine();

            bool wasDeleted = _devTeamRepository.RemoveDevTeamFromList(input);

            //If the content was deleted we need to tell the user
            // If it wasnt we also need to tell them

            if (wasDeleted)
            {
                Console.WriteLine("The team was successfully removed from the list.");
            }
            else
            {
                Console.WriteLine("The team was unable to be removed from the list.");
            }
        }


        // 7 Add new developers to teams
        private void AddMembersToTeam()
        {
           
            // clear console
            Console.Clear();

            // Get ID for the team the user would like to add a developer to
            DisplayAllTeams();
            Console.WriteLine("\nPick a team by its ID that you would like to add this member to.");
            string teamIDSelected = Console.ReadLine();

            // Get ID for developer
            Console.Clear();
            DisplayAllDevelopers();

            bool keepEntering = true;
            while (keepEntering)
            {
                Console.WriteLine("\nPick a developer by ID you would like to add to the team:");
                string chosenDeveloperID = Console.ReadLine();

                // Get developer ID and assign to object
                Developer dev = _developerRepository.GetDeveloperByID(chosenDeveloperID);

                // Add dev to team and see if it worked
                bool wasUpdated = _devTeamRepository.AddDevToTeam(teamIDSelected, dev);

                //If the developer was added we need to tell the user
                // If it wasnt we also need to tell them
                if (wasUpdated)
                {
                    Console.WriteLine("\nThe developer was successfully added to the team");
                }
                else
                {
                    Console.WriteLine("\nThe developer was unable to be added to the team");
                }

                
                Console.WriteLine("Would you like to add another developer to the team?...(y/n)");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    keepEntering = true;
                }
                else
                {
                    keepEntering = false;
                }

            }
        }

        // Add multiple Developers to a team at once
        private void AddMultipleMembersToTeam()
        {
            // clear console
            Console.Clear();

            //Get ID for team the user would like to add developers to
            DisplayAllTeams();
            Console.WriteLine("\nEnter the ID for the team you would like to add developers to:");
            string teamIDSelected = Console.ReadLine();

            // Get ID for developers the user would like to add
            Console.Clear();
            DisplayAllDevelopers();

        }


        // Remove individual developer from a team
        private void RemoveMembersFromTeam()
        {
            // clear console
            Console.Clear();

            // pick the team from which they would like to remove a developer
            DisplayAllTeams();
            Console.WriteLine("\nPick a team by ID that you would like to remove a member from.");
            string teamIDSelected = Console.ReadLine();

            //clear console
            Console.Clear();

            // pick the developer that the user would like to remove from the selected team
            DisplayAllDevelopers();
            Console.WriteLine("\nPick a developer by ID that you would like to remove from the team");
            string developerIDSelected = Console.ReadLine();

            // Get developer by ID
            Developer dev = _developerRepository.GetDeveloperByID(developerIDSelected);

            // remove developer from team
            bool wasUpdated = _devTeamRepository.RemoveDevFromTeam(teamIDSelected, dev);
            if (wasUpdated)
            {
                Console.WriteLine("Developer was removed successfully");
            }
            else
            {
                Console.WriteLine("Developer was unable to be removed");
            }



        }

        // View individual developer
        private void ViewIndividualDeveloper()
        {
            Console.Clear();
            // Prompts the user to give an ID
            Console.WriteLine("Enter the ID of the developer you are looking for:");

            // Get the users Input
            string ID = Console.ReadLine();

            // find the user by that ID
            Developer dev = _developerRepository.GetDeveloperByID(ID);

            // Display said content if it is not null
            if (dev != null)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"ID: {dev.IDNumber}\n" +
                    $"Pluralsight access: {dev.HasPluralsightAccess}");
            }
            else
            {
                Console.WriteLine("There is no developer with that ID");
            }
        }




        // View current list of developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepository.GetListOfDevs();

            foreach (Developer dev in listOfDevelopers)
            {
                Console.WriteLine($"\nName: {dev.Name}\n" +
                    $"ID Number: {dev.IDNumber}\n" +
                    $"Pluralsight Access: {dev.HasPluralsightAccess}");
            }
        }



        // View current List of Teams
        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeamRepository.GetListOfTeams();

            foreach (DevTeam developerTeam in listOfDevTeams)
            {
                Console.WriteLine($"\nTitle: {developerTeam.Title}\n" +
                    $"Team ID: {developerTeam.TeamID}\n" +
                    $"Department: {developerTeam.Department}\n" +
                    $"Project Title: {developerTeam.ProjectTitle}\n" +
                    $"Project ID: {developerTeam.ProjectID}\n" +
                    $"Project Status: {developerTeam.StatusOfProject}");

                Console.WriteLine("Members:");

                    foreach (Developer developerMember in developerTeam.Members)
                {
                    Console.WriteLine(developerMember.Name);
                }
                  
            }
        }

        // Generate ID number
        private string GenerateIDNumber()
        {
            //List<Developer> listOfDevelopers = _developerRepository.GetListOfDevs()

            int ID = _randomID.Next(000, 999);
            ID = _randomID.Next(000, 999);
            return ID.ToString();
        }

        // Seed developer and team list
        public void SeedDeveloperList()
        {
            Developer devOne = new Developer("Josh Erkman", GenerateIDNumber(), true);
            Developer devTwo = new Developer("Joel Norman", GenerateIDNumber(), false);
            Developer devThree = new Developer("Hillary Lindstrom", GenerateIDNumber(), true);

            _developerRepository.AddDevToList(devOne);
            _developerRepository.AddDevToList(devTwo);
            _developerRepository.AddDevToList(devThree);

            List<Developer> teamListOne = new List<Developer>()
            {
                devOne,
                devTwo,
            };

            List<Developer> teamListTwo = new List<Developer>()
            {
                devThree,
            };
            List<Developer> teamListThree = new List<Developer>()
            {
                devTwo,
                devThree,
            };


            DevTeam devTeamOne = new DevTeam("Team 1", GenerateIDNumber(), "SDEV", "SDEV LogIn", GenerateIDNumber(), ProjectStatus.PrePhase, teamListOne );
            DevTeam devteamTwo = new DevTeam("Team 2", GenerateIDNumber(), "Accounting", "Accounting LogIn", GenerateIDNumber(), ProjectStatus.Pending, teamListTwo);
            DevTeam devTeamThree = new DevTeam("Team 3", GenerateIDNumber(), "SDEV", "software testing", GenerateIDNumber(), ProjectStatus.Complete, teamListThree);

            _devTeamRepository.AddDevTeam(devTeamOne);
            _devTeamRepository.AddDevTeam(devteamTwo);
            _devTeamRepository.AddDevTeam(devTeamThree);

        }


        private bool HasPluralsightAccess()
        {
            Console.WriteLine("\nDoes this developer have Pluralsight access? (type y/n)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
