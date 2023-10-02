public partial class Start : AppButton
{
	public override void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Assets/Scenes/Game/Game.tscn");
	}
}
