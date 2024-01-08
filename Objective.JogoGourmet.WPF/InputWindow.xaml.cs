using System.Windows;

namespace Objective.JogoGourmet.WPF;

/// <summary>
/// Interaction logic for InputWindow.xaml
/// </summary>
public partial class InputWindow : Window
{

    public string? Result { get; private set; }

    public InputWindow(string pergunta, string titulo)
    {
        InitializeComponent();
        txtPergunta.Text = pergunta;
        Title = titulo;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Result = result.Text;
        DialogResult = true;
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Result = null;
        DialogResult = false;
        Close();
    }
}
