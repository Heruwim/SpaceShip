using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _canvas;

    private PlayerInput _input;
    private Player _player;
    private Menu _menu;
    private bool _menuOpen = false;
    private NextWave _nextWaveButton;
    private float _topLimitY = 3.0f;
    private float _bottomLimitY = -4.0f;

    private void Awake()
    {
        _input = new PlayerInput();

        _player = GetComponent<Player>();
        _menu = _canvas.GetComponent<Menu>();
        _nextWaveButton = _canvas.GetComponentInChildren<NextWave>();
        
        _input.Player.Shoot.performed += context => ShootHandler();
        _input.Player.NextWeapon.performed += context => _player.NextWeapon();
        _input.Player.PreviousWeapon.performed += context => _player.PreviousWeapon();
        _input.Player.OpenMenu.performed += context => ToggleMenu();
        _input.Player.NextWave.performed += context => _nextWaveButton.OnNextWaveButtonClick();

        _menu.Initialize(_input);
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
        Vector3 newPosition = transform.position + moveDirection * scaleMoveSpeed;

        newPosition.y = Mathf.Clamp(newPosition.y, _bottomLimitY, _topLimitY);
        transform.position = newPosition;
    }

    private void ShootHandler()
    {
        if (!_menuOpen)
        {
            _player.Shoot();
        }
    }

    private void ToggleMenu()
    {
        if(_menuOpen)
        {
            _menu.ClosePanel(_menuPanel);
            _menuOpen = false;
        }
        else
        {
            _menu.OpenPanel(_menuPanel);
            _menuOpen = true;
        }

    }
}
