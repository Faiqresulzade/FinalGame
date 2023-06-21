using UnityEngine;



public class PlayerOpenDoorState : PlayerBaseState
{
    public PlayerOpenDoorState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Animator.SetTrigger("Open");
        StateMachine.Detector.OnDetectGround += OnDetectGround;
    }
    private void OnDetectGround()
    {
        StateMachine.SwitchState(new PlayerMoveState(StateMachine));
    }

    public override void Tick(float deltaTime)
    {
        if (Physics.Raycast(StateMachine.transform.position, Vector3.down, 1f, StateMachine.GroundLayer))
        {
            StateMachine.SwitchState(new PlayerMoveState(StateMachine));
        }
    }

    public override void Exit()
    {
        StateMachine.Detector.OnDetectGround -= OnDetectGround;
        StateMachine.Wait(3f, () =>
        {
            StateMachine.Animator.SetTrigger("Cloose");
        });

    }

    public override void MyOnTriggerEnter(Collider other)
    {
        // throw new System.NotImplementedException();
    }
}
