public partial class Pizdyulina : CharacterBody2D
{
	/// <summary>
	/// Base speed of Pizdyulina
	/// </summary>
	[Export]
	public int Vel { get; private set; } = 2000;
	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
		if (GetSlideCollisionCount() > 0)
		{
			GetNode<Label>("/root/Game/Camera/Counter").Text = (Convert.ToInt32(GetNode<Label>("/root/Game/Camera/Counter").Text) + 20).ToString();
			GetSlideCollision(0).GetCollider().Free();
			QueueFree();
		}
	}
}
