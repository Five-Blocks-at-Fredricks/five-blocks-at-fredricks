using Godot;

public partial class CameraRotate : Camera3D {
    public override void _Process(double delta) {
        Vector2 MousePos = GetViewport().GetMousePosition();
        float ScreenWidth = GetViewport().GetVisibleRect().Size.X;

        if (MousePos.X > ScreenWidth * 0.75 && RotationDegrees.Y > -42.238636) {
            RotationDegrees = new Vector3(RotationDegrees.X, RotationDegrees.Y - 90f * (float)delta, RotationDegrees.Z);
        }

        if (MousePos.X < ScreenWidth * 0.25 && RotationDegrees.Y < 42.238636) {
            RotationDegrees = new Vector3(RotationDegrees.X, RotationDegrees.Y + 90f * (float)delta, RotationDegrees.Z);
        }
    }
}