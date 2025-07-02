using Godot;
using System;

public partial class Cheeky : Node3D {
    private int AiLevel = 10;
    private int PositionNumber = 0;
    private Random random = new Random();
    private float MoveTimer = 0f;

    public override void _Ready() {
        Label CheekyAiLevelLabel = GetNode<Label>("/root/Game/GUI/Debug/Cheeky/Label");

        CheekyAiLevelLabel.Text = "Ai: " + AiLevel.ToString();
    }

    public override void _Process(double delta) {
        int MoveValue = random.Next(1, 21);
        Vector3 Pos = Position;
        Vector3 Rot = RotationDegrees;

        MeshInstance3D Head = GetNode<MeshInstance3D>("Cube_004");
        Vector3 HeadRotation = Head.RotationDegrees;

        if (MoveTimer >= 5f) {
            Label CheekyMovementValueLabel = GetNode<Label>("/root/Game/GUI/Debug/Cheeky/Label2");

            CheekyMovementValueLabel.Text = "Random Value: " + MoveValue.ToString();
        }

        if (MoveValue <= AiLevel && MoveTimer >= 5f) {
            // Cheeky's Starting Pos:
            // X: -2.581
            // Y: 3.147
            // Z: -38.513

            if (PositionNumber == 0) {
                PositionNumber = 1;

                Pos.X = -17.729f;
                Pos.Y = 1.225f;
                Pos.Z = -46.571f;

                Rot.Y = 105f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 1) {
                PositionNumber = 2;

                Pos.X = -21.625f;
                Pos.Y = 1.225f;
                Pos.Z = -60.796f;

                Rot.Y = -180.0f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 2) {
                PositionNumber = 3;

                Pos.X = -25.606f;
                Pos.Y = 1.225f;
                Pos.Z = -36.705f;

                Rot.Y = -180.0f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 3) {
                PositionNumber = 4;

                Pos.X = -17.851f;
                Pos.Y = -0.358f;
                Pos.Z = -23.35f;

                Rot.Y = 0f;
                Rot.Z = 82f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 4) {
                PositionNumber = 5;

                Pos.X = -0.531f;
                Pos.Y = 1.225f;
                Pos.Z = -24.273f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 5) {
                PositionNumber = 6;

                Pos.X = 7.135f;
                Pos.Y = 1.225f;
                Pos.Z = -17.673f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 6) {
                PositionNumber = 7;

                Pos.X = 7.135f;
                Pos.Y = 1.225f;
                Pos.Z = -4.123f;

                Rot.Y = -90f;
                Rot.Z = 0f;

                HeadRotation.Z = 0f;
            }
        }

        if (MoveTimer > 5f) {
            MoveTimer = 0f;
        }

        MoveTimer += (float)delta;

        Position = Pos;
        RotationDegrees = Rot;

        Head.RotationDegrees = HeadRotation;
    }
}
