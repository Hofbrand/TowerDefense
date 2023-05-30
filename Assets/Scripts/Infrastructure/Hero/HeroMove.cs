using Assets.Scripts.Infrastructure.CameraLogic;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float MovementSpeed = 5f;
  //  public CharacterController Controller;

    private IInputService _inputService;
    private Camera _camera;

    private void Awake()
    {
        _inputService = AllServices.Container.Single<IInputService>();
    }

    private void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("FPS").GetComponent<Camera>();

        _camera.GetComponent<FPSCameraController>().Follow(this.gameObject);
    }

    public void Update()
    {
        Vector3 movementVector = Vector3.zero;

        if (_inputService.Axis.sqrMagnitude > 0.01f)
        {
            Debug.LogError(_inputService.Axis);
            movementVector = _inputService.Axis;
            movementVector.y = 0;
            movementVector.Normalize();

            transform.forward = movementVector;
        }

       // movementVector += Physics.gravity;

        transform.position += movementVector * MovementSpeed * Time.deltaTime;
    }
}
