using Godot;
using System;

public partial class AiCustomizers : Button {
    [Export] public int UporDown = 1;
    [Export] public string Animatronic = "";

    public override void _Ready() {
        Pressed += OnButtonPressed;
    }

    private void OnButtonPressed() {
        Label LevelLabel = GetNode<Label>("../../Level");
        if (UporDown == 1 && int.Parse(LevelLabel.Text) < 20) {
            LevelLabel.Text = (int.Parse(LevelLabel.Text) + 1).ToString();

            if (Animatronic.ToLower() == "fredrick") {
                Globals.FredrickAiLevel += 1;
            } else if (Animatronic.ToLower() == "bernie") {
                Globals.BernieAiLevel += 1;
            } else if (Animatronic.ToLower() == "cheeky") {
                Globals.CheekyAiLevel += 1;
            } else if (Animatronic.ToLower() == "dingus") {
                Globals.DingusAiLevel += 1;
            }
        } else if (UporDown == 2 && int.Parse(LevelLabel.Text) > 0) {
            LevelLabel.Text = (int.Parse(LevelLabel.Text) - 1).ToString();

            if (Animatronic.ToLower() == "fredrick") {
                Globals.FredrickAiLevel -= 1;
            } else if (Animatronic.ToLower() == "bernie") {
                Globals.BernieAiLevel -= 1;
            } else if (Animatronic.ToLower() == "cheeky") {
                Globals.CheekyAiLevel -= 1;
            } else if (Animatronic.ToLower() == "dingus") {
                Globals.DingusAiLevel -= 1;
            }
        }
    }
}
