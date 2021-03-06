﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
      
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();
        

        //DevTeam Create
        public void AddDevTeam(DevTeam team)
        {
            _devTeams.Add(team);
        }


        //DevTeam Read

        public List<DevTeam> GetListOfTeams()
        {
            return _devTeams;
        }


        //DevTeam Update
        public bool UpdateExistingDevTeam(string originalTeam, DevTeam newTeam)
        {
            // Find the original developer the user would like to update
            DevTeam oldTeam = GetDevTeamByID(originalTeam);

            // Update the developer in the list
            if (oldTeam != null)
            {
                oldTeam.Title = newTeam.Title;
                oldTeam.TeamID = newTeam.TeamID;
                oldTeam.Department = newTeam.Department;
                oldTeam.ProjectTitle = newTeam.ProjectTitle;
                oldTeam.ProjectID = newTeam.ProjectID;
                oldTeam.StatusOfProject = newTeam.StatusOfProject;
                oldTeam.Members = newTeam.Members;
                return true;
            }
            else
            {
                return false;
            }
        }




        //DevTeam Delete
        public bool RemoveDevTeamFromList(string DeveloperTeam)
        {
            DevTeam team = GetDevTeamByID(DeveloperTeam);
            if(team == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(team);

            if(initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }





        //DevTeam Helper (Get Team by ID)
        public DevTeam GetDevTeamByID(string DeveloperTeam)
        {
            foreach(DevTeam team in _devTeams)
            {
                if(team.TeamID == DeveloperTeam)
                {
                    return team;
                }
            }

            return null;
        }

        // Add developer to a team
        public bool AddDevToTeam(string teamID, Developer developer)
        {
            DevTeam devTeam = GetDevTeamByID(teamID);
            if (devTeam == null)
            {
                return false;
            }

            int initialCount = devTeam.Members.Count;
            devTeam.Members.Add(developer);
            int newCount = devTeam.Members.Count;

            if(newCount > initialCount)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }

        // Add Multiple Developers to a team at once
        public bool AddMultipleDevsToTeam(string teamID, Developer developerOne, Developer developerTwo, Developer developerThree)
        {
            DevTeam devTeam = GetDevTeamByID(teamID);
            if(devTeam == null)
            {
                return false;
            }

            int initialCount = devTeam.Members.Count;
            devTeam.Members.Add(developerOne);

            int newCount = devTeam.Members.Count;

            if (newCount > initialCount)
            {
                return true;
            }
            else
            {
                return false;
            }

            int secondCount = devTeam.Members.Count;
            devTeam.Members.Add(developerTwo);

            int newCountTwo = devTeam.Members.Count;

            if (newCountTwo > secondCount)
            {
                return true;
            }
            else
            {
                return false;
            }

            int ThirdCount = devTeam.Members.Count;
            devTeam.Members.Add(developerThree);

            int newCountThree = devTeam.Members.Count;

            if (newCountThree > ThirdCount)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // remove a developer from a team
        public bool RemoveDevFromTeam(string teamID, Developer developer)
        {
            DevTeam devTeam = GetDevTeamByID(teamID);
            if (devTeam == null)
            {
                return false;
            }

            int initialCount = devTeam.Members.Count;
            devTeam.Members.Remove(developer);
            int newCount = devTeam.Members.Count;

            if (newCount < initialCount)
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
