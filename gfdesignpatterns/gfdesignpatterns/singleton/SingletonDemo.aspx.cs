using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace gfdesignpatterns.singleton
{
    public partial class SingletonDemo : System.Web.UI.Page
    {
        public string JsonMovieData = "";
        public string JsonShortsData = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            var pixarSingelton = singleton.Singleton.Instance;

            setupJson(pixarSingelton.movies, pixarSingelton.shorts);

        }

        private void setupJson(List<singleton.Singleton.show> movies, List<singleton.Singleton.show> shorts)
        {
            JsonMovieData = JsonConvert.SerializeObject(movies);
            JsonShortsData = JsonConvert.SerializeObject(shorts);
        }

        protected void carsClick(object sender, EventArgs e)
        {
            var pixarSingelton = singleton.Singleton.Instance;
            pixarSingelton.addMovie("Cars", 2006);
            setupJson(pixarSingelton.movies, pixarSingelton.shorts);
        }
        protected void birdsClick(object sender, EventArgs e)
        {
            var pixarSingelton = singleton.Singleton.Instance;
            pixarSingelton.addShorts("For The Birds", 2006);
            setupJson(pixarSingelton.movies, pixarSingelton.shorts);

        }
    }
}