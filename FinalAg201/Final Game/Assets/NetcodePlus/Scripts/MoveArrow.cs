using UnityEngine;

public class MoveArrow : MonoBehaviour
{

    private float _speed=1;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position=new Vector3 ((transform.position.x- .1f* _speed), transform.position.y, transform.position.z);
       // transform.position.x -= 10 * _speed;
    }
}
