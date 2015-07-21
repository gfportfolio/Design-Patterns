using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns.observer
{
    public partial class ObserverDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MovieTheathre provider = new MovieTheathre();
            MovieMonitor observer1 = new MovieMonitor("Pixar Monitor");
            MovieMonitor observer2 = new MovieMonitor("Disney Monitor");

            provider.newMovie("Inside Out", 3, new DateTime(2015, 7, 20, 8, 15,0));
            observer1.Subscribe(provider);
            var text = observer1.monitorText;
            text = observer2.monitorText;
            provider.newMovie("Frozen", 1, new DateTime(2015, 7, 20, 6, 10,0));
            provider.newMovie("Cinderella", 3, new DateTime(2015, 7, 20, 9, 35,0));
            provider.newMovie("Wreck It Ralf", 6, new DateTime(2015, 7, 20, 10, 50,0));
            observer2.Subscribe(provider);
            text = observer1.monitorText;
            text = observer2.monitorText;
            provider.movieStarted("Frozen", 1);
            provider.movieStarted("Cinderella", 3);
            observer2.Unsubscribe();
            text = observer1.monitorText;
            text = observer2.monitorText;
            provider.movieOver("Cinderella", 3);
            text = observer1.monitorText;
            text = observer2.monitorText;





        }
    }
}