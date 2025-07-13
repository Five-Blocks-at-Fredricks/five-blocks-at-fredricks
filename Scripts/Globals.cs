using Godot;
using System.Collections.Generic;

public partial class Globals : Node {
    public static int ActiveCamera = 0;
    public static List<Camera3D> Cameras = [];
    public static bool MovableCamera = false;
    public static int Time = 0;
    public static int PreviousCam = 1;

    public static int FredrickAiLevel = 5;
    public static int BernieAiLevel = 5;
    public static int CheekyAiLevel = 5;
    public static int DingusAiLevel = 5;

    public static void ResetGlobals() {
        ActiveCamera = 0;
        MovableCamera = false;
        Time = 0;
        Cameras.Clear();
    }
}