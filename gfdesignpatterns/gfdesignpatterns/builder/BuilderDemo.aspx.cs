using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns.builder
{
    public partial class BuilderDemo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> showData = getShowData();
            data.Text = string.Join("<br><br><br>", showData.ToArray());
        }

        private List<string> getShowData()
        {
            Director director = new Director();

            Builder shortBuilder = new buildShort();
            Builder movieBuilder = new buildMovie();
            var shows = new List<string>();

            director.construct(shortBuilder, "One Man Band", "2005", "Street Performers");
            shows.Add(shortBuilder.getResult());

            director.construct(shortBuilder, "Presto", "2008", "Alec Azam");
            shows.Add(shortBuilder.getResult());

            director.construct(shortBuilder, "Inside Out", "2015", "Joy");
            shows.Add(shortBuilder.getResult());

            director.construct(shortBuilder, "Finding Nemo", "2003", "Nemo, Merlin");
            shows.Add(shortBuilder.getResult());

            return shows;

        }

    }
}