using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevelhi()
    {
        StartCoroutine(ReloadLevel());
    }

    public IEnumerator ReloadLevel()
    {
        yield return new WaitForSeconds(3f);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }
}