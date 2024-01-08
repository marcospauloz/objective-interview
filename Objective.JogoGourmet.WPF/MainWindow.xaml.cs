namespace Objective.JogoGourmet.WPF;

using Objective.JogoGourmet.WPF.Application.Interface;
using System.Windows;

public partial class MainWindow : Window
{
    public MainWindow(IGameManager gameManager)
    {
        gameManager.StartGame();
    }
}
