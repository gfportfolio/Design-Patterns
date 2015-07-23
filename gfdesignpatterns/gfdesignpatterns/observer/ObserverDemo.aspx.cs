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
            if (IsPostBack)
            {
                return;

            }
            ObserverProvider.reset();
            var observerProvider = ObserverProvider.Instance;

            observerProvider.provider.newMovie("Inside Out", 3, new DateTime(2015, 7, 20, 8, 15,0));
            observerProvider.observer1.Subscribe(observerProvider.provider);
            observerProvider.provider.newMovie("Wreck It Ralf", 6, new DateTime(2015, 7, 20, 10, 50,0));
            observerProvider.observer2.Subscribe(observerProvider.provider);
            updateText(observerProvider);

            


        }

        private void updateText(ObserverProvider.observerSingletonPoco observerProvider)
        {
            observer1lb.Text = observerProvider.observer1.monitorText;
            observer2lb.Text = observerProvider.observer2.monitorText;
        }

        protected void startFrozen_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.movieStarted("Frozen", 1);
            observerProvider.observer2.Subscribe(observerProvider.provider);
            updateText(observerProvider);
        }

        protected void endFrozen_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.movieOver("Frozen", 1);
            updateText(observerProvider);
        }

        protected void startWreckItRalf_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.movieStarted("Wreck It Ralf", 6);
            updateText(observerProvider);
        }

        protected void addFrozen_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.newMovie("Frozen", 1, new DateTime(2015, 7, 20, 6, 10, 0));
            observerProvider.observer2.Subscribe(observerProvider.provider);
            updateText(observerProvider);
        }

        protected void addCinderella_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.newMovie("Cinderella", 3, new DateTime(2015, 7, 20, 9, 35, 0));
            observerProvider.observer2.Subscribe(observerProvider.provider);
            updateText(observerProvider);
        }

        protected void startInsideOut_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.provider.movieStarted("Inside Out", 3);
            updateText(observerProvider);
        }

        protected void turnOffScreen2_Click(object sender, EventArgs e)
        {
            var observerProvider = ObserverProvider.Instance;
            observerProvider.observer2.Unsubscribe();
            updateText(observerProvider);
        }
    }
}