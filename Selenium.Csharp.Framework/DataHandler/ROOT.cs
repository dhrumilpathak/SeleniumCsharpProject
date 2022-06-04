using System;
using System.Collections.Generic;

namespace Selenium.Csharp.Framework.DataHandler
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class  User
    {
        public string Username { get; set; }
        public string password { get; set; }
    }

    public class Root
    {
        public List<User> Users { get; set; }
    }


}
