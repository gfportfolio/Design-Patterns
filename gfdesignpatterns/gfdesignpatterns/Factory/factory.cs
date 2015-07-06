using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.Factory
{
    public abstract class Show
    {
        protected List<string> movieNames = new List<string>{"Toy", "Story", "A", "Bug's", "Life", "2", "Monsters", "Inc.", "Finding", "Nemo", "The", "Incredibles", "Cars", "Ratatouille", "WALL-E", "Up", "3", "Brave", "University", "Inside", "Out"};
        protected List<string> shortNames = new List<string>{"The", "Adventures", "of", "André", "and", "Wally", "Luxo", "Jr.", "Red's", "Dream", "Tin", "Toy", "Knick", "Knack", "Geri's", "Game", "For", "Birds", "Boundin'", "One", "Man", "Band", "Lifted", "Presto", "Partly", "Cloudy", "Day", "&", "Night", "La", "Luna", "Blue", "Umbrella", "Lava", "Sanjay's", "Super", "Team", "Mike's", "New", "Car", "Jack-Jack", "Attack", "Mater", "Ghostlight", "Your", "Friend", "Rat", "BURN-E", "Dug's", "Special", "Mission", "George", "A.J.", "Legend", "Mor'du", "Party", "Central"};

        public abstract string type { get; }
        public abstract string name { get; }

        public string year
        {
            get
            {
                DateTime start = new DateTime(2015, 1, 1);
                Random gen = new Random();
                int range = (20);
                var newdate= start.AddYears(gen.Next(range));
                return (gen.Next(range) + 2015).ToString();
            }

        }
    }

    public class Movie : Show
    {

        public override string type
        {
            get { return "Movie"; }
        }

        public override string name
        {
            get
            {
                Random rnd = new Random();
                int count = rnd.Next(1, 6);
                string result = "";
                for (int i = 0; i < count; i++)
                {
                    result += movieNames[rnd.Next(0, movieNames.Count() - 1)]+" ";
                }
                return result;
            }
        }
    }

    public class Short : Show
    {

        public override string type
        {
            get
            {
                return "Short";
            }

        }
        public override string name
        {
            get
            {
                Random rnd = new Random();
                int count = rnd.Next(1, 6);
                string result = "";
                for (int i = 0; i < count; i++)
                {
                    result += shortNames[rnd.Next(0, shortNames.Count() - 1)] + " ";
                }
                return result;
            }
        }
    }

    public static class ShowFactory
    {
        public static Show get(string type)
        {
            switch (type.ToLower())
            {
                case "1": return new Movie();
                default: return new Short();
            }
        }
    }


}