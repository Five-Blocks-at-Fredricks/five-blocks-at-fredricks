using Godot;
using System;
using System.Collections.Generic;

// This script was mostly made by chatgpt since godot was being a lil special
public partial class LightFlicker : Node3D {
    [Export] public float MinFlickerSpeed = 0.05f;
    [Export] public float MaxFlickerSpeed = 0.1f;

    [Export] public Godot.Collections.Array<NodePath> LightPaths = [];
    [Export] public Godot.Collections.Array<float> MinEnergies = [];
    [Export] public Godot.Collections.Array<float> MaxEnergies = [];

    private class LightData {
        public Light3D Light;
        public float MinEnergy;
        public float MaxEnergy;
        public bool IsMin = true;
    }

    private List<LightData> lights = [];
    private float timer = 0f;
    private float flickerSpeed;
    private Random random = new();

    public override void _Ready() {
        int count = Mathf.Min(LightPaths.Count, Mathf.Min(MinEnergies.Count, MaxEnergies.Count));

        for (int i = 0; i < count; i++) {
            Light3D light = GetNodeOrNull<Light3D>(LightPaths[i]);
            if (light != null) {
                lights.Add(new LightData {
                    Light = light,
                    MinEnergy = MinEnergies[i],
                    MaxEnergy = MaxEnergies[i],
                });
            }
        }

        flickerSpeed = GetNextFlickerSpeed();
    }

    public override void _Process(double delta) {
        timer += (float)delta;

        if (timer >= flickerSpeed) {
            timer = 0f;
            flickerSpeed = GetNextFlickerSpeed();

            foreach (var light in lights) {
                light.IsMin = !light.IsMin;
                light.Light.LightEnergy = light.IsMin ? light.MinEnergy : light.MaxEnergy;
            }
        }
    }

    private float GetNextFlickerSpeed() {
        return (float)(MinFlickerSpeed + random.NextDouble() * (MaxFlickerSpeed - MinFlickerSpeed));
    }
}