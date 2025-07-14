using Godot;
using System;

public partial class NewGameLogic : Control {
    // Godot generated this function name but I'm keeping it cuz its funny af.
    private void _on_new_game_button_button_up() {
        Globals.Night = 1;

        // Ai levels for the animatronics
        Globals.FredrickAiLevel = 0;
        Globals.BernieAiLevel = 2;
        Globals.CheekyAiLevel = 2;
        Globals.DingusAiLevel = 0;
    }
}
