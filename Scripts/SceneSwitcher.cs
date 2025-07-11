using Godot;

public partial class SceneSwitcher : Button {
    [Export]
    public string ScenePath = ""; // Set this in the Inspector

    public override void _Ready() {
        Pressed += OnButtonPressed;
    }

    private void OnButtonPressed() {
        if (string.IsNullOrEmpty(ScenePath)) {
            GD.PrintErr("Scene path not set!");
            return;
        }

        var error = GetTree().ChangeSceneToFile(ScenePath);
        if (error != Error.Ok) {
            GD.PrintErr("Failed to change scene: " + error);
        }

        if (ScenePath == "res://Scenes/Game.tscn") {
            Globals.MovableCamera = true;
        }
    }
}