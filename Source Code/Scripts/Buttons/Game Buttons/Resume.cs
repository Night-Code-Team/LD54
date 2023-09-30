public partial class Resume : AppButton
{
	public override void _OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Pause Menu").Visible = false;
	}
}
