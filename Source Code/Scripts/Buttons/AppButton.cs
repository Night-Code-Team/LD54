public abstract partial class AppButton : Button
{
    public abstract void _OnButtonPressed();
    public override void _Ready()
    {
        Pressed += _OnButtonPressed;
    }
}