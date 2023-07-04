using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMoveState : PlayerBaseState
{

    private Vector3 _direction;
    private float _currentTurnAngle;
    private bool isOpenDoor;

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        StateMachine.Detector.OnDetectFloorSwitch += OnDetectFloorSwitch;
        StateMachine.Detector.OnDetectOpenLever += OnDetectOpenLever;
        StateMachine.Detector.OnDetectPuzzleCube += OnDetectPuzzleCube;
        StateMachine.Detector.OnDetectKey += OnDetectKey;
        StateMachine.Detector.OnDetectRoom3OpenDoor += OnDetectRoom3OpendDoor;
    }

    public override void Exit()
    {
        StateMachine.Detector.OnDetectFloorSwitch -= OnDetectFloorSwitch;
        StateMachine.Detector.OnDetectOpenLever -= OnDetectOpenLever;
        StateMachine.Detector.OnDetectPuzzleCube -= OnDetectPuzzleCube;
        StateMachine.Detector.OnDetectKey -= OnDetectKey;
        StateMachine.Detector.OnDetectRoom3OpenDoor -= OnDetectRoom3OpendDoor;
    }


    public override void Tick(float deltaTime)
    {

        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;

            float angle = Mathf.SmoothDampAngle(StateMachine.transform.eulerAngles.y,
            targetAngle, ref _currentTurnAngle, 0.3f);

            StateMachine.transform.rotation = Quaternion.Euler(0, angle, 0);

            StateMachine.Physics.MovePosition(StateMachine.transform.position +
            (_direction.normalized * (StateMachine.speed * Time.deltaTime)));

            StateMachine.MoveAnim.SetBool("Run", true);
        }
        else
        {
            StateMachine.MoveAnim.SetBool("Run", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) &&
            Physics.Raycast(StateMachine.transform.position, Vector3.down, 1f, StateMachine.GroundLayer))
        {
            StateMachine.SwitchState(new PlayerJumpState(StateMachine));
        }
    }



    private void OnDetectOpenLever(Collider other, Animator animator, GameObject UIOpenLever, Animator Opendooranimator)
    {

        UIOpenLever.SetActive(true);

        if (Input.GetKeyDown(KeyCode.O) && !isOpenDoor)
        {
            isOpenDoor = true;
            animator.SetTrigger("OpenLever");
            Opendooranimator.SetTrigger("DoorOpen");
        }

        StateMachine.Wait(5f, () =>
        {
            isOpenDoor = false;
        });
    }

    private void OnDetectPuzzleCube(Collider other)
    {
        StateMachine.SwitchState(new PuzzleCubeState(StateMachine));
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

    private void OnDetectKey(Collider other, GameObject UIKeySetActive)
    {
        other.gameObject.SetActive(false);

        UIKeySetActive.gameObject.SetActive(true);
    }

    private void OnDetectRoom3OpendDoor(Animator animator, GameObject UIKeySetActive, GameObject UIPressOSetActive)
    {
        //Debug.Log("qwertkolui");
        //UIPressOSetActive.gameObject.SetActive(true);
        //Debug.Log("qwert");
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    Debug.Log("qwerty");
        //    animator.SetTrigger("Open");
        //    UIKeySetActive.SetActive(false);
        //}
    }

    public override void MyOnTriggerEnter(Collider other)
    {

    }
}
