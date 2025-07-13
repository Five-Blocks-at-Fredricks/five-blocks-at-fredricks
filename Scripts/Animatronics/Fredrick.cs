using Godot;
using System;

public partial class Fredrick : Node3D {
    private int PositionNumber = 0;
    private Random random = new Random();
    private float MoveTimer = 0f;
    private DoorLogic LeftDoor = new();
    private DoorLogic RightDoor = new();
    private float FlashTimer = 0f;
    private bool CountTimer = false;

    public override void _Ready() {
        Label FredrickAiLevelLabel = GetNode<Label>("/root/Game/GUI/Debug/Fredrick/Label");

        FredrickAiLevelLabel.Text = "Ai: " + Globals.FredrickAiLevel.ToString();

        LeftDoor = GetNode<DoorLogic>("/root/Game/Building/Office/LeftDoor");
        RightDoor = GetNode<DoorLogic>("/root/Game/Building/Office/RightDoor");
    }

    public override void _Process(double delta) {
        int MoveValue = random.Next(1, 21);
        Vector3 Pos = Position;
        Vector3 Rot = RotationDegrees;

        MeshInstance3D Head = GetNode<MeshInstance3D>("Cube_007");
        MeshInstance3D ArmOne = GetNode<MeshInstance3D>("Cube_002");
        MeshInstance3D ArmTwo = GetNode<MeshInstance3D>("Cube_003");
        MeshInstance3D LegOne = GetNode<MeshInstance3D>("Cube_008");
        MeshInstance3D LegTwo = GetNode<MeshInstance3D>("Cube_009");
        Vector3 HeadRotation = Head.RotationDegrees;
        Vector3 ArmOneRotation = ArmOne.RotationDegrees;
        Vector3 ArmTwoRotation = ArmTwo.RotationDegrees;
        Vector3 LegOneRotation = LegOne.RotationDegrees;
        Vector3 LegTwoRotation = LegTwo.RotationDegrees;

        if (MoveTimer >= 5f) {
            Label FredrickMovementValueLabel = GetNode<Label>("/root/Game/GUI/Debug/Fredrick/Label2");

            FredrickMovementValueLabel.Text = "Random Value: " + MoveValue.ToString();
        }

        if (MoveValue <= Globals.FredrickAiLevel && MoveTimer >= 5f) {
            // Fredrick's Starting Pos:
            // X: -4.191
            // Y: 3.147
            // Z: -41.583

            if (PositionNumber == 0) {
                PositionNumber = 1;

                Pos.X = -24.296f;
                Pos.Y = 1.225f;
                Pos.Z = -36.53f;

                Rot.Y = -180f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 1) {
                PositionNumber = 2;

                Pos.X = -16.406f;
                Pos.Y = 1.225f;
                Pos.Z = -6.895f;

                Rot.Y = -180.0f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 2) {
                PositionNumber = 3;

                Pos.X = 1.558f;
                Pos.Y = 1.225f;
                Pos.Z = -25.544f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 3) {
                PositionNumber = 4;

                Pos.X = 0f;
                Pos.Y = 1.225f;
                Pos.Z = -16.77f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 4) {
                PositionNumber = 5;

                Pos.X = -3.869f;
                Pos.Y = 0.07f;
                Pos.Z = -3.916f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;

                ArmOneRotation.Z = 90f;
                ArmTwoRotation.Z = 90f;
                LegOneRotation.Z = 90f;
                LegTwoRotation.Z = 90f;

                LeftDoor.DoorPower = 0;
                RightDoor.DoorPower = 0;
            }
        }

        if (Globals.ActiveCamera == 0 && Input.IsKeyPressed((Key)Key.Ctrl) && PositionNumber == 4) {
            CountTimer = true;
        }

        if (CountTimer) {
            FlashTimer += (float)delta;
        }

        if (FlashTimer > 1f) {
            PositionNumber = 1;

            Pos.X = -24.296f;
            Pos.Y = 1.225f;
            Pos.Z = -36.53f;

            Rot.Y = -180f;

            CountTimer = false;
            FlashTimer = 0f;
        }

        if (MoveTimer > 5f) {
            MoveTimer = 0f;
        }

        MoveTimer += (float)delta;

        Position = Pos;
        RotationDegrees = Rot;

        Head.RotationDegrees = HeadRotation;
        ArmOne.RotationDegrees = ArmOneRotation;
        ArmTwo.RotationDegrees = ArmTwoRotation;
        LegOne.RotationDegrees = LegOneRotation;
        LegTwo.RotationDegrees = LegTwoRotation;
    }
}
