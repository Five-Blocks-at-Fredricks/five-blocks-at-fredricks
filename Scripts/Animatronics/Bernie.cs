using Godot;
using System;

public partial class Bernie : Node3D {
    private int AiLevel = 5;
    private int PositionNumber = 0;
    private Random random = new Random();
    private float MoveTimer = 0f;
    private float JumpScareTimer = 0f;

    public override void _Ready() {
        Label BernieAiLevelLabel = GetNode<Label>("/root/Game/GUI/Debug/Bernie/Label");

        BernieAiLevelLabel.Text = "Ai: " + AiLevel.ToString();
    }

    public override void _Process(double delta) {
        int MoveValue = random.Next(1, 21);
        Vector3 Pos = Position;
        Vector3 Rot = RotationDegrees;

        MeshInstance3D Head = GetNode<MeshInstance3D>("Cube_004");
        Vector3 HeadRotation = Head.RotationDegrees;

        if (MoveTimer >= 5f) {
            Label BernieMovementValueLabel = GetNode<Label>("/root/Game/GUI/Debug/Bernie/Label2");

            BernieMovementValueLabel.Text = "Random Value: " + MoveValue.ToString();
        }

        if (MoveValue <= AiLevel && MoveTimer >= 5f) {
            // Bernie's Starting Pos:
            // X: -2.607
            // Y: 3.089
            // Z: -44.654

            if (PositionNumber == 0) {
                PositionNumber = 1;

                Pos.X = -28.2f;
                Pos.Y = 1.225f;
                Pos.Z = -33.981f;

                Rot.Y = 120f;
            } else if (PositionNumber == 1) {
                PositionNumber = 2;

                Pos.X = -25.278f;
                Pos.Y = 1.225f;
                Pos.Z = -14.419f;

                Rot.Y = -133.1f;

                HeadRotation.Z = 13.3f;
            } else if (PositionNumber == 2) {
                PositionNumber = 3;

                Pos.X = -2.607f;
                Pos.Y = 1.225f;
                Pos.Z = -23.264f;

                Rot.Y = -90f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 3) {
                PositionNumber = 4;

                Pos.X = -7.166f;
                Pos.Y = 1.225f;
                Pos.Z = -18.184f;

                Rot.Y = -90f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 4) {
                PositionNumber = 5;

                Pos.X = -7.166f;
                Pos.Y = 1.225f;
                Pos.Z = -4.684f;

                Rot.Y = -90f;

                HeadRotation.Z = 0f;
            } else if (PositionNumber == 5) {
                DoorLogic LeftDoor = GetNode<DoorLogic>("/root/Game/Building/Office/LeftDoor");
                if (LeftDoor.IsClosed) {
                    PositionNumber = 1;

                    Pos.X = -28.2f;
                    Pos.Y = 1.225f;
                    Pos.Z = -33.981f;

                    Rot.Y = 120f;
                } else {
                    PositionNumber = 6;
                }
            }
        }

        if (PositionNumber == 6) {
            Jumpscare((float)delta, ref Pos);
        }

        if (MoveTimer > 5f) {
            MoveTimer = 0f;
        }

        MoveTimer += (float)delta;

        Position = Pos;
        RotationDegrees = Rot;

        Head.RotationDegrees = HeadRotation;
    }

    private void Jumpscare(float delta, ref Vector3 Pos) {
        AudioStreamPlayer3D JumpscarePlayer = GetNode<AudioStreamPlayer3D>("AudioPlayer");

        if (JumpScareTimer < 1f) {
            Pos = new Vector3(0f, 0f, Pos.Z);
            Pos.Z += 3.5f * delta;
        } else {
            GetTree().ChangeSceneToFile("res://Scenes/GameOver.tscn");
            JumpScareTimer = 0f;
        }

        if (JumpScareTimer == 0f) {
            Globals.ResetGlobals();
            JumpscarePlayer.Play();
        }

        JumpScareTimer += delta;
    }

    private void ResetScene() {
        var currentScene = GetTree().CurrentScene.SceneFilePath;
        GetTree().ChangeSceneToFile(currentScene);
    }
}
