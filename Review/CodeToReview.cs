﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }

        /* This is not a subclass, but looks like an alternative constructor that inherits
           a date-offset if the dob is not passed through. */
        public People(string name)
        {
            Name = name;
            DOB = Under16.Date;
        }

        public People(string name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;
        //_people is understood to be a private implementation for what's to be a public property, by general convention.

        public BirthingUnit() //Constructor.
        {
            _people = new List<People>(); //Understood to be creating an empty list of 'People' class type.
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++) //Where i how many people are wanted to be created for the list.
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    var random = new Random();
                    if (random.Next(0, 1) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 365, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Don't think this should ever happen.
                    throw new Exception("Something failed in user creation: " + e);
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            //The code below uses '>=', so age 30 will also be included. Also looks like another 356-365 typo.
            //Also strings should be compared with example.Equals("") rather than '=='.
            return olderThan30 ? _people.Where(x => x.Name.Equals("Bob") && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 365, 0, 0, 0))) : _people.Where(x => x.Name.Equals("Bob"));
        }

        public string GetMarried(People p, string lastName)
        {
            string marriedName = "";
            if (lastName.Contains("test"))
                return p.Name; //Just returns if the lastName parameter is just a "test", or anything that contains "test".
            if ((p.Name.Length + lastName.Length) < 255) //Looks like a bug, looks like we should be adding both lengths as integers for the conditional.
                //Also think it should be < rather than > as we want to fit the name within the specified 255 length below.
            {
                marriedName = (p.Name + " " + lastName).Substring(0, 255); //Saving the concatenated name into a local string.
            }

            return marriedName; //Reusing code from before.
        }
    }
}