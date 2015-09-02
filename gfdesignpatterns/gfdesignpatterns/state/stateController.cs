using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.state
{
    public class stateController
    {
    }



    public class twoKeyDictionary
    {
        private static twoKeyDictionary _manager;
        public static twoKeyDictionary Instance
        {

            get
            {

                if (_manager == null)
                {
                    _manager = new twoKeyDictionary();
                }

                return _manager;

            }
        }

        public List<Operation> convertionDictionary;

        public twoKeyDictionary()
        {
            convertionDictionary = new List<Operation>();
        }

        public void add(string key1, string key2, double value)
        {
            convertionDictionary.Add(new Operation { from = key1, to = key2, OperatorValue = value, visited = false });
            convertionDictionary.Add(new Operation { from = key2, to = key1, OperatorValue = 1 / value, visited = false });
            //convertionDictionary.Add( new Operation { from = key2, to = key2, OperatorValue = 1, visited = false });
            //convertionDictionary.Add( new Operation { from = key1, to = key1, OperatorValue = 1, visited = false });
        }

        public string convert(string from, string to, double value)
        {
            foreach (var entry in convertionDictionary)
            {
                entry.visited = false;
            }
            if (from.Equals(to))
            {
                return "1.0";
            }
            var resultDouble = converterTool(from, to, value);
            if (resultDouble != null)
            {
                return resultDouble.ToString();
            }
            else
            {
                return "There was an error";
            }

        }

        public double? converterTool(string from, string to, double value)
        {
            var newDictionary = convertionDictionary.Where(t => t.from.Equals(from) && t.visited == false);
            var currentNewDictionary = newDictionary.ToList();
            if (newDictionary.Count() > 0)
            {
                var values = new List<double?>();
                foreach (var entry in newDictionary)
                {
                    entry.visited = true;
                    if (entry.to.Equals(to))
                    {
                        values.Add(entry.OperatorValue);
                    }

                }
                var possibleValueList = values.Where(t => t != null).Distinct();
                if (possibleValueList.Distinct().Count() ==0)
                {
                    foreach (var entry in currentNewDictionary)
                    {
                        var recersConvert = converterTool(entry.to, to, value);
                        values.Add(recersConvert != null ? (recersConvert * entry.OperatorValue) : null);
                    }
                }

                possibleValueList = values.Where(t => t != null).Distinct();
                if (possibleValueList.Distinct().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return possibleValueList.ElementAt(0) * value;
                }
            }
            return null;
        }
    }


    public class Operation
    {
        public string to;
        public string from;
        public double OperatorValue;
        public bool visited;
    }

}