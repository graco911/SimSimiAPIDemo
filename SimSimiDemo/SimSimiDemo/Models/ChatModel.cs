﻿using System;
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
    public class ChatModel
    {
        public string ChatMessage { get; set; }
        public bool IsSend { get; set; }
    }
}