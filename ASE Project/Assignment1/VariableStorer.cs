using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    public class VariableStorer
    {
        //Dictionary represent to store key and its value
        Dictionary<string, int> VarDetail = new Dictionary<string, int>();


        public void StoreVar(String varName, int varValue)
        {
            VarDetail.Add(varName, varValue); //add specific key and value to the Dictionary
        }


        public int GetVar(String varName)
        {
            int x;
            VarDetail.TryGetValue(varName, out x); //get value from specific key
            return x;
        }


        public void EditVar(String varName, int varValue)
        {
            VarDetail[varName] = varValue; //update value if needed
        }


        public bool VarExists(String varName)
        {
            int x;
            return VarDetail.TryGetValue(varName, out x);
        }


        public void Reset()
        {
            VarDetail.Clear(); //Remove all keys and value from Dictionary
        }
    }
}