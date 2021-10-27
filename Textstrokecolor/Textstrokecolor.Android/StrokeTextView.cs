﻿using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Graphics.Paint;
namespace Textstrokecolor.Droid
{
    class StrokeTextView : TextView
    {
        private TextView borderText = null;
        float OriTextSize;
        public StrokeTextView(Context context, float OriTextSize, string StrokeTextViewColor, int StrokeThickness) : base(context)
        {
            borderText = new TextView(context);

            borderText.TextSize = OriTextSize;
            this.TextSize = OriTextSize;

            init(StrokeTextViewColor, StrokeThickness);
        }
        public void init(string StrokeTextViewColor, int StrokeThickness)
        {
            TextPaint tp1 = borderText.Paint;
            tp1.StrokeWidth = StrokeThickness;         // sets the stroke width                        
            tp1.SetStyle(Style.Stroke);
            borderText.SetTextColor(Color.ParseColor(StrokeTextViewColor));  // set the stroke color
            borderText.Gravity = Gravity;

        }


        public override ViewGroup.LayoutParams LayoutParameters { get => base.LayoutParameters; set => base.LayoutParameters = value; }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            string tt = borderText.Text;


            if (tt == null || !tt.Equals(this.Text))
            {
                borderText.Text = Text;
                this.PostInvalidate();
            }

            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            borderText.Measure(widthMeasureSpec, heightMeasureSpec);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            borderText.Layout(left, top, right, bottom);
        }

        protected override void OnDraw(Canvas canvas)
        {
            borderText.Draw(canvas);
            base.OnDraw(canvas);
        }
    }
}