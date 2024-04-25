using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{
    public static EnemyPoolManager Instance;
    

      public GameObject enemyPrefab;
  public int poolSize = 20;
  private Queue<GameObject> enemypool = new Queue<GameObject>();
    void Awake(){
        Instance = this;
        InitializePool();
    }
    
private void InitializePool()
{
  for(int i = 0; i < poolSize; i++){
    GameObject newenemy = Instantiate(enemyPrefab);
    newenemy.SetActive(false);
    enemypool.Enqueue(newenemy);
  }
}
    
    public GameObject GetEnemy(){
    if(enemypool.Count > 0)
    { 

    GameObject enemy = enemypool.Dequeue();
    enemy.SetActive(true);
    return enemy;
    }
    else{
    GameObject newenemy = Instantiate(enemyPrefab);
      newenemy.SetActive(true);
      return newenemy;
    }
}

public void Returnenemy(GameObject enemy){
  enemy.SetActive(false);
  enemypool.Enqueue(enemy);
 }

}



