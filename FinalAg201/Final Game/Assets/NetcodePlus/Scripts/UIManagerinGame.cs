using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerinGame : MonoBehaviour
{
    public static GameObject canvas;
    public static UIManagerinGame Instance;

    public bool _isClick;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }
    public void OnClickPlayBTN()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void KlikForOpen()
    {
        _isClick = true;
        Debug.Log("HelloWorld");
    }
    public void OnClickQuitBTN()
    {

    }
}
