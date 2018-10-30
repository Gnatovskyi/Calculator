using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Text;
using CalculatorMVC.Models;
using Android.Widget;
using Java.Interop;
using System;
using System.Data;

namespace CalculatorMVC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText content;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            content = (EditText)FindViewById(Resource.Id.content);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tollbar);
            SupportActionBar.Title = "Calculator";
            //-----------------------REMOVE CURSOR----------------
            content.SetCursorVisible(false);
            content.InputType = InputTypes.Null;
            content.Text = Intent.GetStringExtra("content");
            //-----------------------TEXTCHANGE-----------------------
            content.TextChanged += delegate
            {
                if (content.Text.Equals(""))
                {
                    KeyboardClick.operand = "";
                }
                string x = content.Text;
                try
                {
                    double result = Convert.ToDouble(new DataTable().Compute(x, null));
                    KeyboardClick.operand = result.ToString();
                }
                catch
                {
                }
            };
        }

        [Export("OnClickNumber")]
        public void OnClickNumber(View v)
        {
            KeyboardClick.ClickNumber(v, ref content);
        }

        [Export("OnClickOperation")]
        public void OnClickOperation(View v)
        {
            KeyboardClick.ClickOperation(v, ref content);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ToolBarMenu.OptionSelectedItem(item.ItemId, this, out Intent intent, content.Text))
            {
                StartActivity(intent);
                OnStop();
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}