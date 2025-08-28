using Godot;

public partial class Main : Node
{
    // Load the scene
    private PackedScene _draggableRectScene = GD.Load<PackedScene>("res://Scenes/draggable-rect.tscn");

    public override void _Ready()
    {
        // Instantiate and add to scene
        var draggableRect = _draggableRectScene.Instantiate<ColorRect>();
        draggableRect.Position = new Vector2(100, 100); // Set initial position
        AddChild(draggableRect);
    }
}
