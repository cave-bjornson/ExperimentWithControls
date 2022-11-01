using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ExperimentWithControls
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NumberTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Number.Text = NumberTextBox.Text;
        }

        private void NumberTextBox_OnBeforeTextChanging(
            TextBox sender,
            TextBoxBeforeTextChangingEventArgs args
        )
        {
            args.Cancel = !int.TryParse(args.NewText, out int _);
        }

        private void RadioButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                Number.Text = radioButton.Content.ToString();
            }
        }

        private void MyBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Selector { SelectedItem: string item })
            {
                Number.Text = item;
            }
        }

        private void EditableComboBox_OnTextSubmitted(
            ComboBox sender,
            ComboBoxTextSubmittedEventArgs args
        )
        {
            args.Handled = !int.TryParse(args.Text, out int _);
        }

        private void SmallSlider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Number.Text = SmallSlider.Value.ToString("0");
        }

        private void BigSlider_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Number.Text = BigSlider.Value.ToString("000-000-0000");
        }
    }
}
