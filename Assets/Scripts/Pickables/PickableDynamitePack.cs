
public class PickableDynamitePack : Pickables
{
    public override void Pick()
    {
        GameManager.Instance.AddPlayerHealth(0);
        Destroy(gameObject);
    }
}
