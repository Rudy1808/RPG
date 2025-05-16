using UnityEngine;
using UnityEngine.Rendering;

public class Stats : MonoBehaviour
{
    //base stats
    public float maxHP = 100f;
    private float _hp = 100f;
    public float HP
    {
        get => _hp;
        set
        {
            _hp = Mathf.Clamp(value, 0, maxHP);
            if (_hp == 0)
            {
                //œmieræ            
            }

        }
    }
    public float attack;
    public float defence;
    public float agility;

    //expirience
    public int expToNextLevel { get; private set; } = 1000;
    public int level { get; private set; } = 0;

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
