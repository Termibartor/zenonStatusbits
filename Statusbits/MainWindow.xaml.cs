using Statusbits.Controller;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.Diagnostics;
using WK.Libraries.SharpClipboardNS;

namespace Statusbits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StatusbitsController controller;
        private SharpClipboard clipboard = new SharpClipboard();

        public MainWindow()
        {
            try
            {
                controller = new StatusbitsController(64);
                this.DataContext = controller;
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private async void Clipboard_ContentChanged(object sender, object e)
        {
            if (ClipboardType.Items.IndexOf(ClipboardType.SelectionBoxItem.ToString()) == 0)
            {
                return;
            }
            controller.UpdateValues(Clipboard.GetText(), ClipboardType.SelectionBoxItem.ToString(), ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
        }

        private async void ClipboardType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClipboardType.SelectedItem == null)
            {
                return;
            }
            clipboard.ClipboardChanged -= Clipboard_ContentChanged;
            if (ClipboardType.SelectedItem.ToString() != "no")
            {
                clipboard.ClipboardChanged += Clipboard_ContentChanged;
            }
        }

        private void DecimalTB_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                controller.UpdateValues(DecimalTB.Text, controller.Model.Dec_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

            }
        }

        private void SignedDecimalTB_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

            }
        }

        private void HexadecimalTB_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                controller.UpdateValues(HexadecimalTB.Text, controller.Model.Hex_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

            }
        }

        private void BinaryTB_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                controller.UpdateValues(BinaryTB.Text, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

            }
        }

        private void DecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
        {
            controller.UpdateValues(DecimalTB.Text, controller.Model.Dec_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

        }

        private void SignedDecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
        {
            controller.UpdateValues(SignedDecimalTB.Text, "SignedDecimal", ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

        }

        private void HexadecimalTB_OnLostFocus(object sender, RoutedEventArgs e)
        {
            controller.UpdateValues(HexadecimalTB.Text, controller.Model.Hex_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

        }

        private void BinaryTB_OnLostFocus(object sender, RoutedEventArgs e)
        {
            controller.UpdateValues(BinaryTB.Text, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

        }

        private void ActiveBits_OnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            controller.UpdateFromCheckboxes(ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
        }

        private void Bit64_OnChecked(object sender, RoutedEventArgs e)
        {
            if (BinaryTB != null)
            {
                string value = BinaryTB.Text;
                controller.UpdateBits(64);
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

            }
            else
            {
                controller.UpdateBits(64);
            }
        }
        private void Bit32_OnChecked(object sender, RoutedEventArgs e)
        {
            string value = BinaryTB.Text.Substring(40);
            controller.UpdateBits(32);
            controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);

        }

        private void V1000_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "1000")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("1000");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems); ;
            }
        }
        private void V820_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "820")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("820");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
            }
        }

        private void V810_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "810")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("810");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
            }
        }

        private void V800_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "800")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("800");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
            }
        }

        private void V760_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "760")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("760");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
            }
        }

        private void V750_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Version != "7.50")
            {
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion("7.50");
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
            }
        }
        private void en_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Language != "en")
            {
                controller.SetLanguage("en");
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion(controller.Model.Version);
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                ClipboardType.SelectedItem = controller.Model.No_Resources;
                ClipboardType.Items.Refresh();
            }
        }

        private void de_OnClick(object sender, RoutedEventArgs e)
        {
            if (controller.Model.Language != "de")
            {
                controller.SetLanguage("de");
                string value = BinaryTB.Text;
                controller.UpdateStatusbitsFromVersion(controller.Model.Version);
                controller.UpdateValues(value, controller.Model.Bin_Resources, ActiveBits8.SelectedItems, ActiveBits7.SelectedItems, ActiveBits6.SelectedItems, ActiveBits5.SelectedItems, ActiveBits4.SelectedItems, ActiveBits3.SelectedItems, ActiveBits2.SelectedItems, ActiveBits1.SelectedItems);
                ClipboardType.SelectedItem = controller.Model.No_Resources;
                ClipboardType.Items.Refresh();
            }
        }
    }
}

