using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo_UWP_SimpleConverter
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

        private async void SpeakButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(ConvertedValueTextBox.Text);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }


        private void InchesToFeetRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ValueToCovertTextBox.Text != "")
            {
                ConvertedValueTextBox.Text = (double.Parse(ValueToCovertTextBox.Text) / 12).ToString("0.00");
            }
        }

        private void FeetToInchesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ValueToCovertTextBox.Text != "")
            {
                ConvertedValueTextBox.Text = (double.Parse(ValueToCovertTextBox.Text) * 12).ToString("0.00");
            }
        }
    }
}
