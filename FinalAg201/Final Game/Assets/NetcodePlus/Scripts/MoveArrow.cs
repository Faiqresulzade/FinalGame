using UnityEngine;

public class MoveArrow : MonoBehaviour
{

    private float _speed=1;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position+=Vector3.left*_speed*Time.deltaTime;
       // transform.position.x -= 10 * _speed;
    }
}
