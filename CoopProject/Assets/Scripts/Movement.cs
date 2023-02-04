using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _gravityForce;

    private CharacterController _controller;
    private PlayerInputActions _inputActions;
    private Vector3 _targetDirection;
    private Vector3 _gravityDirection;
    private float _inputAngle;
    private float _rotationSmoothVelocity;
    private float _lockAngleValue = 0.0f;

    private void OnEnable()
    {
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
        _inputActions.Player.Movement.performed += OnMove;
    }

    private void OnDisable()
    {
        _inputActions.Player.Movement.performed -= OnMove;
    }

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        SetGravity();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        print(context.ReadValue<Vector2>());
        CreateTargetDirection(context.ReadValue<Vector2>());
    }

    private void Move()
    {
        if (_targetDirection.magnitude > 0.01f)
        {
            _controller.Move(_targetDirection * Time.deltaTime * _moveSpeed);
            Rotate();
        }     
    }

    private void CreateTargetDirection(Vector2 inputDirection)
    {
        _targetDirection = new Vector3(inputDirection.x, 0.0f, inputDirection.y).normalized;  
    }

    private void Rotate()
    {
        _inputAngle = Mathf.Atan2(_targetDirection.x, _targetDirection.z) * Mathf.Rad2Deg;
        float targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                _inputAngle, ref _rotationSmoothVelocity, _rotationSpeed);
        transform.rotation = Quaternion.Euler(_lockAngleValue, targetAngle, _lockAngleValue);
    }

    private void SetGravity()
    {
        _gravityDirection.y += _gravityForce * Time.deltaTime;
        _controller.Move(_gravityDirection * _moveSpeed);
    }
}
