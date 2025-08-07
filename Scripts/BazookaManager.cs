using Godot;

public partial class BazookaManager : Node {
    public static string LastBeatenNight = "lastbeatennight";
    public static string MuteFlashSound = "0";

    public static string Read(string saveKey, string defaultValue) {
        string path = "user://" + saveKey + ".txt";
        if (!FileAccess.FileExists(path)) {
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
            file.StoreString(defaultValue);
            return defaultValue;
        } else {
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
            return file.GetAsText();
        }
    }

    public static void Write(string saveKey, string value) {
        string path = "user://" + saveKey + ".txt";
        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file.StoreString(value);
        file.Flush();
    }
}