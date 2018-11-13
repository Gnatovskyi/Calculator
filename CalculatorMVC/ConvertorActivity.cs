using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using CalculatorMVC.Assets;
using Java.Interop;

namespace CalculatorMVC
{
    [Activity(Label = "ConvertorActivity")]
    public class ConvertorActivity : AppCompatActivity
    {
        EditText _content;
        Spinner _typeSpinner;
        Spinner _v1Spinner;
        Spinner _v2Spinner;
        ArrayAdapter _typeValues, 
            _timeAdapter, 
            _weightAdapter, 
            _speedAdapter;
        int Item1;
        int Item2;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_convertor);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.tollbar);
            _content = FindViewById<EditText>(Resource.Id.content);
            SupportActionBar.Title = "Convertor";

            //-----------------------REMOVE CURSOR----------------
            _content.SetCursorVisible(false);
            _content.InputType = InputTypes.Null;
            //-----------------------SPENNERS---------------------
            _typeSpinner = FindViewById<Spinner>(Resource.Id.spinner1);
            _v1Spinner = FindViewById<Spinner>(Resource.Id.spinner2);
            _v2Spinner = FindViewById<Spinner>(Resource.Id.spinner3);

            _typeSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerItemSelected);
            _v1Spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ItemSelected);
            _v2Spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(ItemSelected);

            //---------------------ADAPTERS------------------------
            _typeValues = ArrayAdapter.CreateFromResource(this, Resource.Array.typearray, Android.Resource.Layout.SimpleSpinnerItem);
            _typeValues.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _timeAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timearray, Android.Resource.Layout.SimpleSpinnerItem);
            _timeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _weightAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.weightarray, Android.Resource.Layout.SimpleSpinnerItem);
            _weightAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _speedAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.speedarray, Android.Resource.Layout.SimpleSpinnerItem);
            _speedAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            _typeSpinner.Adapter = _typeValues;

            //--------------Bundle------------
            _content.Text = Intent.GetStringExtra("content");
        }
        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            String[] choose = Resources.GetStringArray(Resource.Array.typearray);
            switch (choose[e.Position])
            {
                case "Time":
                    Convertor.ReloadSpinnerItem(ref _v1Spinner, ref _v2Spinner, _timeAdapter);
                    break;
                case "Weight":
                    Convertor.ReloadSpinnerItem(ref _v1Spinner, ref _v2Spinner, _weightAdapter);
                    break;
                case "Speed":
                    Convertor.ReloadSpinnerItem(ref _v1Spinner, ref _v2Spinner, _speedAdapter);
                    break;
            }
        }
        private void ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner sp = (Spinner)sender;
            switch (sp.Id)
            {
                case Resource.Id.spinner2:
                    Item1 = e.Position;
                    break;
                case Resource.Id.spinner3:
                    Item2 = e.Position;
                    break;
            }
        }


        [Export("OnClickNumber")]
        public void OnClickNumber(View v)
        {
           Calculation.ClickNumber(v, ref _content);
        }
        [Export("OnClickOperation")]
        public void OnClickOperation(View v)
        {
           Calculation.ClickOperation(v, ref _content);
        }
        [Export("OnClickSubmit")]
        public void OnClickSubmit(View v)
        {
            Convertor.Submit(ref _content, _v1Spinner, _v2Spinner, Item1, Item2);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (ToolBarMenu.OptionSelectedItem(item.ItemId, this, out Intent intent, _content.Text))
            {
                StartActivity(intent);
                OnStop();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}