using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{

  public float sensX;
  public float sensY;
  public float xRotation;
  public float yRotation;

  public InputSystem_Actions playerControls;
  private InputAction look;
  public Vector2 lookDirection;

  public Transform orientation;

  private void Awake()
  {
    playerControls = new InputSystem_Actions();
  }
    
    
  private void OnEnable()
  {
    look = playerControls.Player.Look;
    look.Enable();
  }

  private void OnDisable()
  {
    look.Disable();
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (Cursor.lockState == CursorLockMode.Locked){
      lookDirection = look.ReadValue<Vector2>(); 
      yRotation += lookDirection.x;
      xRotation -= lookDirection.y;

      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
      orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
  }
}
