using Godot;
using System;

[Tool]
public partial class TextBubbleNode : Node2D
{
	[Export]
	public TextBubbleResource TextBubbleResource { get; set; }

	Label Label { get; set; }
	Timer Timer { get; set; }
	AnimationPlayer AnimationPlayer { get; set; }

	public override void _Ready()
	{
		base._Ready();

		Label = GetNode<Label>("Label");
		Label.Text = TextBubbleResource.Text;

		if (!Engine.IsEditorHint())
			Label.Position += TextBubbleResource.Offset;

		AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		AnimationPlayer.SpeedScale = 1.0f / TextBubbleResource.FadeoutTime;

		Timer = GetNode<Timer>("Timer");
		Timer.WaitTime = TextBubbleResource.LifeTime;

		if (!Engine.IsEditorHint())
			Timer.Start();
	}

	public void _OnTimerTimeout() => AnimationPlayer.Play("fadeout");

	public void _OnAnimationPlayerAnimationFinished(StringName animName)
	{
		if (animName == "fadeout")
			QueueFree();
	}
}
