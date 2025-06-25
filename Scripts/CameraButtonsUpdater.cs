using Godot;
using System;

public partial class CameraButtonsUpdater : Control {
    public override void _Process(double delta) {
        Visible = Globals.ActiveCamera != 0;
    }
}
