using BasicWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicWebServer.Demo.HTTP
{
    public class Header
    {
        public const string ContentType = "Content-Type";
        public const string ContentLenght = "Content-Lenght";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";


        public Header(string name, string value)
        {
            Guard.AgainsNull(name, nameof(name));
            Guard.AgainsNull(value, nameof(value));
            Name = name;
            Value = value;
        }
        public string Name { get; set; } // change set with init ?
        public string Value { get; set; }
        public override string ToString() =>
                        $"{this.Name}: {this.Value}";

    }
}
