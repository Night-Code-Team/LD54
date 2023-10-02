public partial class Quit : AppButton
{
    public override void OnButtonPressed()
    {
        GetTree().Quit();
    }
}
