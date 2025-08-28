using Godot;

public partial class DraggableRect : ColorRect
{
    private bool _dragging = false;
    private Vector2 _dragOffset;

    public override void _Ready()
    {
        // Enable mouse input for this node
        MouseFilter = Control.MouseFilterEnum.Pass;
    }

    public override void _GuiInput(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseButton)
        {
            if (mouseButton.ButtonIndex == MouseButton.Left)
            {
                if (mouseButton.Pressed)
                {
                    // Start dragging
                    _dragging = true;
                    _dragOffset = mouseButton.Position;
                }
                else
                {
                    // Stop dragging
                    _dragging = false;
                }
            }
        }
        else if (@event is InputEventMouseMotion mouseMotion && _dragging)
        {
            // Update position while dragging
            GlobalPosition += mouseMotion.Relative;
        }
    }

    // Alternative approach using global mouse position
    /*
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion && _dragging)
        {
            GlobalPosition = GetGlobalMousePosition() - _dragOffset;
        }
    }
    */
}
