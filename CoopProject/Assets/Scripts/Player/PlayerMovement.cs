using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AnimatorPlayer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _gravityForce;
    [SerializeField] private AnimatorPlayer _animator;
    [SerializeField] private FloatingJoystick _joystick;

    private CharacterController _controller;
    private PlayerInputActions _inputActions;
    private Vector3 _targetDirection;
    private Vector3 _inputDirection;
    private Vector3 _gravityDirection;
    private float _inputAngle;
    private float _rotationSmoothVelocity;
    private float _lockAngleValue = 0.0f;
    private bool _iMove = false;

    public bool Imove => _iMove;

    private void OnEnable()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Player.Movement.performed += GetInputDirection;
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        SetGravity();
        CreateTargetDirection();
    }

    private void GetInputDirection(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        if (_targetDirection.magnitude > 0.01f)
        {
            _iMove = true;
            _animator.Move();
            _controller.Move(_targetDirection * Time.deltaTime * _moveSpeed);
            Rotate();
            _animator.StopExtract();
        }
        else
        {
            _animator.Stop();
            _iMove = false;
        }
    }

    private void CreateTargetDirection()
    {
        if (_joystick.Vertical != 0.0f || _joystick.Horizontal != 0.0f)
            _targetDirection = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;
        else 
            _targetDirection = new Vector3(_inputDirection.x, 0.0f, _inputDirection.y).normalized;;
    }

    private void Rotate()
    {
        _inputAngle = Mathf.Atan2(_targetDirection.x, _targetDirection.z) * Mathf.Rad2Deg;
        float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,_inputAngle, ref _rotationSmoothVelocity, _rotationSpeed);
        transform.rotation = Quaternion.Euler(_lockAngleValue, targetAngle, _lockAngleValue);
    }

    private void SetGravity()
    {
        _gravityDirection.y += _gravityForce * Time.deltaTime;
        _controller.Move(_gravityDirection * _moveSpeed);
    }

    private void OnDisable()
    {
        _inputActions.Player.Movement.performed -= GetInputDirection;
    }
}