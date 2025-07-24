using Godot;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class ModApi : Control {
    public override void _Ready() {
        DirAccess.MakeDirAbsolute("user://Mods");

        LoadAllMods("user://Mods");
    }

    private void LoadAllMods(string modsPath) {
        var dir = DirAccess.Open(modsPath);
        if (dir == null) {
            GD.PrintErr($"Mods folder not found at {modsPath}");
            return;
        }

        foreach (string folder in dir.GetDirectories()) {
            string modPath = $"{modsPath}/{folder}";
            string baseScenePath = $"{modPath}/Base.tscn";
            string baseScriptPath = $"{modPath}/Base.gd";
            string modJsonPath = $"{modPath}/mod.json";

            string ModJsonContent = "";

            if (FileAccess.FileExists(modJsonPath)) {
                using var file = FileAccess.Open(modJsonPath, FileAccess.ModeFlags.Read);
                ModJsonContent = file.GetAsText();
            }

            var ModJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(ModJsonContent);

            bool Enabled = (bool)ModJson["enabled"];
            string ModName = (string)ModJson["name"];

            if (Enabled) {
                if (!FileAccess.FileExists(baseScenePath)) {
                    GD.Print($"Skipping {folder}: No Base.tscn");
                    continue;
                }

                PackedScene modScene = GD.Load<PackedScene>(baseScenePath);
                if (modScene == null) {
                    GD.PrintErr($"Failed to load scene: {baseScenePath}");
                    continue;
                }

                Node modRoot = modScene.Instantiate();

                // Load the Base.gd script if it exists
                if (FileAccess.FileExists(baseScriptPath)) {
                    var modScript = GD.Load<Script>(baseScriptPath);
                    if (modScript != null) {
                        modRoot.SetScript(modScript);
                    } else {
                        GD.PrintErr($"Failed to load script: {baseScriptPath}");
                    }
                } else {
                    GD.Print($"No Base.gd script found for mod {folder}");
                }

                AddChild(modRoot);
                GetNode<Node3D>("Base").Name = $"Mod_{ModName}";
                GD.Print($"Loaded mod: {folder}");
            } else {
                GD.Print($"Skipped mod: {folder} because it is disabled");
            }
        }
    }
}
