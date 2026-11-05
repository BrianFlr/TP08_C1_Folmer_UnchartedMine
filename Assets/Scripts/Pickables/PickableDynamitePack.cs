
public class PickableDynamitePack : Pickables
{
    public override void Pick()
    {
        GameManager.Instance.SetDynamitePack();
        Destroy(gameObject);
    }
}
