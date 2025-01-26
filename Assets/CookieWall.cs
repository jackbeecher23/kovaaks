using UnityEngine;

public class CookieWall : MonoBehaviour
{
  
  [Header("Wall Settings")]
  public int maxCookies;
  public int numCookies;
  public int width;
  public int height;

  [Header("Cookie (target) Settings")]
  public Vector3 scale;
  public GameObject Cookie; 

  /**************** Start ****************/
  /*
   * add targets to wall 
   */
  void Start()
  {
    scale = new Vector3(1, 1, 1);
    numCookies = 0;
    AddCookies();
  }

  /**************** Update  ****************/
  /*
   * add targets to wall 
   */
  void Update()
  {
    if (numCookies < maxCookies){
      AddCookies();
    }

  }

  /**************** AddCookies  ****************/
  /*
   * place targets in random location on wall 
   */
  void AddCookies()
  {
    int randX, randY;
    int widthRange = width/2;
    int radius = 1;
    
    //while not enough targets 
    while (numCookies < maxCookies){

      //get a random location
      randX = Random.Range(-(widthRange - radius), (widthRange - radius));
      randY = Random.Range(radius, height - radius);

      //create the object at the location
      GameObject cookie = Instantiate(Cookie, new Vector3(randX, randY, transform.position.z + .5f), Quaternion.identity);
      cookie.transform.localScale = scale; 

      //increment target counter
      numCookies++;
    }
  }
}
