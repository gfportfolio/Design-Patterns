using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gfdesignpatterns.flyweight
{
    public partial class FlyweightDemo : System.Web.UI.Page
    {


        public string JsonGoodPlayers = "";
        public string JsonBadPlayers = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            Flyweight.reset();
            var flyweight = Flyweight.Instance;
            
            setupJson(flyweight.goodPlayers, flyweight.badPlayers);

        }

        private void setupJson(List<flyweight.player> good, List<flyweight.player> bad)
        {
            JsonGoodPlayers = JsonConvert.SerializeObject(good);
            JsonBadPlayers = JsonConvert.SerializeObject(bad);
        }

        protected void playerButton_Click(object sender, EventArgs e)
        {
            var buttonId = ((Button)sender).ID;
            var number = int.Parse(buttonId.Remove(0, 6));
            var flyweight = Flyweight.Instance;
            var result = flyweight.round(number);
            log.Text = result;
            setupJson(flyweight.goodPlayers, flyweight.badPlayers);
        }
    }
}