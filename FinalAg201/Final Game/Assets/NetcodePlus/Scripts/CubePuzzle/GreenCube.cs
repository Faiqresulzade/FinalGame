using UnityEngine;

public class GreenCube : MonoBehaviour
{
    private static GreenCube _instance;
    public static GreenCube Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GreenCube>();
            }
            return _instance;
        }
    }

    public bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            GetComponent<Rigidbody>().mass = 500;
            isTrigger = true;
            Debug.Log("green");
        }
    }
}
