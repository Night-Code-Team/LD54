public partial class Menu : AppButton
{
	public override void _OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
	}
}
