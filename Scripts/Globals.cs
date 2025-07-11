using Godot;
using System.Collections.Generic;

public partial class Globals : Node {
    public static int ActiveCamera = 0;
    public static List<Camera3D> Cameras = [];
    public static bool MovableCamera = false;
    public static int Time = 0;

    public static void ResetGlobals() {
        ActiveCamera = 0;
        MovableCamera = false;
        Cameras.Clear();
    }
}