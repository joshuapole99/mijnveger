using UnityEngine;
using UnityEngine.SceneManagement;
public class Losescene : MonoBehaviour
{
   public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }
}