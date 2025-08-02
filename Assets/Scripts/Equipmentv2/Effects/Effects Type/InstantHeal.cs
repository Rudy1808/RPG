using UnityEngine;

[CreateAssetMenu(fileName = "InstantHeal", menuName = "Effects/InstantHeal")]
public class InstnatHeal : ItemEffect
{
    [SerializeField] private int healPower;
    public override void ApplyEffect(GameObject target)
    {
        var playerStats = target.GetComponent<PlayerStats>();
        playerStats.HP += healPower;
    }
}
