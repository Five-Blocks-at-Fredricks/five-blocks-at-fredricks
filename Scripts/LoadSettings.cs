using Godot;
using System;

public partial class LoadSettings : Control {
    public override void _Ready() {
        Globals.MuteFlashSound = BazookaManager.Read(BazookaManager.MuteFlashSound, "0") == "1";
    }
}
