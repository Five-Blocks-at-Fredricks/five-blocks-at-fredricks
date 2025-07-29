using Godot;
using System;

public partial class ContinueLogic : Control {
    public override void _Ready() {
        Globals.LastCompletedNight = int.Parse(BazookaManager.Read(BazookaManager.LastBeatenNight, "0"));
    }

    private void _on_continue_button_button_up() {
        if (Globals.LastCompletedNight == 5) {
            Globals.Night = 5;
            Globals.LastCompletedNight = 4;
        } else {
            Globals.Night = Globals.LastCompletedNight + 1;
        }

        // Ai levels for the animatronics
        if (Globals.LastCompletedNight == 0) {
            Globals.FredrickAiLevel = 0;
            Globals.BernieAiLevel = 2;
            Globals.CheekyAiLevel = 2;
            Globals.DingusAiLevel = 0;
        } else if (Globals.LastCompletedNight == 1) {
            Globals.FredrickAiLevel = 2;
            Globals.BernieAiLevel = 4;
            Globals.CheekyAiLevel = 4;
            Globals.DingusAiLevel = 2;
        } else if (Globals.LastCompletedNight == 2) {
            Globals.FredrickAiLevel = 3;
            Globals.BernieAiLevel = 5;
            Globals.CheekyAiLevel = 5;
            Globals.DingusAiLevel = 2;
        } else if (Globals.LastCompletedNight == 3) {
            Globals.FredrickAiLevel = 5;
            Globals.BernieAiLevel = 6;
            Globals.CheekyAiLevel = 6;
            Globals.DingusAiLevel = 5;
        } else if (Globals.LastCompletedNight == 4) {
            Globals.FredrickAiLevel = 6;
            Globals.BernieAiLevel = 8;
            Globals.CheekyAiLevel = 8;
            Globals.DingusAiLevel = 6;
        }
    }
}
