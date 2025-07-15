using Godot;
using System;

public partial class CameraSwitcher : Button {
    [Export]
    public int TargetCamera;

    private void _on_button_up() {
        Globals.ActiveCamera = TargetCamera;
        Globals.PreviousCam = TargetCamera;

        AudioStreamPlayer AudioPlayer = GetNode<AudioStreamPlayer>("../AudioPlayer");

        AudioPlayer.Play();
    }
}
