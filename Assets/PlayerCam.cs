using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCam : MonoBehaviour
{

  [Header("Mouse Settings")]
  public float sensX;
  public float sensY;


  [Header("Inputs")]
  public InputSystem_Actions playerControls;
  private InputAction look;

  [Header("Other")]
  public float xRotation;
  public float yRotation;
  public Vector2 lookDirection;
  public Transform orientation;

  /**************** Awake ****************/
  /*
   * initialize player controls
   */
  private void Awake()
  {
    playerControls = new InputSystem_Actions();
  }

  /**************** OnEnable ****************/
  /*
   * enable player controls
   */
  private void OnEnable()
  {
    look = playerControls.Player.Look;
    look.Enable();
  }

  /**************** OnDisble ****************/
  /*
   * disable player controls
   */
  private void OnDisable()
  {
    look.Disable();
  }

  /**************** Start ****************/
  /*
   * set cursor settings 
   */
  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  /**************** Update ****************/
  /*
   * move players camera angle 
   */
  void Update()
  {
    if (Cursor.lockState == CursorLockMode.Locked){
      //get the user mouse input
      lookDirection = look.ReadValue<Vector2>(); 

      //rotate the x and y angle of the camera
      yRotation += lookDirection.x;
      xRotation -= lookDirection.y;

      //clamp vertical rotation
      xRotation = Mathf.Clamp(xRotation, -90f, 90f);

      //set the camera view
      transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
      orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
  }
}
