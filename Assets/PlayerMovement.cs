using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

  [Header("Movement")]
  public float moveSpeed;
  public InputSystem_Actions playerControls;
  private InputAction move;
  private InputAction attack;

  [Header("Targets")]
  public LayerMask Cookie;
  public CookieWall cw;

  [Header("Other")]
  public float playerHeight;
  public Transform orientation;
  public Logic logic;
  public Vector3 moveDirection;
  public Rigidbody rb;

  /**************** Awake ****************/
  /*
   * initialize input controls 
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
    move = playerControls.Player.Move;
    move.Enable();

    attack = playerControls.Player.Attack;
    attack.Enable();
    attack.performed += Attack;
  }

  /**************** OnDisble ****************/
  /*
   * disable player controls
   */
  private void OnDisable()
  {
    move.Disable();
    attack.Disable();
  }

  /**************** Start ****************/
  /*
   * set rigid body up 
   */
  void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
  }


  /**************** Update ****************/
  /*
   * collect user move input
   */
  void Update()
  {
    moveDirection = move.ReadValue<Vector2>();
  }

  /**************** FixedUpdate ****************/
  /*
   * move player (synced with physics engine) 
   */
  void FixedUpdate()
  {
    MovePlayer();
  }

  /**************** MovePlayer ****************/
  /*
   * move player based on input 
   */
  void MovePlayer()
  {
    //orient their movement to the direction they currently face
    Vector3 movement = orientation.TransformDirection(new Vector3(moveDirection.x, 0f, moveDirection.y));
    transform.Translate(movement * moveSpeed * Time.deltaTime);
  }

  /**************** Attack ****************/
  /*
   * shoot at target 
   */
  private void Attack(InputAction.CallbackContext context)
  {
    //if hit target
    if (Physics.Raycast(orientation.position, orientation.forward, out RaycastHit hitInfo, 100f, Cookie)){
      
      //delete target
      Destroy(hitInfo.collider.gameObject);

      //update logic
      cw.numCookies--;
      logic.AddScore();
    }
  }
}
