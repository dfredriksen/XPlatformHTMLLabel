using System.ComponentModel;
using System;
using Android.Text;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CYINT.XPlatformHTMLLabel;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(AndroidHtmlLabelRenderer))]

namespace CYINT.XPlatformHTMLLabel
{
    public class AndroidHtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Control?.SetText(FromHtml(Element.Text), TextView.BufferType.Spannable);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                Control?.SetText(FromHtml(Element.Text), TextView.BufferType.Spannable);
            }
        }
        
        //Disable deprecation warnings
        #pragma warning disable 612, 618
        protected ISpanned FromHtml(String strHtml)
        {
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.Build.VERSION_CODES.N)
                return Html.FromHtml(strHtml,Html.FromHtmlModeLegacy);

            return Html.FromHtml(strHtml);
        }
    }
}
