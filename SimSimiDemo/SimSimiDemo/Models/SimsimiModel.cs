using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SimSimiDemo.Models
{
    public class SimsimiModel
    {
        public string response { get; set; }
        public string id { get; set; }
        public int result { get; set; }
        public string msg { get; set; }
    }
}