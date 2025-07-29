using Godot;
using System;

public partial class CustomNightLogic : Control {
    public override void _Ready() {
        Globals.LastCompletedNight = int.Parse(BazookaManager.Read(BazookaManager.LastBeatenNight, "0"));
        Button CustomNightButton = GetNode<Button>("..");

        if (Globals.LastCompletedNight != 5) {
            CustomNightButton.Visible = false;
        }
    }
}
