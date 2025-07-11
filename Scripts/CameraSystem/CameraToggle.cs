using Godot;
using System;

public partial class CameraToggle : Button {
    private void _on_button_up() {
        if (Globals.ActiveCamera == 0) {
            Globals.MovableCamera = false;
            Globals.ActiveCamera = Globals.PreviousCam;
        } else {
            Globals.MovableCamera = true;
            Globals.ActiveCamera = 0;
        }
    }
}
