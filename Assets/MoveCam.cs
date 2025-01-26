using UnityEngine;

public class MoveCam : MonoBehaviour
{
  public Transform cameraPos;

  /**************** Update ****************/
  /*
   * track the camera's position to the
   *  position the camera should be 
   */
  void Update()
  {
    transform.position = cameraPos.position;
  }
}
