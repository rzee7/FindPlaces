using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace FindPlaces.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //Theme
            var tintColor = UIColor.FromRGB(69, 90, 100);
            UINavigationBar.Appearance.BarTintColor = tintColor;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                ForegroundColor = UIColor.White
            };

            //UIProgressView.Appearance.ProgressTintColor = tintColor;

            //UISlider.Appearance.MinimumTrackTintColor = tintColor;
            //UISlider.Appearance.MaximumTrackTintColor = tintColor;
            //UISlider.Appearance.ThumbTintColor = tintColor;

            //UISwitch.Appearance.OnTintColor = tintColor;

            //UITableViewHeaderFooterView.Appearance.TintColor = tintColor;

            ////UITableView.Appearance.SectionIndexBackgroundColor = AccentColor;
            ////UITableView.Appearance.SeparatorColor = AccentColor;

            //UITextField.Appearance.TintColor = tintColor;

            //UIButton.Appearance.TintColor = tintColor;
            //UIButton.Appearance.SetTitleColor(tintColor, UIControlState.Normal);

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
