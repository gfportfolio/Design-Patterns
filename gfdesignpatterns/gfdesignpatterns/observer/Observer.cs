using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.observer
{
    public class Movie
    {
        private string _name;
        private bool _started;
        private bool _ended;
        private int _theatreNumber;

        protected Movie(string name, int theatre, bool started=false, bool ended=false){
            _name = name;
            _theatreNumber = theatre;
            _ended = ended;
            _started = started;
        }

        public string name { get { return _name; } }
        public string started { get { return _started; } }
        public string ended { get { return _ended; } }
        public string theatreNumber { get { return _theatreNumber; } }
    }


    public class MovieTheathre : IObservable<Movie>
    {
        private List<IObservable<Movie>> movies;
        
        public Movie(){
            movies = new List<IObservable<Movie>>();
        }

        public IDisposable Subscribe(IObservable<Movie> movie){
            if(! movies.Contains(movie)){
                movies.Add(movie);
            }
            return new Unsubscriber<Movie>(movies, movie);
        }

        public void movieOver(string name)
    }
}