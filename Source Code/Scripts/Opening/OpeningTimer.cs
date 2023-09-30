public partial class OpeningTimer : Timer
{
	private bool change = false;
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
#else
			GetTree().ChangeSceneToFile("res://Assets/Scenes/Main Menu/Main Menu.tscn");
#endif
		}
	}
}
