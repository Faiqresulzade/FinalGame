using UnityEngine;

public class GreenCube : MonoBehaviour
{
    private static readonly GreenCube _instance = new GreenCube();
    public static GreenCube Instance { get { return _instance; } }

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
