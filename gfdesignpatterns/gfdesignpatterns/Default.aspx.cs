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
            dictionary.add("feet", "inch", 12);
            dictionary.add("mile", "feet", 5280);

            var result = dictionary.convert("inch", "mile", 1);
            result = dictionary.convert("inch", "feet", 10);
            result = dictionary.convert("feet", "mile", 2);
            result = dictionary.convert("mile", "inch", 1);
            result = dictionary.convert("inch", "inch", 1);

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }
    }
}