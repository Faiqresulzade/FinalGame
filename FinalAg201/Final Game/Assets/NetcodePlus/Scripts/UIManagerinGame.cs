using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerinGame : MonoBehaviour
{
    public void OnClickPlayBTN()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnClickQuitBTN()
    {

    }
}
