using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CalculatorMVC.Assets;
using CalculatorMVC.Resources.Models;

namespace CalculatorMVC
{
    [Activity(Label = "History")]
    public class HistoryActivity : AppCompatActivity
    {
        List<string> items = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_history);
            ListView view = FindViewById<ListView>(Resource.Id.information);
            Database db = new Database();
            db.Select().ForEach(x => items.Add(x.ToString()));
            var adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
            view.Adapter = adapter;
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ToolBarMenu.OptionSelectedItem(item.ItemId, this, out Intent intent, null))
            {
                StartActivity(intent);
                OnStop();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}