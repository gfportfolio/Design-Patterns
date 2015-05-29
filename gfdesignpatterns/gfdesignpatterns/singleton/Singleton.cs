using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.singleton
{
    public class Singleton
    {
        private static Singleton _singleton;
        protected static int singletonCounter = 0;
        public static Singleton Instance
        {
            get
            {
                //reset  new Singleton((singletonCounter++), "singletonTest");
                if (_singleton == null)
                {
                    _singleton = new Singleton((singletonCounter++), "singletonTest");
                }

                return _singleton;

            }
        }


        private Singleton(int id, string name)
        {
            _id = id;
            _name = name;
            _movies = new List<show>();
            _shorts = new List<show>();

            addMovie("Toy Story", 1995);
            addMovie("Bugs Life", 1998);
            addShorts("Luxo Jr.", 1986);
            addShorts("The Blue Umbrella", 2013);
        }

        private int _id;
        private string _name;
        private List<show> _movies;
        private List<show> _shorts;

        public int id
        {
            get { return _id; }
        }

        public string name
        {
            get { return _name; }
        }

        public List<show> movies
        {
            get { return _movies; }
        }

        public List<show> shorts
        {
            get { return _shorts; }
        }

        public void addMovie(string name, int year)
        {
            _movies.Add(makeANewShow(name, year));
        }
        public void addShorts(string name, int year)
        {
            _shorts.Add(makeANewShow(name, year));
        }

        public show makeANewShow(string name, int year)
        {
            var newShow = new show();
            newShow.name = name;
            newShow.year = year;
            return newShow;
        }


        public class show
        {
            public string name;
            public int year;
        }
    }
}