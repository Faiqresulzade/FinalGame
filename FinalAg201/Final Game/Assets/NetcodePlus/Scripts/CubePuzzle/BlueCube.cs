using UnityEngine;

public class BlueCube : MonoBehaviour
{
    private static BlueCube _instance;
    public static BlueCube Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<BlueCube>();
            }
            return _instance;
        }
    }

    public bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blue"))
        {
            GetComponent<Rigidbody>().mass = 500;
            isTrigger = true;
            Debug.Log("blue");
        }
    }
}
