public partial class Pause : AppButton
{
	public override void _OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Pause Menu").Visible = true;
	}
}