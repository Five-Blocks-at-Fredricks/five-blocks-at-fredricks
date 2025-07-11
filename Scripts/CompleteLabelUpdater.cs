using Godot;
using System.Threading.Tasks;

//I want to formally thank chatgpt for making this as I didn't make a single line of code here
public partial class CompleteLabelUpdater : Control {
    private Label label5AM;
    private Label label6AM;
    private Tween tween;

    public override void _Ready() {
        label5AM = GetNode<Label>("5AMLabel");
        label6AM = GetNode<Label>("6AMLabel");

        label5AM.Modulate = new Color(1, 1, 1, 1);
        label6AM.Modulate = new Color(1, 1, 1, 0);

        AnimateLabelsAsync();
    }

    private async void AnimateLabelsAsync() {
        await Task.Delay(1000);

        tween = CreateTween();

        tween.TweenMethod(Callable.From<float>(SetRotation), 0f, 360f, 3f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.InOut);

        tween.Parallel().TweenMethod(Callable.From<float>(t => {
            label5AM.Modulate = new Color(1, 1, 1, 1 - t);
            label6AM.Modulate = new Color(1, 1, 1, t);
        }), 0f, 1f, 1f)
            .SetDelay(1.5f)
            .SetTrans(Tween.TransitionType.Sine)
            .SetEase(Tween.EaseType.InOut);

        var tcs = new TaskCompletionSource<bool>();
        tween.Finished += () => tcs.SetResult(true);
        await tcs.Task;

        await Task.Delay(3000);

        GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
    }

    private new void SetRotation(float angle) {
        label5AM.RotationDegrees = angle;
        label6AM.RotationDegrees = angle;
    }
}
