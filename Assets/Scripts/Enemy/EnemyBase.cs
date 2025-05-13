using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    protected float attack;
    protected float hp;
    protected float maxhp;
    protected float speed;
    protected float expierenceDrop;
    protected float defense;
    protected bool isFollowing = false;

    protected float detectionRange;
    [SerializeField] protected Transform playerPosition;
    protected float distanceX;
    protected float distanceY;

    protected virtual void update()
    {
        distanceX = playerPosition.position.x - transform.position.x;
        distanceY = playerPosition.position.y - transform.position.y;

        if (Mathf.Abs(distanceX) <= detectionRange && Mathf.Abs(distanceY) <= detectionRange)
        {
            //start coroutine
        }
    }
}
