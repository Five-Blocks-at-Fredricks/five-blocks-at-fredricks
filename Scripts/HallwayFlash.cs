using Godot;
using System;

public partial class HallwayFlash : OmniLight3D {
    public override void _Process(double delta) {
        if (LightEnergy > 0) {
            LightEnergy -= (float)delta * 6f;
        }

        foreach (Camera3D Camera in Globals.Cameras) {
            Light3D Light = Camera.GetNode<Light3D>("Light");

            if (Light.LightEnergy > 0) {
                Light.LightEnergy -= (float)delta * 6f;
            }
        }

        if (Input.IsKeyPressed((Key)Key.Ctrl)) {
            if (Globals.ActiveCamera == 0) {
                LightEnergy = 5f;
            }

            if (Globals.ActiveCamera != 0) {
                foreach (Camera3D Camera in Globals.Cameras) {
                    Light3D Light = Camera.GetNode<Light3D>("Light");

                    Light.LightEnergy = 5f;
                }
            }
        }
    }
}
