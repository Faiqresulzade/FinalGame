using UnityEngine;

public class YellowCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Yellow"))
        {
            GetComponent<Rigidbody>().mass = 500;
        }
    }
}
