using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float attack;
    [SerializeField] protected float hp;
    [SerializeField] protected float maxhp;
    [SerializeField] protected float speed;
    [SerializeField] protected float expierenceDrop;
    [SerializeField] protected float defense;
    protected bool isFollowing = false;

    [SerializeField] protected float detectionRange;
    [SerializeField] protected Transform playerPosition;
    protected float distanceX;
    protected float distanceY;
    protected Vector2 input;
    protected bool isMoving = false;

    protected virtual void Update()
    {
        distanceX = playerPosition.position.x - transform.position.x;
        distanceY = playerPosition.position.y - transform.position.y;

        if (!isMoving && Mathf.Abs(distanceX) <= detectionRange && Mathf.Abs(distanceY) <= detectionRange)
        {          
            if(Mathf.Abs(distanceX) >= Mathf.Abs(distanceY))
            {
                input = new Vector2(distanceX > 0 ? 1 : -1, 0);
            }
            else
            {
                input = new Vector2(0, distanceY > 0 ? 1 : -1);
            }

            StartCoroutine(Move(input));
        }
    }

    protected IEnumerator Move(Vector2 direction)
    {

        isMoving = true;
        //animator.SetBool("isMoving", true);
        //animator.SetFloat("moveX", direction.x);
        //animator.SetFloat("moveY", direction.y);

        float duration = 1f / speed;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + (Vector3)direction;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
        //animator.SetBool("isMoving", false);
    }
}
