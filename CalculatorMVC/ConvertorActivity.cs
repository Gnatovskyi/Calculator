using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using CalculatorMVC.Models;
using Java.Interop;

namespace CalculatorMVC
{
    [Activity(Label = "ConvertorActivity")]
    public class ConvertorActivity : AppCompatActivity
    {
        EditText content;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_convertor);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tollbar);
            SupportActionBar.Title = "Convertor";

            

        }
        [Export("OnClickNumber")]
        public void OnClickNumber(View v)
        {
            KeyboardClick.ClickNumber(v, ref content);
        }

        [Export("OnClickSubmit")]
        public void OnClickSubmit(View v)
        {

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ToolBarMenu.OptionSelectedItem(item.ItemId, this, out Intent intent))
            {
                StartActivity(intent);
                OnStop();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}