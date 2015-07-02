using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns.Factory
{
    public partial class FactoryDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            var test = ShowFactory.get("1");



        }

        protected void load_Click(object sender, EventArgs e)
        {

            var factoryResult = ShowFactory.get(selectType.SelectedValue);
            lbltitle.Text = "Your " + factoryResult.type + " is:";
            lblname.Text = factoryResult.name;
            lblyear.Text = "It will come out in " +factoryResult.year;
        }
    }
}