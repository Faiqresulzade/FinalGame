using UnityEngine;

public class YellowCube : MonoBehaviour
{
    private static YellowCube _instance;
    public static YellowCube Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<YellowCube>();
            }
            return _instance;
        }
    }

    public bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yellow"))
        {
            GetComponent<Rigidbody>().mass = 500;
            isTrigger = true;
            Debug.Log("yellow");
        }
    }
}
