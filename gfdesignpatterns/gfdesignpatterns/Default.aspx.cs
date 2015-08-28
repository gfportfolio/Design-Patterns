using gfdesignpatterns.state;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dictionary = new twoKeyDictionary();
            dictionary.add("inch", "feet", 12);
            dictionary.add("feet", "mile", 5280);

            var result = dictionary.convert("inch", "mile", 1);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
    }
}