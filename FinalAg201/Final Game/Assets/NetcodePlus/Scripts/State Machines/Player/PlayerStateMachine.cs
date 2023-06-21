using System;
using System.Collections;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public LayerMask GroundLayer { get; set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [SerializeField] public float speed;

    public Rigidbody Physics { get; private set; }
    public Detector Detector { get; private set; }

   // private State _currentState;



    private void Awake()
    {
        Physics = GetComponent<Rigidbody>();
        Detector = GetComponentInChildren<Detector>();
        SwitchState(new PlayerMoveState(this));
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FloorSwitch"))
        {

        }

    }

    public  IEnumerator WaitForSeconds(float time,Action OnComplate)
    {
        yield return new WaitForSeconds(time);
        OnComplate?.Invoke();
    }

    public void Wait(float Time,Action OnComplate)
    {
        StartCoroutine(WaitForSeconds(Time,OnComplate));
    }
}
