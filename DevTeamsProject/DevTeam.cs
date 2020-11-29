using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    // POCO for developer teams

    public enum ProjectStatus
    {
        PrePhase = 1,
        Pending,
        Complete,
    }
    public class DevTeam
    {
        public string Title { get; set; }

        public string TeamID { get; set; }
        public string Department { get; set; }

        public string ProjectTitle { get; set; }

        public string ProjectID { get; set; }

        public ProjectStatus StatusOfProject { get; set; }

        public List<Developer> Members { get; set; } = new List<Developer>();

        public DevTeam() { }

        public DevTeam(string title, string teamID, string department, string projectTitle, string projectID, ProjectStatus statusOfProject, List<Developer> members)
        {
            Title = title;
            TeamID = teamID;
            Department = department;
            ProjectTitle = projectTitle;
            ProjectID = projectID;
            StatusOfProject = statusOfProject;
            Members = members;
        }
    }
}
