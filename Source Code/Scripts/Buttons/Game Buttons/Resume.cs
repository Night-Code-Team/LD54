public partial class Resume : AppButton
{
	public override void OnButtonPressed()
	{
		GetNode<Control>("/root/Game/Pause Menu").Visible = false;
	}
}
