public partial class MC : Character
{
    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("a", "d", "w", "s");
        Velocity = inputDirection * Vel;
    }
    public override void _PhysicsProcess(double delta)
    {
        GetInput();
        MoveAndSlide();
        GetNode<Camera2D>("/root/Game/Field/Camera").Position = Position;
    }
    public override void Spawn()
    {

    }
    public override void Die()
    {

    }
    public override void Move()
    {

    }
    public override void Attack()
    {

    }
    public override int HP { get; set; } = 3;
    public override int Vel { get; set; } = 400;
}
