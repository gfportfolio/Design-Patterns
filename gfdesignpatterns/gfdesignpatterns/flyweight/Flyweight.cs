using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.flyweight
{
    public class Flyweight
    {
       

    }

    public abstract class player
    {
        private int _strength;
        public int strenth { get { return _strength; } set { _strength = value; } }
        private string _name;
        public string name { get { return _name; } }
        private bool _alive;
        public bool alive { get { return _alive; } set { _alive = value; } }
        private bool _good;
        public bool good { get { return _good; } }
        private string _image;


        public player(int strenth, string name, bool good, string image)
        {
            _strength = strenth;
            _name = name;
            _alive = true;
            _good = good;
            _image = image;
        }



    }
}