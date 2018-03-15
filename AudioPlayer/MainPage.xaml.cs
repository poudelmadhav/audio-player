using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AudioPlayer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPreview.Play();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaPreview.Pause();
        }

        async private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            // Represents the UI element that lets the uset choose and open files
            FileOpenPicker openPicker = new FileOpenPicker();
            // PickerLocation:Identifies the storage location that file picker presents to user
            openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
            openPicker.FileTypeFilter.Add(".mwv");
            openPicker.FileTypeFilter.Add(".mp4");
            openPicker.FileTypeFilter.Add(".3gp");
            openPicker.FileTypeFilter.Add(".mp3");
            // PickSingleFileAsync: Shows the file picker so that the user can pick the file
            var file = await openPicker.PickSingleFileAsync();
            // media is a MediaElement defined in XAML
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            mediaPreview.SetSource(stream, file.ContentType);
            mediaPreview.Play();
        }
    }
}
