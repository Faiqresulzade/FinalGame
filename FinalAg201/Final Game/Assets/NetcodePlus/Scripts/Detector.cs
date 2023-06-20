using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
   // public event Action<Transform> OnCoinDetect;
    public event Action OnDetectGround;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("12345");
            OnDetectGround?.Invoke();
        }
    }
}
