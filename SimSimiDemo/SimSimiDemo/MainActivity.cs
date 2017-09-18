using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using SimSimiDemo.Models;
using System.Collections.Generic;

namespace SimSimiDemo
{
    [Activity(Label = "SimSimiDemo", MainLauncher = true, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {

        ListView list_of_messages;
        EditText user_message;
        FloatingActionButton btn_send;

        List<ChatModel> list_chat = new List<ChatModel>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            list_of_messages = FindViewById<ListView>(Resource.Id.list_of_message);
            user_message = FindViewById<EditText>(Resource.Id.user_message);
            btn_send = FindViewById<FloatingActionButton>(Resource.Id.fab);

            btn_send.Click += delegate
            {
                string text = user_message.Text;
                ChatModel model = new ChatModel();
                model.ChatMessage = text;
                model.IsSend = true;
            };

        }
    }
}

