using Assets.Scripts.Infrastructure.CameraLogic;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.EventSystems;

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
            movementVector = _inputService.Axis;
            movementVector.y = 0;
            movementVector.Normalize();

        //    transform.forward = movementVector;
        }

        //rotate gameObjeect by input x axis and y axis
       // check if input x axis is greater than input y axis by absolute value
       if(Mathf.Abs(_inputService.AxisR.x) > Mathf.Abs(_inputService.AxisR.z))
        {
            transform.Rotate(0, _inputService.AxisR.x, 0);
            return;
        }
        
        //transform.Rotate(-_inputService.AxisR.z, 0, 0);
        
     

       // movementVector += Physics.gravity;

        transform.position += movementVector * MovementSpeed * Time.deltaTime;
    }
}
