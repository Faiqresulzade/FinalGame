public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine StateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }
}
