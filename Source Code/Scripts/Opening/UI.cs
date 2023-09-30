public partial class UI : Control
{
	public override void _Ready()
	{
		Open();
	}
	public void Open()
	{
		GetChild<AnimationPlayer>(1).Play("Open");
	}
	public void Close()
	{
		GetChild<AnimationPlayer>(1).Play("Close");
	}
}
