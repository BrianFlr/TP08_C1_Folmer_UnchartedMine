
public class PickableDynamitePack : Pickables
{
    public override void Pick()
    {
        GameManager.Instance.AddDynamitePack();
        Destroy(gameObject);
    }
}
