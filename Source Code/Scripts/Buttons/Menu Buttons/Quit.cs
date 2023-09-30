public partial class Quit : AppButton
{
    public override void _OnButtonPressed()
    {
        GetTree().Quit();
    }
}
