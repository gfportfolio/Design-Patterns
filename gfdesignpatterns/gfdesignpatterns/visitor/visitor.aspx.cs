using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns.visitor

{
    public partial class visitor : System.Web.UI.Page
    {
        twoKeyDictionary dictionary;
        OperationVisitor dictionaryVisitor;
        protected void Page_Load(object sender, EventArgs e)
        {
            dictionary = new twoKeyDictionary();

            dictionary.add("feet", "inches", 12);
            dictionary.add("miles", "feet", 5280);
            dictionary.add("cms", "inches", 2.54);
            dictionary.add("A113", "EACs", 20);
            dictionary.add("Piston Cups","Pizza Planet Trucks",  943);
            dictionary.add("EACs", "Pizza Planet Trucks", 1.25);
            dictionary.add("BnLs", "Piston Cups", 5000);

            dictionaryVisitor = new OperationVisitor();

           // var result = dictionary.Accept(visitor, "inch", "mile", 1);
            //result = dictionary.Accept(visitor, "inch", "feet", 10);
            //result = dictionary.Accept(visitor, "feet", "mile", 2);
            //result = dictionary.Accept(visitor, "mile", "inch", 1);
            //result = dictionary.Accept(visitor, "inch", "inch", 1);



        }

        protected void pixarClick(object sender, EventArgs e)
        {
            double howMany = 0.0;
            if (Double.TryParse(pixarHowMany.Text, out howMany) && howMany > 0)
            {
                string nameFrom = namefrom.Text;
                string nameTo = nameto.Text;
                string result = dictionary.accept(dictionaryVisitor, nameFrom, nameTo, howMany);
                results.Text = result;
            }
            else
            {
                results.Text = "Please enter a valid number in How Many";
            }
        }

        protected void realWorld_Click(object sender, EventArgs e)
        {
            double howMany = 0.0;
            if (Double.TryParse(realHowMany.Text, out howMany) && howMany > 0)
            {
                string nameFrom = realList1.Text;
                string nameTo = realList2.Text;
                string result = dictionary.accept(dictionaryVisitor, nameFrom, nameTo, howMany);
                realresults.Text = result;
            }
            else
            {
                realresults.Text = "Please enter a valid number in How Many";
            }
        }
    }
}