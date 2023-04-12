using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PlayerInput _input;
    private Player _player;

    private void Awake()
    {
        _input = new PlayerInput();

        _player = GetComponent<Player>();

        _input.Player.Shoot.performed += context => _player.Shoot();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();

        Move(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        float scaleMoveSpeed = _speed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, direction.y, 0);
        transform.position += moveDirection * scaleMoveSpeed;
    }   
}
