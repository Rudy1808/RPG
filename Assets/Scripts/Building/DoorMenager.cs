using Unity.Cinemachine;
using UnityEngine;

public class DoorMenager : MonoBehaviour
{
    // gracz
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
    [SerializeField] private Direction _innerMoveDirction;
    private Vector2 InnerMoveDirection
    {
        get => DirectionToVector2(_innerMoveDirction);    
    }

    [SerializeField] private Transform exitDoor;
    [SerializeField] private Direction _exitMoveDirction;
    private Vector2 ExitMoveDirection
    {
        get => DirectionToVector2(_exitMoveDirction);
    }
}
