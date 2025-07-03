using Godot;

public partial class BazookaManager : Node {
    public static string[] saveIds = [];

    public static string Read(int saveId, string defaultValue) {
        string path = "user://" + saveIds[saveId] + ".txt";
        if (!FileAccess.FileExists(path)) {
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
            file.StoreString(defaultValue);
            return defaultValue;
        } else {
            using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
            return file.GetAsText();
        }
    }

    public static void Write(int saveId, string value) {
        string path = "user://" + saveIds[saveId] + ".txt";
        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file.StoreString(value);
        file.Flush();
    }
}