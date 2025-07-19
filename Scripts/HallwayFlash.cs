using Godot;

public partial class HallwayFlash : OmniLight3D {
    private bool WasFlashLightKeybindPressed = false;
    private float FlashLightTimer = 0f;

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

        if (Input.IsKeyPressed((Key)Key.Ctrl) && !WasFlashLightKeybindPressed && FlashLightTimer > 1) {
            WasFlashLightKeybindPressed = true;
            FlashLightTimer = 0;

            // Code for flashing the hallway light
            if (Globals.ActiveCamera == 0) {
                LightEnergy = 5f;
            }

            // Code for flashing the camera light
            int cam = 0;
            if (Globals.ActiveCamera != 0) {
                foreach (Camera3D Camera in Globals.Cameras) {
                    Light3D Light = Camera.GetNode<Light3D>("Light");

                    if (cam == Globals.ActiveCamera - 1) {
                        Light.LightEnergy = 5f;
                    }

                    cam += 1;
                }
            }

            AudioStreamPlayer AudioPlayer = GetNode<AudioStreamPlayer>("AudioPlayer");

            AudioPlayer.Play(1f);
        }

        WasFlashLightKeybindPressed = Input.IsKeyPressed(Key.Ctrl);
        FlashLightTimer += (float)delta;
    }
}