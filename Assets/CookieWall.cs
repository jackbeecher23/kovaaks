using UnityEngine;

public class CookieWall : MonoBehaviour
{
  
  [Header("Wall Settings")]
  public int maxCookies;
  public int numCookies;
  public int width;
  public int height;

  [Header("Cookie Settings")]
  public Vector3 scale;
  public GameObject Cookie; 



  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    scale = new Vector3(1, 1, 1);
    numCookies = 0;
    AddCookies();
  }

  // Update is called once per frame
  void Update()
  {
    if (numCookies < maxCookies){
      AddCookies();
    }

  }

  void AddCookies()
  {
    int randX, randY;
    int widthRange = width/2;
    int radius = 1;
    while (numCookies < maxCookies){
      randX = -1;
      randY = -1;
      while (!validCookieLocation(randX, randY)){
        randX = Random.Range(-(widthRange - radius), (widthRange - radius));
        randY = Random.Range(radius, height - radius);
      }
      //GameObject cookie = Instantiate(Cookie, (new Vector3(randX, .5f, randZ)), transform.rotation, transform);
      GameObject cookie = Instantiate(Cookie, new Vector3(randX, randY, transform.position.z + .5f), Quaternion.identity);
      cookie.transform.localScale = scale; 
      numCookies++;
    }
  }

  bool validCookieLocation(int x, int y){
    if (x == -1){
      return false;
    }
    return true;
  }
}
