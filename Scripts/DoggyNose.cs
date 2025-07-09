using Godot;
using System;

public partial class DoggyNose : Button {
    // Doggy's Original Position:
    // X: -27.146
    // Y: -0.136
    // Z: -21.242

    private void _on_button_up() {
        Node3D Doggy = GetNode<Node3D>("/root/Game/Building/StorageRoom/Doggy");

        Vector3 Pos = Doggy.Position;
        Pos.X = 3.791f;
        Pos.Z = -4.259f;
        Doggy.Position = Pos;
    }
}
