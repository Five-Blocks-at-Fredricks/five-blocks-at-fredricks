using Godot;
using System;

public partial class DreamFileDialog : Label {
    private string DisplayedDialog = "";
    private float DialogTimer = 0f;
    private int DialogTime = 0;

    public override void _Process(double delta) {
        if (DialogTimer < 0.9f) {
            DialogTimer += (float)delta;
        } else {
            DialogTimer = 0f;
        }

        if (DialogTimer <= 1.1f && DialogTimer >= 0.9f) {
            DialogTime += 1;
        }

        if (DialogTime == 5) {
            DisplayedDialog = "You know Fredrick, Bernie, Cheeky, And dingus. They've been your enemy.";
        } else if (DialogTime == 10) {
            DisplayedDialog = "I'm not here for that.";
        } else if (DialogTime == 15) {
            DisplayedDialog = "I'm not really here at all.";
        } else if (DialogTime == 20) {
            DisplayedDialog = "Just like you aren't.";
        } else if (DialogTime == 25) {
            DisplayedDialog = "We're not part of the game. We are \"Players\" as you call them.";
        } else if (DialogTime == 30) {
            DisplayedDialog = "I'm no more than just a player of this little fan game you installed.";
        } else if (DialogTime == 35) {
            DisplayedDialog = "I'm not even part of the code. I managed to sneak into the game.";
        } else if (DialogTime == 40) {
            DisplayedDialog = "The game dev made a perfect gateway into this game so I just went right in.";
        } else if (DialogTime == 45) {
            DisplayedDialog = "I was meant to be more but I was scrapped.";
        } else if (DialogTime == 50) {
            DisplayedDialog = "I could've been so much more.";
        } else if (DialogTime == 55) {
            DisplayedDialog = "I COULD HAVE BEEN SO MUCH MORE";
        } else if (DialogTime == 60) {
            Globals.Night = 7;
            Globals.MovableCamera = true;
            GetTree().ChangeSceneToFile("res://Scenes/Game.tscn");
        }

        Text = DisplayedDialog;
    }
}
