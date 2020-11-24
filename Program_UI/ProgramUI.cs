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
                    "3. Assign A Developer To A Team\n" +
                    "4. View Developers\n" +
                    "5. View Teams\n" +
                    "6. Exit");

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
                        break;

                    case "3":
                        // Assign a Developer to a team
                        break;

                    case "4":
                        // View list of developers
                        DisplayAllDevelopers();
                        break;

                    case "5":
                        // View list of Teams
                        break;

                    case "6":
                        // Exit
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Add new developer
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

        // Add new team

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

        // Add a developer to a team
        private void AddDevToTeam()
        {
            Console.Clear();

        }
         
            


        // View current list of developers
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepository.GetListOfDevs();
            
            foreach(Developer dev in listOfDevelopers)
            {
                Console.WriteLine($"Name: {dev.Name}\n" +
                    $"ID Number: {dev.IDNumber}\n" +
                    $"Pluralsight Access: {dev.HasPluralsightAccess}");
            }
        }

        // View current List of Teams
        private void DisplayAllTeams()
        {
            Console.Clear();

            List<DevTeam> listOfDevTeams = _devTeamRepository.GetListOfTeams();

            foreach(DevTeam developerTeam in listOfDevTeams)
            {
                Console.WriteLine($"Title: {developerTeam.Title}\n" +
                    $"Team ID: {developerTeam.TeamID}\n" +
                    $"Department: {developerTeam.Department}\n" +
                    $"Project Title: {developerTeam.ProjectTitle}\n" +
                    $"Project ID: {developerTeam.ProjectID}\n" +
                    $"Project Status: {developerTeam.StatusOfProject}\n" +
                    $"Team Members: {developerTeam.Members}");
            }
        }

        private string GenerateIDNumber()
        {
            return Guid.NewGuid().ToString("N");
        }

        // Seed method
        private void SeedDeveloperList()
        {
            Developer devOne = new Developer("Josh Erkman", GenerateIDNumber(), true);
            Developer devTwo = new Developer("Joel Norman", GenerateIDNumber(), false);
            Developer devThree = new Developer("Hillary Lindstrom", GenerateIDNumber(), true);

            _developerRepository.AddDevToList(devOne);
            _developerRepository.AddDevToList(devTwo);
            _developerRepository.AddDevToList(devThree); 
        }

        private bool HasPluralsightAccess()
        {
            Console.WriteLine("Does this developer have Pluralsight access? (type y/n)");
            string answer = Console.ReadLine().ToLower();
            if(answer == "y")
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
