using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerinGame : MonoBehaviour
{
    public static GameObject canvas;
    private void Awake()
    {
        canvas=GameObject.FindGameObjectWithTag("Canvas");
    }
    public void OnClickPlayBTN()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnClickQuitBTN()
    {

    }
}
