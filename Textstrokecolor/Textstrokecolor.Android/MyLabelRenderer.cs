using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textstrokecolor;
using Textstrokecolor.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomLabel), typeof(MyLabelRenderer))]
namespace Textstrokecolor.Droid
{
    public class MyLabelRenderer : LabelRenderer
    {
        Context context;
        public MyLabelRenderer(Context context) : base(context)
        {
            this.context = context;
        }




        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MyCustomLabel customLabel = (MyCustomLabel)Element;
            var StrokeTextViewColor = customLabel.StrokeColor;

            int StrokeThickness = customLabel.StrokeThickness;
            if (Control != null)
            {

                StrokeTextView strokeTextView = new StrokeTextView(context, Control.TextSize, StrokeTextViewColor, StrokeThickness);
                strokeTextView.Text = e.NewElement.Text;
                strokeTextView.SetTextColor(Control.TextColors);

                SetNativeControl(strokeTextView);
            }
        }


    }
}