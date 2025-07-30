using Godot;
using System;

public partial class DialogPlayer : AudioStreamPlayer3D {
    private AudioStreamMP3 DialogMessage = new();
    public override void _Ready() {
        if (Globals.Night != 6) {
            DialogMessage = GD.Load<AudioStreamMP3>($"res://Audio/Dialog/Night{Globals.Night}.mp3");

            Stream = DialogMessage;

            Play();
        }
    }
}
