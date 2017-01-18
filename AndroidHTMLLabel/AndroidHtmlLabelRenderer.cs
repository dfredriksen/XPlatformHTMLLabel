using System.ComponentModel;
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
        protected SpannedString FromHtml(string html)
        {
            SpannedString result;
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.Build.VERSION_CODES.N)
            {
                result = (SpannedString)Html.FromHtml(html,Html.FromHtmlModeLegacy);
            }
            else
            {
                result = (SpannedString)Html.FromHtml(html);
            }

            return result;
        }
    }
}
