using Godot;
using System;

public partial class HallwayFlash : OmniLight3D {
    public override void _Process(double delta) {
        if (LightEnergy > 0) {
            LightEnergy -= (float)delta * 6f;
        }

        if (Input.IsKeyPressed((Key)Key.Ctrl)) {
            LightEnergy = 5f;
        }
    }
}
