using UnityEngine;

public class MoveArrow : MonoBehaviour
{

    private float _speed=5;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position+=Vector3.left*_speed*Time.deltaTime;
    }
}
