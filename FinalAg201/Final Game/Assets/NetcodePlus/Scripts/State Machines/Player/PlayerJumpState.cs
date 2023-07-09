using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Physics.AddForce(Vector3.up * 7.5f, ForceMode.Impulse);
        StateMachine.Detector.OnDetectGround += OnDetectGround;
    }

    private void OnDetectGround()
    {
        StateMachine.SwitchState(new PlayerMoveState(StateMachine));
    }
        
    public override void Tick(float deltaTime)
    {
        if(StateMachine.joystick.Vertical <0.5)
        {
            StateMachine.SwitchState(new PlayerMoveState(StateMachine));
        }
    }

    public override void Exit()
    {
        StateMachine.Detector.OnDetectGround -= OnDetectGround;
    }

    public override void MyOnTriggerEnter(Collider other)
    {

    }
}
