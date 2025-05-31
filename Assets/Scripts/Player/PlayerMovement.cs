using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    public bool isMoving { get; private set; } = false;
    private Vector2 input;

    void Update()
    {
        
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                StartCoroutine(Move());
            }
        }
    }
    private IEnumerator Move()
    {
        
        isMoving = true;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        float duration = 1f / currentSpeed;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + (Vector3)input;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }
    public IEnumerator Move(Vector2 rotation)
    {

        isMoving = true;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
        float duration = 1f / currentSpeed;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + (Vector3)rotation;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        isMoving = false;
    }
}