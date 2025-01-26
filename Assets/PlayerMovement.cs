using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

  [Header("Movement")]
  public float moveSpeed;
  public InputSystem_Actions playerControls;
  private InputAction move;
  private InputAction attack;

  [Header("Cookie")]
  public LayerMask Cookie;
  public CookieWall cw;

  public float playerHeight;
  public Transform orientation;
  public Logic logic;
  
  Vector3 moveDirection;
  Rigidbody rb;

  private void Awake()
  {
    playerControls = new InputSystem_Actions();
  }

  private void OnEnable()
  {
    move = playerControls.Player.Move;
    move.Enable();

    attack = playerControls.Player.Attack;
    attack.Enable();
    attack.performed += Attack;
  }
  
  private void OnDisable()
  {
    move.Disable();
    attack.Disable();
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
  }


  // Update is called once per frame
  void Update()
  {
    MyInput();
    //SpeedControl();
  }

  void FixedUpdate()
  {
    MovePlayer();
  }

  void MyInput()
  {
    moveDirection = move.ReadValue<Vector2>();
  }

  void MovePlayer()
  {
    Vector3 movement = orientation.TransformDirection(new Vector3(moveDirection.x, 0f, moveDirection.y));
    transform.Translate(movement * moveSpeed * Time.deltaTime);
  }

  private void Attack(InputAction.CallbackContext context)
  {
    if (Physics.Raycast(orientation.position, orientation.forward, out RaycastHit hitInfo, 100f, Cookie)){
      Destroy(hitInfo.collider.gameObject);
      cw.numCookies--;
      logic.AddScore();
    }
  }
}
