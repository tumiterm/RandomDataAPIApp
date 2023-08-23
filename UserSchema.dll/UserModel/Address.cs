using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSchema.dll.UserModel
{
    public class Address
    {
        public string city { get; set; }
        public string street_name { get; set; }
        public string street_address { get; set; }
        public string zip_code { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public Coordinates coordinates { get; set; }
    }
}
