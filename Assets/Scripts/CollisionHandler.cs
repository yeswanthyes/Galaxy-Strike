using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] GameObject explosion;
  GameSceneManager gameSceneManager;


  private void Start()
  {
    gameSceneManager = FindAnyObjectByType<GameSceneManager>();
    
  }
  void OnTriggerEnter(Collider other)
    {
      gameSceneManager.ReloadLevelhi();
         Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
