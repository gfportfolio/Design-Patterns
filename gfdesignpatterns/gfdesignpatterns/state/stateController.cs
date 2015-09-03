using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gfdesignpatterns.state
{
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

        public Dictionary<string, Operator> convertionDictionary;

        public twoKeyDictionary()
        {
            convertionDictionary = new Dictionary<string, Operator>();
        }

        public void add(string key1, string key2, double value)
        {
            addEntry(key1, key2, value);
            addEntry(key2, key1, 1 / value);
            addEntry(key1, key1, 1);
            addEntry(key2, key2, 1);
        }

        public void addEntry(string key1, string key2, double value)
        {
            Operator currentDictionaryState;
            if (convertionDictionary.ContainsKey(key1))
            {
                currentDictionaryState = convertionDictionary[key1];
            }
            else
            {
                currentDictionaryState = new Operator();
                convertionDictionary.Add(key1, currentDictionaryState);
            }
            if (!currentDictionaryState.operations.ContainsKey(key2))
            {
                currentDictionaryState.operations.Add(key2, value);
            }
        }


        public string convert(string from, string to, double value)
        {
            foreach (var entry in convertionDictionary)
            {
                entry.Value.visited = false;
            }
            //if (from.Equals(to))
            //{
            //    return "1.0";
            //}
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
            if (!convertionDictionary.ContainsKey(from) || convertionDictionary[from].visited == true)
            {
                return null;
            }

            var values = new List<double?>();
            var currentState = convertionDictionary[from];
            currentState.visited = true;
            if (currentState.operations.ContainsKey(to))
            {
                values.Add(currentState.operations[to]);
            }
            var possibleValueList = values.Where(t => t != null).Distinct();
            if (possibleValueList.Distinct().Count() == 0)
            {
                foreach (var opperation in currentState.operations)
                {
                    values.Add(converterTool(opperation.Key, to, opperation.Value));
                }
            }
            if (possibleValueList.Distinct().Count() != 0)
            {
                return possibleValueList.ElementAt(0) * value;
            }

            return null;
        }
    }

    public class OperationVisitor
    {
        private string _from;
        private string _to;
        private double _value;
        private List<string> visited;
        public OperationVisitor(string from, string to, double value)
        {
            _from = from;
            _to = to;
            _value = value;
            visited = new List<string>();
        }


    }

    public class Operator
    {
        public Dictionary<string, double> operations = new Dictionary<string, double>();
    }
}