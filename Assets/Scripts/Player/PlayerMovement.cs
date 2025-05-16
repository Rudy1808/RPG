using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float sprintSpeed = 7f;
    private bool isMoving = false;
    private Vector2 input;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
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
        IEnumerator Move()
        {
            isMoving = true;

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;
            float duration = 1f / currentSpeed;

            Vector3 startPosition = transform.position;
            Vector3 endPosition = startPosition + new Vector3(input.x, input.y, 0);

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
}