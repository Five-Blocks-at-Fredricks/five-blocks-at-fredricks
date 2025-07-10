using Godot;
using System;

public partial class Dingus : Node3D {
    private int AiLevel = 5;
    private int PositionNumber = 0;
    private Random random = new Random();
    private float MoveTimer = 0f;

    public override void _Ready() {
        Label DingusAiLevelLabel = GetNode<Label>("/root/Game/GUI/Debug/Dingus/Label");

        DingusAiLevelLabel.Text = "Ai: " + AiLevel.ToString();
    }

    public override void _Process(double delta) {
        int MoveValue = random.Next(1, 21);
        Vector3 Pos = Position;
        Vector3 Rot = RotationDegrees;

        MeshInstance3D Head = GetNode<MeshInstance3D>("Cone");
        Vector3 HeadRotation = Head.RotationDegrees;

        if (MoveTimer >= 5f) {
            Label DingusMovementValueLabel = GetNode<Label>("/root/Game/GUI/Debug/Dingus/Label2");

            DingusMovementValueLabel.Text = "Random Value: " + MoveValue.ToString();
        }

        if (MoveValue <= AiLevel && MoveTimer >= 5f) {
            // Dingus's Starting Pos:
            // X: 2.147
            // Y: 1.225
            // Z: -40.225

            if (PositionNumber == 0) {
                PositionNumber = 1;

                Pos.X = 2.618f;
                Pos.Y = 1.225f;
                Pos.Z = -33.003f;

                Rot.Y = 180f;
            } else if (PositionNumber == 1) {
                PositionNumber = 2;

                Pos.X = -1.421f;
                Pos.Y = 1.225f;
                Pos.Z = -33.003f;

                Rot.Y = 180f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 2) {
                int HallwayNumber = random.Next(0, 3);
                if (HallwayNumber == 0) {
                    PositionNumber = 3;

                    Pos.X = 0f;
                    Pos.Y = 1.225f;
                    Pos.Z = -18.77f;

                    Rot.Y = -90f;
                    Rot.Z = 0f;

                    HeadRotation.Z = 0f;
                } else if (HallwayNumber == 1) {
                    PositionNumber = 4;

                    Pos.X = -7.166f;
                    Pos.Y = 1.225f;
                    Pos.Z = -6.684f;

                    Rot.Y = -90f;

                    HeadRotation.Z = 0f;
                } else if (HallwayNumber == 2) {
                    PositionNumber = 5;

                    Pos.X = 7.135f;
                    Pos.Y = 1.225f;
                    Pos.Z = -6.123f;

                    Rot.Y = -90f;
                    Rot.Z = 0f;

                    HeadRotation.Z = 0f;
                }
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
