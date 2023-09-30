public partial class OpeningTimer : Timer
{
	private bool change = false;
	public override void _Input(InputEvent @event)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left))
		{
			GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
		}
	}
	private void OnTimerTimeout()
	{
		if (!change)
		{
			GetParent<UI>().Close();
			WaitTime = 1;
			Start();
			change = true;
		}
		else
		{
#if DEBUG
			GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
#else
			GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
#endif
		}
	}
}
