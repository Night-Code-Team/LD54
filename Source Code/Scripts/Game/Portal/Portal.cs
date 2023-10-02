public partial class Portal : Node2D
{
	private int KeysLeft { get; set; } = 3;
	
	public void OnKeyEntered(Node2D body)
	{
		KeysLeft -= 1;
	}
	public void OnPlayerEntered(Node2D body)
	{
		if (KeysLeft <= 0)
		{
			Win();
		}
	}
	public void Win()
	{
		GetTree().ChangeSceneToFile("res://Assets/Scenes/Game/Game.tscn");
	}
}
