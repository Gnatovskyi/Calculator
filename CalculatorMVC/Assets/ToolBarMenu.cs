using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.Widget;

namespace CalculatorMVC.Assets
{
    static class ToolBarMenu
    {
        static public bool OptionSelectedItem(int ItemID, Context context, out Intent nextactivity, string content)
        {
            switch (ItemID)
            {
                case Resource.Id.calculator:
                    Toast.MakeText(context, "Calculator clicked", ToastLength.Short).Show();
                    nextactivity = new Intent(context, typeof(MainActivity));
                    nextactivity.PutExtra("content", content);
                    return true;
                case Resource.Id.convertor:
                    nextactivity = new Intent(context, typeof(ConvertorActivity));
                    Toast.MakeText(context, "Convertor clicked", ToastLength.Short).Show();
                    nextactivity.PutExtra("content", content);
                    return true;
                case Resource.Id.history:
                    nextactivity = new Intent(context, typeof(HistoryActivity));
                    Toast.MakeText(context, "History clicked", ToastLength.Short).Show();
                    return true;
                default:
                    {
                        nextactivity = null;
                        break;
                    }
            }            
            return false;
        }
    }
}