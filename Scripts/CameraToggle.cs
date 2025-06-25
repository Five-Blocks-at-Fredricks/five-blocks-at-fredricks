using Godot;
using System;

public partial class CameraToggle : Button {
    private void _on_button_up() {
        if (Globals.ActiveCamera == 0) {
            Globals.ActiveCamera = 1;
        } else {
            Globals.ActiveCamera = 0;
        }
    }
}
