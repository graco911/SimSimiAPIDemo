using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using SimSimiDemo.Models;
using System.Collections.Generic;
using SimSimiDemo.Helpers;
using Newtonsoft.Json;
using SimSimiDemo.Adapters;

namespace SimSimiDemo
{
    [Activity(Label = "SimSimiDemo", MainLauncher = true, Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {

        public ListView list_of_messages;
        public EditText user_message;
        FloatingActionButton btn_send;

        public List<ChatModel> list_chat = new List<ChatModel>();
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

                list_chat.Add(model);
                new SimsimiAPI(this).Execute(user_message.Text);
            };

        }
    }

    internal class SimsimiAPI : AsyncTask<string, string, string>
    {
        private MainActivity mainActivity;
        private string API_KEY = "b95853ae-77f0-4015-a898-d6a430530671";

        public SimsimiAPI(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        protected override string RunInBackground(params string[] @params)
        {
            string url = string.Format("http://sandbox.api.simsimi.com/request.p?key={0}&lc=en&ft=1.0&text={1}", API_KEY, mainActivity.user_message.Text);

            HttpDataHandler dataHandler = new HttpDataHandler();
            return dataHandler.GetHTTPData(url);
        }

        protected override void OnPostExecute(string result)
        {
            SimsimiModel simsimiModel = JsonConvert.DeserializeObject<SimsimiModel>(result);

            ChatModel model = new ChatModel();
            model.ChatMessage = simsimiModel.response;
            model.IsSend = false;

            mainActivity.list_chat.Add(model);
            CustomAdapter adapter = new CustomAdapter(mainActivity.list_chat, mainActivity.BaseContext);
            mainActivity.list_of_messages.Adapter = adapter;
        }
    }
}

