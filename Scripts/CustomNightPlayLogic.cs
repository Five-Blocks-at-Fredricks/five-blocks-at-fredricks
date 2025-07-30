using Godot;
using System;

public partial class CustomNightPlayLogic : Control {
    private void _on_play_button_button_up() {
        Globals.Night = 6;
    }
}
