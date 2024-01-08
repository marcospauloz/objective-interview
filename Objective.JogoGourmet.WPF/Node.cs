namespace Objective.JogoGourmet.WPF;

public class Node
{
    public string Dish { get; set; }
    public bool FimJogo { get; set; }
    public Node YesNode { get; set; }
    public Node NoNode { get; set; }
}