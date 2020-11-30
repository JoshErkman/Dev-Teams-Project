using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_UI
{
    class ProgramUI
    {
        private DeveloperRepo _developerRepository = new DeveloperRepo();
        private DevTeamRepo _devTeamRepository = new DevTeamRepo();
        private Random _randomID = new Random();

        // This is the method that runs the application
        public void Run()
        {
            SeedDeveloperList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Dislay our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add New Developer\n" +
                    "2. Add New Team\n" +
                    "3. Update Developer Info\n" +
                    "4 Update Team Info\n" +
                    "5 Remove Developer\n" +
                    "6. Remove Team\n" +
                    "7. Assign A Developer To A Team\n" +
                    "8. Remove A Developer From A Team\n" +
                    "9. View All Developers\n" +
                    "10. View All Teams\n" +
                    "11. Exit");



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
            Console.Clear();
            Developer newDeveloper = new Developer();

            // Name
            Console.WriteLine("Enter the Name of the developer.");
            newDeveloper.Name = Console.ReadLine();

            // Does this developer have pluralsight access

            bool response = HasPluralsightAccess();
            newDeveloper.HasPluralsightAccess = response;

            // ID number
            Console.WriteLine("This developer will automatically be assigned an ID.");
            newDeveloper.IDNumber = GenerateIDNumber();

            _developerRepository.AddDevToList(newDeveloper);
        }

        // 2 Add new team

        private void AddNewDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            // Title
            Console.WriteLine("What is the Title of this team?");
            newDevTeam.Title = Console.ReadLine();

            // Team ID and Project ID
            Console.WriteLine("This team will automatically be assign an ID.");
            Console.WriteLine("The project this team is working on will also automatically be assigned an ID.");
            newDevTeam.TeamID = GenerateIDNumber();
            newDevTeam.ProjectID = GenerateIDNumber();

            // Project Name
            Console.WriteLine("What is the title of this teams current project.");
            newDevTeam.ProjectTitle = Console.ReadLine();

            // Department
            Console.WriteLine("What department is this team working under?");
            newDevTeam.Department = Console.ReadLine();

            // Project Status
            Console.WriteLine("Enter the status of this teams project\n" +
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

            Console.WriteLine("Enter the name for the new develoer.");
            newDev.Name = Console.ReadLine();

            HasPluralsightAccess();

            Console.WriteLine("An ID will automatically be generated");
            newDev.IDNumber = GenerateIDNumber();

            // verify the update worked
            bool wasUpdated = _developerRepository.UpdateExistingDev(oldDeveloper, newDev);

            if (wasUpdated)
            {
                Console.WriteLine("Developer was successfully updated.");
            }
            else
            {
                Console.WriteLine("Developer could not be updated.");
            }
        }


        // 4 Update Team Info
        private void UpdateExistingDevTeam()
        {
            // Display the teams
            DisplayAllTeams();

            // Ask for the ID of the team you would like to update
            Console.WriteLine("Enter the ID for the team you would like to update");

            // Get the ID of the team
            string oldTeam = Console.ReadLine();

            // Build new object for new team
            DevTeam newDevTeam = new DevTeam();

            // Get new name for the dev team update
            Console.WriteLine("Enter the name for the new dev team");
            newDevTeam.Title = Console.ReadLine();

            // Generate new ID for new team
            Console.WriteLine("A new ID will automatically be generated for this team");
            newDevTeam.TeamID = GenerateIDNumber();

            // Get new department for new team
            Console.WriteLine("Enter the department for the new team");
            newDevTeam.Department = Console.ReadLine();

            // Get new project title for new team
            Console.WriteLine("Enter the project title for the new team");
            newDevTeam.ProjectTitle = Console.ReadLine();

            // Get new ID for new team project
            Console.WriteLine("A new ID will be automatically assigned to this project");
            newDevTeam.ProjectID = GenerateIDNumber();

            // Get the project status for the new teams project
            Console.WriteLine("Enter the status of the new teams project:\n" +
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
                Console.WriteLine("The new team was updated successfully");
            }
            else
            {
                Console.WriteLine("The new team could not be updated");
            }

        }

        // 5 Delete Developer
        private void DeleteExistingDeveloper()
        {

            // Get the ID of the developer they want to remove
            DisplayAllDevelopers();
            Console.WriteLine("\nEnter the ID number of the developer you would like to remove:");
            string input = Console.ReadLine();

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

            DisplayAllTeams();
            Console.WriteLine("\nPick a team by its ID that you would like to add this member to.");
            string teamIDSelected = Console.ReadLine();

            Console.Clear();
            DisplayAllDevelopers();
            Console.WriteLine("\nPick a developer by ID you would like to add to the team:");
            
            string chosenDeveloperID = Console.ReadLine();

            Developer dev = _developerRepository.GetDeveloperByID(chosenDeveloperID);


            bool wasUpdated = _devTeamRepository.AddDevToTeam(teamIDSelected, dev);

            //If the developer was added we need to tell the user
            // If it wasnt we also need to tell them
            if (wasUpdated)
            {
                Console.WriteLine("The developer was successfully added to the team");
            }
            else
            {
                Console.WriteLine("The developer was unable to be added to the team");
            }

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
            Console.WriteLine("Does this developer have Pluralsight access? (type y/n)");
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
