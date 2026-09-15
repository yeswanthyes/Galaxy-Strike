using UnityEngine;

public class Enemy : MonoBehaviour

{
    [SerializeField] GameObject explosion;
    [SerializeField] int HitPoints = 15;
    [SerializeField] int ScoreValue = 10;
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindAnyObjectByType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        Hit();
    }

    private void Hit()
    {
        HitPoints--;
        if (HitPoints <= 0)
        {
            scoreBoard.AddScore(ScoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
