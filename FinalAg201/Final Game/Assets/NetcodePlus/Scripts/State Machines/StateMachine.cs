using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    public void SwitchState(State newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }

    private void Update()
    {
        _currentState?.Tick(Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
        _currentState?.MyOnTriggerEnter(other);
    }
}
