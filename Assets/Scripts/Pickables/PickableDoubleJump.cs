
public class PickableDoubleJump : Pickables
{
    public override void Pick()
    {
        GameManager.Instance.ActivateDoubleJump();
        Destroy(gameObject);
    }
}
