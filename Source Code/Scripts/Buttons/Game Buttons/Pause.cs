public partial class Pause : AppButton
{
	public override void OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Camera/Pause Menu").Show();
		GetTree().Paused = true;
	}
}