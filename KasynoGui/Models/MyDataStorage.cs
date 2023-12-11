using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KasynoGui.Models
{
    public class MyDataStorage
    {
        private static List<string> myDataList = new List<string>();

        public static List<string> GetMyDataList()
        {
            return myDataList;
        }

        public static void AddToMyDataList(string item)
        {
            myDataList.Add(item);
        }
    }
}