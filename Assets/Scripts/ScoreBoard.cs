using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text scoreText;
  public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
        
    }
}
