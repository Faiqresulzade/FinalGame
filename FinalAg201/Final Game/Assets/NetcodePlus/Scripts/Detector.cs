using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
   // public event Action<Transform> OnCoinDetect;
    public event Action OnDetectGround;
    public event Action<Collider> OnDetectFloorSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("12345");
            OnDetectGround?.Invoke();
        }

        if (other.CompareTag("FloorSwitch"))
        {
            Debug.Log("12345");
            OnDetectFloorSwitch?.Invoke(other);
        }
    }
}
