using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSchema.dll.UserModel
{
    public class Subscription
    {
        public string plan { get; set; }
        public string status { get; set; }
        public string payment_method { get; set; }
        public string term { get; set; }
    }
}
