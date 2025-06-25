using Godot;
using System;

public partial class ActiveCameraUpdater : Node3D {
    public override void _Process(double delta) {
        if (Globals.ActiveCamera == 0) {
            SwitchCamera(GetNode<Camera3D>("/root/Game/PlayerCamera"));
        } else if (Globals.ActiveCamera == 1) {
            SwitchCamera(GetNode<Camera3D>("/root/Game/Building/OfficeHallway/RightHallway/Camera"));
        } else if (Globals.ActiveCamera == 2) {
            SwitchCamera(GetNode<Camera3D>("/root/Game/Building/OfficeHallway/LeftHallway/Camera"));
        }
    }
    public void SwitchCamera(Camera3D TargetCamera) {
        if (TargetCamera != null) {
            TargetCamera.MakeCurrent();
            GD.Print("Switched to camera: " + TargetCamera.Name);
        } else {
            GD.PrintErr("Cannot switch camera, TargetCamera is null.");
        }
    }
}
