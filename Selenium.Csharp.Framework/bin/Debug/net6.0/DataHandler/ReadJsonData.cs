using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Selenium.Csharp.Framework.DataHandler
{
    public  class ReadJsonData
    {
      
        public static List<User> ReadJsonLoginArray()
        {
            string readvalues = File.ReadAllText("TestData/Login.Json");

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(readvalues);
            return myDeserializedClass.Users;
        }

     

    }
}
