using System;
using System.Data;
using Android.Views;
using SQLite;
using Android.Widget;
using CalculatorMVC.Resources.Models;

namespace CalculatorMVC.Assets
{
    static class Calculation
    {
        private static Database database = new Database();
        private static bool dotFlag;
        private static bool resultFlag;
        public static string operand = "";
        public static void ClickNumber(View v, ref EditText content)
        {
            var btn = (Button)v;
            if(resultFlag) { content.Text = ""; resultFlag = false; }
            if (btn != null) { AddTextInContent(btn.Text, ref content, TypeOperation.NumberClick); }
        }
        public static void ClickOperation(View v, ref EditText content)
        {
            var btn = (Button)v;
            switch (btn.Id)
            {
                case Resource.Id.btndot:
                    AddDot(btn, ref content);
                    return;
                case Resource.Id.btnallclear:
                    AllClear(ref content);
                    return;
                case Resource.Id.btnclear:
                    ClearChar(ref content);
                    return;
                case Resource.Id.btnsub:
                    Sub(btn, ref content);
                    return;
                case Resource.Id.btndiv:
                    Div(btn, ref content);
                    return;
                case Resource.Id.btnmult:
                    Mult(btn, ref content);
                    return;
                case Resource.Id.btnadd:
                    Add(btn, ref content);
                    return;
                case Resource.Id.btnresult:
                    Result(ref content);
                    return;
            }
        }

        private static bool AddTextInContent(string btnText , ref EditText content, TypeOperation type)
        {
            switch (type)
            {
                case TypeOperation.NumberClick when content.Text.Length < 24:
                    if (content.Text.Length == 1 && content.Text == "0")
                    {
                        content.Text += ".";
                    }
                    content.Text += btnText;
                    resultFlag = false;
                    return true;
                case TypeOperation.OperationClick when content.Text.Length < 23:
                    content.Text += btnText;
                    return true;
                default: return false;
            }
        }

        private static void AllClear(ref EditText content)
        {
            if (!operand.Equals("") || !content.Text.Equals(""))
            {
                operand = "";
                dotFlag = false;
                content.Text = "";
            }
        }
        private static void ClearChar(ref EditText content)
        {
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(0, l - 1);
                content.Text = x2;
                if (x2.Length != 0)
                {
                    string x3 = x2.Substring(l - 2, 1);
                    if (x3.Equals("+") || x3.Equals("-") || x3.Equals("*") || x3.Equals("/") || x3.Equals("."))
                    {
                        try
                        {
                            if (x3.Equals(".")) dotFlag = false;
                            double result = Convert.ToDouble(new DataTable().Compute(x.Substring(0, l - 2), null));
                            operand = result.ToString();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private static void Result(ref EditText content)
        {
            if (!operand.Equals(""))
            {
                if (operand.Length > 23)
                {
                    operand = operand.Substring(0, 23);
                }
                History history = new History
                {
                    Equation = content.Text,
                    Result = operand
                };
                database.Insert(history);
                content.Text = operand;
                if (dotFlag) dotFlag = false;
                resultFlag = true;
                operand = "";
            }
        }

        private static void AddDot(Button btn, ref EditText content)
        {
            resultFlag = false;
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(l - 1, 1);
                if (!x2.Equals("."))
                {
                    if (x2 == "-" || x2 == "*" || x2 == "/" || x2 == "+")
                    {
                        string s1 = x.Substring(0, l - 1);
                        content.Text = s1;
                    }
                    if (!dotFlag)
                    {
                        AddTextInContent(btn.Text, ref content, TypeOperation.OperationClick);
                        dotFlag = true;
                    }
                }
            }
            else
            {
                content.Text += "0.";
                dotFlag = true;
            }
        }        
        private static void Sub(Button btn, ref EditText content)
        {
            resultFlag = false;
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(l - 1, 1);
                if (!x2.Equals("-"))
                {
                    if (x2.Equals("+") || x2.Equals("*") || x2.Equals("/") || x2.Equals("."))
                    {
                        string s1 = x.Substring(0, l - 1);
                        content.Text = s1;
                    }
                    if (dotFlag) dotFlag = false;
                    AddTextInContent(btn.Text, ref content, TypeOperation.OperationClick);
                }
            }
        }
        private static void Div(Button btn, ref EditText content)
        {
            resultFlag = false;
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(l - 1, 1);
                if (!x2.Equals("/"))
                {
                    if (x2.Equals("-") || x2.Equals("*") || x2.Equals("+") || x2.Equals("."))
                    {
                        string s1 = x.Substring(0, l - 1);
                        content.Text = s1;
                    }
                    if (dotFlag) dotFlag = false;
                    AddTextInContent(btn.Text, ref content, TypeOperation.OperationClick);
                }
            }
        }
        private static void Mult(Button btn, ref EditText content)
        {
            resultFlag = false;
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(l - 1, 1);
                if (!x2.Equals("*"))
                {
                    if (x2 == "-" || x2 == "+" || x2 == "/" || x2 == ".")
                    {
                        string s1 = x.Substring(0, l - 1);
                        content.Text = s1;
                    }
                    if (dotFlag) dotFlag = false;
                    AddTextInContent(btn.Text, ref content, TypeOperation.OperationClick);
                }
            }
        }
        private static void Add(Button btn, ref EditText content)
        {
            resultFlag = false;
            string x = content.Text;
            int l = x.Length;
            if (l != 0)
            {
                string x2 = x.Substring(l - 1, 1);
                if (!x2.Equals("+"))
                {
                    if (x2.Equals("-") || x2.Equals("*") || x2.Equals("/") || x2.Equals("."))
                    {
                        string s1 = x.Substring(0, l - 1);
                        content.Text = s1;
                    }
                    if (dotFlag) dotFlag = false;
                    AddTextInContent(btn.Text, ref content, TypeOperation.OperationClick);
                }
            }
        }
    }
}