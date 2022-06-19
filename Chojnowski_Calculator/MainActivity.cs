using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Chojnowski_Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        string operation = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        
            Button button0 = FindViewById<Button>(Resource.Id.button0);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);

            Button buttonPlus = FindViewById<Button>(Resource.Id.buttonsign1);
            Button buttonMinus = FindViewById<Button>(Resource.Id.buttonsign2);
            Button buttonTimes = FindViewById<Button>(Resource.Id.buttonsign3);
            Button buttonDivision = FindViewById<Button>(Resource.Id.buttonsign4);

            Button buttonComma  = FindViewById<Button>(Resource.Id.buttoncomma);

            Button buttonEnter = FindViewById<Button>(Resource.Id.buttonenter);
            Button buttonClear = FindViewById<Button>(Resource.Id.buttonclear);
            Button buttonClearAll = FindViewById<Button>(Resource.Id.buttonclearall);

            button0.Click += Event0;
            button1.Click += Event1;
            button2.Click += Event2;
            button3.Click += Event3;
            button4.Click += Event4;
            button5.Click += Event5;
            button6.Click += Event6;
            button7.Click += Event7;
            button8.Click += Event8;
            button9.Click += Event9;

            buttonPlus.Click += EventPlus;
            buttonMinus.Click += EventMinus;
            buttonTimes.Click += EventTimes;
            buttonDivision.Click += EventDivision;

            buttonComma.Click += EventComma;


            buttonClear.Click += EventClear;
            buttonClearAll.Click += EventClearAll;
            buttonEnter.Click += EventEnter;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void Event0(object sender, EventArgs e)
        {
            AddChar('0');
        }
        private void Event1(object sender, EventArgs e)
        {
            AddChar('1');
        }
        private void Event2(object sender, EventArgs e)
        {
            AddChar('2');
        }
        private void Event3(object sender, EventArgs e)
        {
            AddChar('3');
        }
        private void Event4(object sender, EventArgs e)
        {
            AddChar('4');
        }
        private void Event5(object sender, EventArgs e)
        {
            AddChar('5');
        }
        private void Event6(object sender, EventArgs e)
        {
            AddChar('6');
        }
        private void Event7(object sender, EventArgs e)
        {
            AddChar('7');
        }
        private void Event8(object sender, EventArgs e)
        {
            AddChar('8');
        }
        private void Event9(object sender, EventArgs e)
        {
            AddChar('9');
        }
        private void EventPlus(object sender, EventArgs e)
        {
            AddChar('+');
        }
        private void EventMinus(object sender, EventArgs e)
        {
            AddChar('-');
        }
        private void EventTimes(object sender, EventArgs e)
        {
            AddChar('*');
        }
        private void EventDivision(object sender, EventArgs e)
        {
            AddChar('/');
        }
        private void EventComma(object sender, EventArgs e)
        {
            AddChar('.');
        }
        private void EventEnter(object sender, EventArgs e)
        {
            DisplayResult();
        }
        private void EventClear(object sender, EventArgs e)
        {
            if(operation.Length >= 1)
                operation = operation.Remove(operation.Length - 1);
            DisplayString();
        }
        private void EventClearAll(object sender, EventArgs e)
        {
            TextView operationText = FindViewById<TextView>(Resource.Id.textView1);
            TextView resultText = FindViewById<TextView>(Resource.Id.textView2);

            operationText.Text = "";
            resultText.Text = "";

            operation = "";
        }

        private void AddChar(char ch)
        {
             operation += ch;
            DisplayString();
        }
        private void DisplayString()
        {
            TextView operationText = FindViewById<TextView>(Resource.Id.textView1);
            operationText.Text = operation;
        }
        private void DisplayResult()
        {
            TextView resultText = FindViewById<TextView>(Resource.Id.textView2);
            string formula = operation; //or get it from DB
            StringToFormula stf = new StringToFormula();
            double result = stf.Eval(formula);
            resultText.Text = result.ToString();
        }
    }
}