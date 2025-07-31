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

        var error = Error.Ok;

        if (
            Name == "PlayButton" &&
            Globals.FredrickAiLevel == 0 &&
            Globals.BernieAiLevel == 0 &&
            Globals.CheekyAiLevel == 0 &&
            Globals.DingusAiLevel == 0
        ) {
            error = GetTree().ChangeSceneToFile("res://Scenes/DreamFileDialog.tscn");
        } else {
            error = GetTree().ChangeSceneToFile(ScenePath);
        }
        if (error != Error.Ok) {
            GD.PrintErr("Failed to change scene: " + error);
        }

        if (ScenePath == "res://Scenes/Game.tscn") {
            Globals.MovableCamera = true;
        }
    }
}