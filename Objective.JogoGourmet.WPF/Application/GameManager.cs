namespace Objective.JogoGourmet.WPF.Application;

using Objective.JogoGourmet.WPF.Application.Interface;
using System.Windows;

public class GameManager : IGameManager
{
    private const string BaseQuestion = "O prato que você pensou é";
    private readonly Node RootNode;
    private bool isRunning;

    public GameManager()
    {
        // Start binary tree
        RootNode = new Node
        {
            Dish = "massa",
            YesNode = new Node
            {
                Dish = "lasanha"
            },
            NoNode = new Node
            {
                Dish = "bolo de chocolate"
            }
        };

        isRunning = true;
    }

    public void StartGame()
    {
        // Start the game
        while (isRunning)
        {
            var result = MessageBox.Show("Pense em um prato que gosta...", "Jogo Gourmet", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (result == MessageBoxResult.Cancel)
            {
                Application.Current.Shutdown();
                isRunning = false;
                return;
            }

            HandleQuestions(RootNode);
        }
    }

    private void HandleQuestions(Node currentNode)
    {
        MessageBoxResult result = MessageBox.Show($"{BaseQuestion} {currentNode.Dish}?", "Jogo Gourmet", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            HandleYesResponse(currentNode);
        }
        else if (result == MessageBoxResult.No)
        {
            HandleNoResponse(currentNode);
        }
    }

    private void HandleYesResponse(Node currentNode)
    {
        if (currentNode.YesNode != null)
        {
            HandleQuestions(currentNode.YesNode);
        }
        else
        {
            MessageBox.Show("Acertei :)\nPressione OK para reiniciar.", "Jogo Gourmet", MessageBoxButton.OK, MessageBoxImage.Information);
            StartGame();
        }
    }

    private void HandleNoResponse(Node currentNode)
    {
        if (currentNode.NoNode != null)
        {
            HandleQuestions(currentNode.NoNode);
        }
        else
        {
            HandleNewDishInput(currentNode);
        }
    }

    private void HandleNewDishInput(Node currentNode)
    {
        var inputWindow = new InputWindow("Qual prato você pensou?", "Desisto");
        var dialogResult = inputWindow.ShowDialog();
        if (dialogResult == true)
        {
            var newDish = inputWindow.Result;
            inputWindow = new InputWindow($"{inputWindow.Result} é ____________ mas {currentNode.Dish} não.", "Nova Característica");
            dialogResult = inputWindow.ShowDialog();
            if (dialogResult == true)
            {
                if (!string.IsNullOrWhiteSpace(newDish) && !string.IsNullOrWhiteSpace(inputWindow.Result))
                {
                    currentNode.NoNode = new Node { Dish = inputWindow.Result, YesNode = new Node { Dish = newDish } };
                }
            }
        }
        else
        {
            isRunning = false;
        }
    }
}
