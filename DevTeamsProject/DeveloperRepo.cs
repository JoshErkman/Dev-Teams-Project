using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDevToList(Developer developer)
        {
            _developerDirectory.Add(developer);
        }


        //Developer Read
        public List<Developer> GetListOfDevs()
        {
            return _developerDirectory;
        }


        //Developer Update
        public bool UpdateExistingDev(string originalDeveloper, Developer newDev)
        {
            // Find the original developer the user would like to update
            Developer oldDeveloper = GetDeveloperByID(originalDeveloper);

            // Update the developer in the list
            if(oldDeveloper != null)
            {
                oldDeveloper.Name = newDev.Name;
                oldDeveloper.IDNumber = newDev.IDNumber;
                oldDeveloper.HasPluralsightAccess = newDev.HasPluralsightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }



        //Developer Delete
        public bool RemoveDevFromList(string developer)
        {
            Developer developerNeeded = GetDeveloperByID(developer);
            if(developerNeeded == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(developerNeeded);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        //Developer Helper (Get Developer by ID)

        public Developer GetDeveloperByID(string developerID)
        {
            foreach(Developer id in _developerDirectory)
            {
                if(id.IDNumber.ToLower() == developerID.ToLower())
                {
                    return id;
                }
            }

            return null;
        }


    }
}
