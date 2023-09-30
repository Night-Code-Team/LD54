public partial class Start : AppButton
{
	public override void _OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Assets/Scenes/Game/Game.tscn");
	}
}
