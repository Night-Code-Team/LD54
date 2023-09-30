public partial class Pause : AppButton
{
	public override void OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Pause Menu").Visible = true;
	}
}