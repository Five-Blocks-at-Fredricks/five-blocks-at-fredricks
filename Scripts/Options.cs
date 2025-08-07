using Godot;
using System;

public partial class Options : ColorRect {
    public override void _Ready() {
        Button MuteFlashSoundButton = GetNode<Button>("MuteFlashSound");

        if (!Globals.MuteFlashSound) {
            MuteFlashSoundButton.Text = "Mute Flash Sound: False";
            MuteFlashSoundButton.ButtonPressed = false;
        } else {
            MuteFlashSoundButton.Text = "Mute Flash Sound: True";
            MuteFlashSoundButton.ButtonPressed = true;
        }
    }

    private void _on_back_button_up() {
        if (!Globals.MuteFlashSound) {
            BazookaManager.Write(BazookaManager.MuteFlashSound, "0");
        } else {
            BazookaManager.Write(BazookaManager.MuteFlashSound, "1");
        }
    }

    private void _on_mute_flash_sound_button_up() {
        Button MuteFlashSoundButton = GetNode<Button>("MuteFlashSound");

        Globals.MuteFlashSound = !Globals.MuteFlashSound;
        if (!Globals.MuteFlashSound) {
            MuteFlashSoundButton.Text = "Mute Flash Sound: False";
        } else {
            MuteFlashSoundButton.Text = "Mute Flash Sound: True";
        }
    }
}
