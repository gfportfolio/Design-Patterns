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
            
            setupJson(flyweight.goodPlayers, flyweight.badPlayers, flyweight);

        }

        private void setupJson(List<flyweight.player> good, List<flyweight.player> bad, Flyweight flyweight)
        {
            JsonGoodPlayers = generateJsonFromFlyweightPlayers(good, flyweight);
            JsonBadPlayers = generateJsonFromFlyweightPlayers(bad, flyweight);
        }

        protected void playerButton_Click(object sender, EventArgs e)
        {
            var buttonId = ((Button)sender).ID;
            var number = int.Parse(buttonId.Remove(0, 6));
            var flyweight = Flyweight.Instance;
            var result = flyweight.round(number);
            log.Text = result;
            setupJson(flyweight.goodPlayers, flyweight.badPlayers, flyweight);
        }


        public string generateJsonFromFlyweightPlayers(List<flyweight.player> players, Flyweight flyweight)
        {
            var pocos = new List<flyweightPoco>();
            foreach (var player in players){
                var poco = new flyweightPoco();
                poco.name = player.name;
                poco.image = flyweight.flyweightPlayers[player.name].image;
                poco.life = player.life;
                poco.strength = flyweight.flyweightPlayers[player.name].strength;
                pocos.Add(poco);
            }
            return JsonConvert.SerializeObject(pocos);
        }
        protected class flyweightPoco{
            public string name;
            public string image;
            public int life;
            public int strength;
            }

    }
}