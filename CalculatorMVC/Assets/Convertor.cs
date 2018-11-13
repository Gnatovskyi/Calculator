using System;
using Android.Widget;

namespace CalculatorMVC.Assets
{
    static class Convertor
    {
        public static void Submit(ref EditText content, Spinner sp1, Spinner sp2, int ItemPos, int JtemPos)
        {
            if ((!content.Text.Equals("")))
            {
                    Double.TryParse(content.Text, out double inputed);
                switch (sp1.GetItemAtPosition(ItemPos).ToString())
                {
                    case ("Second"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {
                            case ("Minute"):
                                content.Text = (inputed / 60).ToString();
                                break;
                            case ("Hour"):
                                content.Text = (inputed / 3600).ToString();
                                break;
                        }
                        break;

                    case ("Minute"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {
                            case ("Second"):
                                content.Text = (inputed * 60).ToString();
                                break;

                            case ("Hour"):
                                content.Text = (inputed / 60).ToString();
                                break;
                        }
                        break;

                    case ("Hour"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("Second"):
                                content.Text = (inputed * 3600).ToString();
                                break;

                            case ("Minute"):
                                content.Text = (inputed * 60).ToString();
                                break;
                        }
                        break;

                    case ("Gram"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("Kilogram"):
                                content.Text = (inputed / 1000).ToString();
                                break;

                            case ("Centner"):
                                content.Text = (inputed / 10000).ToString();
                                break;
                        }
                        break;

                    case ("Kilogram"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("Gram"):
                                content.Text = (inputed * 1000).ToString();
                                break;

                            case ("Centner"):
                                content.Text = (inputed / 10).ToString();
                                break;
                        }
                        break;

                    case ("Centner"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("Gram"):
                                content.Text = (inputed * 10000).ToString();
                                break;

                            case ("Kilogram"):
                                content.Text = (inputed * 10).ToString();
                                break;
                        }
                        break;

                    case ("M/s"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("Km/h"):
                                content.Text = (inputed * 3.6).ToString();
                                break;

                            case ("Ml/h"):
                                content.Text = (inputed * 2.237).ToString();
                                break;
                        }
                        break;

                    case ("Km/h"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("M/s"):
                                content.Text = (inputed / 3.6).ToString();
                                break;

                            case ("Ml/h"):
                                content.Text = (inputed * 1.609).ToString();
                                break;
                        }
                        break;

                    case ("Ml/h"):
                        switch (sp2.GetItemAtPosition(JtemPos).ToString())
                        {

                            case ("M/s"):
                                content.Text = (inputed / 2.237).ToString();
                                break;

                            case ("Km/h"):
                                content.Text = (inputed / 1.609).ToString();
                                break;
                        }
                        break;
                }
            }
        }
        public static void ReloadSpinnerItem(ref Spinner sp1, ref Spinner sp2, ArrayAdapter type)
        {
            sp1.Adapter = type;
            sp2.Adapter = type;
        }
    }
}