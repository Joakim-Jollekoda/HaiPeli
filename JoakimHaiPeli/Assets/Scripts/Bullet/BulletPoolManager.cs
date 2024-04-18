using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
  public static BulletPoolManager Instance;
  public GameObject bulletPrefab;
  public int poolSize = 20;
  private Queue<GameObject> bulletpool = new Queue<GameObject>();
  void Awake()
  {
    Instance = this;
    initializePool();
  }
private void initializePool()
{
  for(int i = 0; i < poolSize; i++){
    GameObject newBullet = Instantiate(bulletPrefab);
    newBullet.SetActive(false);
    bulletpool.Enqueue(newBullet);
  }
}



public GameObject GetBullet(){
   if(bulletpool.Count > 0)
   { 

  GameObject bullet = bulletpool.Dequeue();
  bullet.SetActive(true);
  return bullet;
   }
 else{
  GameObject newBullet = Instantiate(bulletPrefab);
    newBullet.SetActive(true);
    return newBullet;
}
}

public void ReturnBullet(GameObject bullet){
  bullet.SetActive(false);
  bulletpool.Enqueue(bullet);
 }

}

