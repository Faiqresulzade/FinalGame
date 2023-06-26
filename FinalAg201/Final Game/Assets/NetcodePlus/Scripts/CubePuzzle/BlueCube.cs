using UnityEngine;

public class BlueCube : MonoBehaviour
{
    private static readonly BlueCube _instance = new BlueCube();
    public static BlueCube Instance { get { return _instance; } }

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
