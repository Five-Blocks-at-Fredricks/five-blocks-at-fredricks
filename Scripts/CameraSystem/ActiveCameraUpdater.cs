using Godot;
using System;

public partial class ActiveCameraUpdater : Node3D {
    public override void _Ready() {
        Globals.Cameras.Add(GetNode<Camera3D>("/root/Game/Building/OfficeHallway/RightHallway/Camera"));
        Globals.Cameras.Add(GetNode<Camera3D>("/root/Game/Building/OfficeHallway/LeftHallway/Camera"));
        Globals.Cameras.Add(GetNode<Camera3D>("/root/Game/Building/StorageRoom/Camera"));
        Globals.Cameras.Add(GetNode<Camera3D>("/root/Game/Building/DiningRoom/Camera"));
        Globals.Cameras.Add(GetNode<Camera3D>("/root/Game/Building/PartsAndService/Camera"));
    }

    public override void _Process(double delta) {
        if (Globals.ActiveCamera == 0) {
            SwitchCamera(GetNode<Camera3D>("/root/Game/PlayerCamera"));
        } else {
            SwitchCamera(Globals.Cameras[Globals.ActiveCamera - 1]);
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
