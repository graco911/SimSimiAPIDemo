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
using Java.Lang;
using SimSimiDemo.Models;
using Com.Github.Library.Bubbleview;

namespace SimSimiDemo.Adapters
{
    public class CustomAdapter : BaseAdapter
    {
        private List<ChatModel> ListChatModel;
        private Context Context;
        private LayoutInflater Inflater;

        public CustomAdapter(List<ChatModel> listchatmodel, Context context)
        {
            this.ListChatModel = listchatmodel;
            this.Context = context;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count
        {
            get
            {
                return ListChatModel.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                if (ListChatModel[position].IsSend)
                {
                    view = Inflater.Inflate(Resource.Layout.list_item_message_send, null);
                }
                else
                {
                    view = Inflater.Inflate(Resource.Layout.list_item_message_recv, null);
                }
                BubbleTextView bubbleTextView = view.FindViewById<BubbleTextView>(Resource.Id.text_message);
                bubbleTextView.Text =   (ListChatModel[position].ChatMessage); 
            }

            return view; 
        }
    }
}