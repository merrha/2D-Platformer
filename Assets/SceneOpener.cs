using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    public string sceneName;
    
  public void OpenScene()

    {
        SceneManager.LoadScene(sceneName);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneName);

    }

}
