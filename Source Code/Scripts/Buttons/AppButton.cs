public abstract partial class AppButton : Button
{
    public abstract void OnButtonPressed();
    public override void _Ready()
    {
        Pressed += OnButtonPressed;
    }
}