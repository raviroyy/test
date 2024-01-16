using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{


    public class StoreMethod
    {
        //Dictionary represent to store key and its value
        Dictionary<string, string> VarDetail = new Dictionary<string, string>();


        public void StoreVar(String methodName, String methodValue)
        {
            VarDetail.Add(methodName, methodValue); //add specific key and value of given method to the Dictionary
        }


        public String GetVar(String methodName)
        {
            String x;
            VarDetail.TryGetValue(methodName, out x); //get value from specific key
            return x;
        }


        public bool VarExists(String methodName)
        {
            String x;
            return VarDetail.TryGetValue(methodName, out x);
        }


        public void Reset()
        {
            VarDetail.Clear(); //Remove all keys and value from Dictionary
        }
    }
}