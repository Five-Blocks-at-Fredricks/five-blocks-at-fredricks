using Godot;

public partial class TimeLabelUpdater : Label {
    private string DisplayedTime = "12 AM";
    private float TimeTimer = 0f;

    public override void _Process(double delta) {
        if (TimeTimer < 0.9f) {
            TimeTimer += (float)delta;
        } else {
            TimeTimer = 0f;
        }

        if (TimeTimer <= 1.1f && TimeTimer >= 0.9f) {
            Globals.Time += 1;
        }

        if (Globals.Time == 60) {
            DisplayedTime = "1 AM";
        } else if (Globals.Time == 120) {
            DisplayedTime = "2 AM";
        } else if (Globals.Time == 180) {
            DisplayedTime = "3 AM";
        } else if (Globals.Time == 240) {
            DisplayedTime = "4 AM";
        } else if (Globals.Time == 300) {
            DisplayedTime = "5 AM";
        } else if (Globals.Time == 360) {
            Globals.LastCompletedNight += 1;
            BazookaManager.Write(BazookaManager.LastBeatenNight, Globals.LastCompletedNight.ToString());

            Globals.ResetGlobals();
            GetTree().ChangeSceneToFile("res://Scenes/6AMScreen.tscn");
        }

        Text = DisplayedTime;
    }
}