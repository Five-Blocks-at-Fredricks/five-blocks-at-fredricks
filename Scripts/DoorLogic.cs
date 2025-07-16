using Godot;

public partial class DoorLogic : CsgBox3D {
    public int DoorPower = 50000;
    public bool IsClosed = false;

    public override void _Process(double delta) {
        if (IsClosed) {
            DoorPower -= 5;
        }

        if (DoorPower < 1) {
            IsClosed = false;
        }

        if (Input.IsActionJustPressed(Name) && (DoorPower > 0)) {
            if (IsClosed) {
                IsClosed = false;
            } else {
                IsClosed = true;
            }

            AudioStreamPlayer3D AudioPlayer = GetNode<AudioStreamPlayer3D>("AudioPlayer");

            AudioPlayer.Play();
        }

        Vector3 Pos = Position;
        if (IsClosed && Position.Y > 0.5) {
            Pos.Y -= (float)delta * 10;
        } else if (!IsClosed && Position.Y < 3.7) {
            Pos.Y += (float)delta * 10;
        }
        Position = Pos;
    }
}