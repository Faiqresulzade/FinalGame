using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMoveState : PlayerBaseState
{

    private Vector3 _direction;
    private float _currentTurnAngle;

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        StateMachine.Detector.OnDetectFloorSwitch += OnDetectFloorSwitch;
    }

    private void OnDetectFloorSwitch(Collider other)
    {
        for (int i = 0; i < StateMachine.Animator.Count; i++)
        {
            StateMachine.Animator[i].SetTrigger("Open");

        }

        StateMachine.Wait(3f, () =>
        {
            for (int i = 0; i < StateMachine.Animator.Count; i++)
            {
                StateMachine.Animator[i]?.SetTrigger("Cloose");

            }
        });
    }

    public override void Tick(float deltaTime)
    {

        _direction = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")); 

        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(StateMachine.transform.eulerAngles.y, targetAngle, ref _currentTurnAngle,
                0.3f);

            StateMachine.transform.rotation = Quaternion.Euler(0, angle, 0);

          StateMachine.Physics.MovePosition(StateMachine.transform.position + (_direction.normalized * (StateMachine.speed * Time.deltaTime)));
        }

        if (Input.GetKeyDown(KeyCode.Space) && 
            Physics.Raycast(StateMachine.transform.position, Vector3.down, 1f, StateMachine.GroundLayer))
        {
            StateMachine.SwitchState(new PlayerJumpState(StateMachine));
        }
    }

    public override void Exit()
    {
        StateMachine.Detector.OnDetectFloorSwitch -= OnDetectFloorSwitch;
    }
    public override void MyOnTriggerEnter(Collider other)
    {

    }
}
