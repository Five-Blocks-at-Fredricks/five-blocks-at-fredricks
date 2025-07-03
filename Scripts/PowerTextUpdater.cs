using Godot;
using System;

public partial class PowerTextUpdater : Control {
    public override void _Process(double delta) {
        DoorLogic LeftDoor = GetNode<DoorLogic>("/root/Game/Building/Office/LeftDoor");
        DoorLogic RightDoor = GetNode<DoorLogic>("/root/Game/Building/Office/RightDoor");

        Label LeftDoorLabel = GetNode<Label>("/root/Game/GUI/Debug/Power/LeftDoor");
        Label RightDoorLabel = GetNode<Label>("/root/Game/GUI/Debug/Power/RightDoor");

        LeftDoorLabel.Text = "Left Door Power: " + (LeftDoor.DoorPower * 100 / 50000.0) + "%";
        RightDoorLabel.Text = "Right Door Power: " + (RightDoor.DoorPower * 100 / 50000.0) + "%";
    }
}
