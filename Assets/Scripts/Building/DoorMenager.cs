using Unity.Cinemachine;
using UnityEngine;

public class DoorMenager : MonoBehaviour
{
    // gracz
    private Transform player;
    private PlayerMovement playerMovement;
    private void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        player = Player.transform;
        playerMovement = Player.GetComponent<PlayerMovement>();
    }
    private enum Direction {
        Null,
        Up,
        Right,
        Down, 
        Left
    };
    private Vector2 DirectionToVector2(Direction direction)
    {
        return direction switch
        {
            Direction.Null => Vector2.zero,
            Direction.Up => Vector2.up,
            Direction.Right => Vector2.right,
            Direction.Down => Vector2.down,
            Direction.Left => Vector2.left,
            _ => Vector2.zero
        };
    } 

    [SerializeField] private Transform innerDoor;
    [SerializeField] private Direction _innerMoveDirection;
    private Vector2 InnerMoveDirection
    {
        get => DirectionToVector2(_innerMoveDirection);    
    }

    [SerializeField] private Transform exitDoor;
    [SerializeField] private Direction _exitMoveDirection;
    private Vector2 ExitMoveDirection
    {
        get => DirectionToVector2(_exitMoveDirection);
    }

    private void Update()
    {
        if(player.position == innerDoor.position)
        {
            player.position = exitDoor.position;
            if(!playerMovement.isMoving)
                StartCoroutine(playerMovement.Move(ExitMoveDirection));
        }
        else if (player.position == exitDoor.position)
        {
            player.position = innerDoor.position;
            if(!playerMovement.isMoving)
                StartCoroutine(playerMovement.Move(InnerMoveDirection));
        }
    }
}
