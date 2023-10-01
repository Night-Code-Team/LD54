public partial class Resume : AppButton
{
	public override void OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Field/Camera/Pause Menu").Hide();
		GetTree().Paused = false;
	}
}
