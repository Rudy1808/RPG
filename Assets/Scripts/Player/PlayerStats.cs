using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    //base stats
    public int maxHP = 100;
    private int _hp = 100;
    public int HP
    {
        get => _hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, maxHP);
            if (_hp == 0)
            {
                //œmieræ
                //prosze dodaæ funkcje œmieræ.
               
            }

        }
    }
    public int attack;
    public int defence;
    public int agility;

    //expirience
    public int expToNextLevel { get; private set; } = 1000;
    public int level { get; private set; } = 1;

    [SerializeField] private int expGrowRate = 500;
    private int _exp = 0;
    public int EXP
    {
        get => _exp;
        set
        {
            _exp = value;
            while(_exp >= expToNextLevel)
            {
                _exp -= expToNextLevel;
                expToNextLevel += expGrowRate;
                level++;
            }
        }
    }
}
