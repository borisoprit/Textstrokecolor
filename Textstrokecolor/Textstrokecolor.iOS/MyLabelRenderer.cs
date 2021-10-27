using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Textstrokecolor;
using Textstrokecolor.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyCustomLabel), typeof(MyLabelRenderer))]
namespace Textstrokecolor.iOS
{
    class MyLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MyCustomLabel myCustomLabel = Element as MyCustomLabel;


            if (Control != null)
            {
                UIStringAttributes strokeTextAttributes = new UIStringAttributes();
                // Here is set the StrokeColor

                strokeTextAttributes.StrokeColor = Color.FromHex(myCustomLabel.StrokeColor).ToUIColor(); ;
                //Here is set the StrokeThickness, IOS is diferert from the android, it border is set to the inside the font.
                strokeTextAttributes.StrokeWidth = -1 * myCustomLabel.StrokeThickness;

                Control.AttributedText = new NSAttributedString(Control.Text, strokeTextAttributes);
               //Control.TextColor = UIColor.Black;
                Control.TextColor = UIColor.Yellow;
            }
        }
    }

}