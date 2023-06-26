using UnityEngine;

public class GreenCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Green"))
        {
            GetComponent<Rigidbody>().mass = 500;
        }
    }
}
