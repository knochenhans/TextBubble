using Godot;

[Tool]
public partial class TextBubbleResource : Resource
{
    [Export]
	public string Text { get; set; } = "";

	[Export]
	public float LifeTime { get; set; } = 1.0f;

	[Export]
	public Vector2 Offset { get; set; } = new Vector2(0, 0);

	[Export]
	public float FadeoutTime { get; set; } = 1.0f;
}