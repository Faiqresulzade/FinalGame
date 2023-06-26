using Unity.VisualScripting;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    private static  RedCube _instance;
    public static RedCube Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindAnyObjectByType<RedCube>();
            }
            return _instance;
        }
    }

    public bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            GetComponent<Rigidbody>().mass = 500;
            isTrigger = true;
            Debug.Log("red");
        }
    }
}
