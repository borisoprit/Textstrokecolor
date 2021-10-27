using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Textstrokecolor
{
    public class MyCustomLabel : Label
    {


        public static readonly BindableProperty StrokeColorProperty = BindableProperty.CreateAttached("StrokeColor", typeof(string), typeof(MyCustomLabel), "");
        public string StrokeColor
        {
            get { return base.GetValue(StrokeColorProperty).ToString(); }
            set { base.SetValue(StrokeColorProperty, value); }
        }

        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.CreateAttached("StrokeThickness", typeof(int), typeof(MyCustomLabel), 0);
        public int StrokeThickness
        {
            get { return (int)base.GetValue(StrokeThicknessProperty); }
            set { base.SetValue(StrokeThicknessProperty, value); }
        }
    }
}