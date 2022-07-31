using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    [SerializeField] private Player _player;
    private PlayerInput _playerInput;

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Punch.performed += context => _player.Punch();
        _playerInput.Player.Kick.performed += context => _player.Kick();
        _playerInput.Player.UseAbility.performed += ContextMenu => _player.UseAbility();
        
    }

    void Update()
    {
        Vector2 moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        _player.Sprinted = _playerInput.Player.Sprint.ReadValue<float>() == 0 ? false : true;

        _player.Move(moveDirection);
        _player.TurnToCamera();
    }
}