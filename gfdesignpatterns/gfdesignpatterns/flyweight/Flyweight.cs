using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.flyweight
{
    public class Flyweight
    {
       public string battle(player attacher1, player attacker2)
        {
            var attacker1Power = attacher1.getPower();
            var attecker2Power = attacker2.getPower();
            attacher1.battle(attecker2Power);
            attacker2.battle(attacker1Power);


            return attacher1.printStatus() + "<br>" + attacker2.printStatus();
        }

        public List<player> goodPlayers;
        public List<player> badPlayers;

        public void setUpPlayers()
        {
            goodPlayers = new List<player>();
            badPlayers = new List<player>();

            goodPlayers.Add(new player(20, 0, "Woody", true, "https://en.wikipedia.org/wiki/Sheriff_Woody#/media/File:Sheriff_Woody.png"));
            goodPlayers.Add(new player(20, 0, "Marida", true, "http://vignette1.wikia.nocookie.net/fantendo/images/e/ea/Merida-brave-32114600-750-835.png/revision/latest?cb=20130519175742"));
            goodPlayers.Add(new player(20, 0, "Dash", true, "http://toons.mit.edu/images/5/55/Dash.png"));
            goodPlayers.Add(new player(20, 0, "Lightning McQueen", true, "http://vignette4.wikia.nocookie.net/pixar/images/4/4c/Lightning_mcqueen_radiator_springs.png/revision/20110522163606"));
            goodPlayers.Add(new player(20, 0, "Sully", true, "http://img3.wikia.nocookie.net/__cb20130414194442/disney/images/3/3b/Sully.png"));

            badPlayers.Add(new player(20, 0, "Hamm", true, "http://img2.wikia.nocookie.net/__cb20121107235208/disney/images/a/a8/Ham.png"));
            badPlayers.Add(new player(20, 0, "Witch", true, "http://vignette1.wikia.nocookie.net/brave/images/0/0b/Witch_n_crow.png/revision/latest?cb=20130104232023"));
            badPlayers.Add(new player(20, 0, "Syndrome", true, "http://img1.wikia.nocookie.net/__cb20150201012340/disney/images/f/fa/500px-Syndrome.png"));
            badPlayers.Add(new player(20, 0, "Chick", true, "http://images2.wikia.nocookie.net/__cb20130712080905/disney/images/1/1e/Chick_Hicks.png"));
            badPlayers.Add(new player(20, 0, "Randell", true, "http://custom-brainrolls.brainient.com/_monsters_inc/images/tech/_medium/characters/randall.png"));

        }
    }

    public class player
    {
        private int _life;
        public int life  { get { return _life; } set { _life = value; } }
        private int _strength;
        public int strenth { get { return _strength; } }
        private string _name;
        public string name { get { return _name; } }
        private bool _alive;
        public bool alive { get { return _alive; } set { _alive = value; } }
        private bool _good;
        public bool good { get { return _good; } }
        private string _image;


        public player(int life, int strenth, string name, bool good, string image)
        {
            _life = life;
            _strength = strenth;
            _name = name;
            _alive = true;
            _good = good;
            _image = image;
        }

        public void battle(int attackerPower)
        {
            life -= attackerPower / strenth;
            if (life <= 0)
            {
                alive = false;
                life = 0;
            }
        }

        public int getPower()
        {
            return strenth * life;
        }

        public string printStatus()
        {
            if (alive)
            {
                return String.Format("{0} survived the battle and has {1} life left", name, life );
            }
            else
            {
                return String.Format("{0} has died in the battle", name);
            }
        }

    }
}