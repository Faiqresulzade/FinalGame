using UnityEngine;

public class YellowCube : MonoBehaviour
{
    private static readonly YellowCube _instance = new YellowCube();
    public static YellowCube Instance { get { return _instance; } }

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
