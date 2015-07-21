using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.observer
{
    public class MovieInfo
    {
        private string _name;
        private bool _started;
        private bool _ended;
        private int _theatreNumber;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private string name1;
        private int theatreNumber1;
        private bool started1;
        private bool ended1;

        public MovieInfo(string name, int theatre, bool start, bool end, DateTime? startTime)
        {
            _name = name;
            _theatreNumber = theatre;
            _ended = end;
            _started = start;
            _startTime = startTime;
            _endTime = null;
        }


        public string name { get { return _name; } }
        public bool started { get { return _started; } }
        public DateTime? endTime { get { return _endTime; } set { _endTime = value; } }
        public DateTime? startTime { get { return _startTime; } }
        public bool ended { get { return _ended; } }
        public int theatreNumber { get { return _theatreNumber; } }
    }


    public class MovieTheathre : IObservable<MovieInfo>
    {
        private List<MovieInfo> movies;
        private List<IObserver<MovieInfo>> observers;

        public MovieTheathre()
        {
            observers = new List<IObserver<MovieInfo>>();
            movies = new List<MovieInfo>();
        }

        public IDisposable Subscribe(IObserver<MovieInfo> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);

                foreach (var film in movies)
                {
                    observer.OnNext(film);
                }

            }
            return new Unsubscriber<MovieInfo>(observers, observer);
        }

        public void movieOver(string name, int theatreNumber)
        {
            TheatreStatus(name, theatreNumber, true, true);
        }

        public void movieStarted(string name, int theatreNumber)
        {
            TheatreStatus(name, theatreNumber, true, false);
        }

        public void newMovie(string name, int theatreNumber, DateTime startTime)
        {
            TheatreStatus(name, theatreNumber, false, false, startTime);
        }

        public void TheatreStatus(string name, int theatreNumber, bool started, bool ended, DateTime? startTime = null)
        {
            var info = new MovieInfo(name, theatreNumber, started, ended, startTime);
            if (!started && !ended)
            {
                movies.Add(info);
                foreach (var observer in observers)
                {
                    observer.OnNext(info);
                }

            }
            if (started && !ended)
            {
                var startedMovies = movies.Where(t => t.name == info.name && t.theatreNumber == info.theatreNumber);
                foreach (var movie in startedMovies)
                {
                    //movie.started = true;
                }
                foreach (var observer in observers)
                {
                    observer.OnNext(info);
                }

            }
            else if (started && ended)
            {
                info.endTime = DateTime.Now;
                movies.RemoveAll(t => t.name == info.name && t.theatreNumber == info.theatreNumber);

                foreach (var observer in observers)
                {
                    observer.OnNext(info);
                }
            }

        }

        public void lastMovieEnded()
        {
            foreach (var observer in observers)
            {
                observer.OnCompleted();
                observers.Clear();
            }
        }
    }

    internal class Unsubscriber<MovieInfo> : IDisposable
    {
        private List<IObserver<MovieInfo>> _observers;
        private IObserver<MovieInfo> _observer;
 
        internal Unsubscriber(List<IObserver<MovieInfo>> observers, IObserver<MovieInfo> observer){
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }

    public class MovieMonitor : IObserver<MovieInfo>
    {
        private string name;
        private List<MovieInfo> movieInfos = new List<MovieInfo>();
        private IDisposable cancellation;
        private string _monitorText;

        public string monitorText{get{return _monitorText;}}

        public MovieMonitor(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                name = "Movie Monitor";
            }

            this.name = name;
        }

        public virtual void Subscribe(MovieTheathre provider)
        {
            cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
            movieInfos.Clear();
        }

        public virtual void OnCompleted()
        {
            movieInfos.Clear();
        }

        public virtual void OnError(Exception error)
        {
            throw error;
        }

        public virtual void OnNext(MovieInfo value)
        {
            bool updated = false;

            if (value.ended == true)
            {
                var flightsToRemove = movieInfos.Where(t => t.name == value.name && t.theatreNumber == value.theatreNumber);
                if (flightsToRemove.Count() > 0)
                {
                    movieInfos.All(t=>flightsToRemove.Contains(t));
                    updated = true;
                }
            }
            else
            {
                if (!movieInfos.Contains(value))
                {
                    movieInfos.Add(value);
                    updated = true;
                }
            }

            if (updated)
            {
            _monitorText = printMovieInfo(movieInfos);
            }
        }

        public string printMovieInfo(List<MovieInfo> movieInfos)
        {
            string s="";
            foreach(var movieInfo in movieInfos){
                s+=movieInfo.name+" theatre # "+movieInfo.theatreNumber;
                if(movieInfo.started){
                   s+=" Starts At ";
                }
                else{
                    s += " Started At ";
                }
                s+=""+String.Format("{0:t}",movieInfo.startTime);
                s += Environment.NewLine;
            }
            return s;
        }

    }
}

