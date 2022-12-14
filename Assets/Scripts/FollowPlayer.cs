using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float Max_Offset;
    public float speed;

    public bool doShit = false;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }
    void Update()
    {
        if (doShit == true)
        {
        Vector3 current_target = target.position + offset + (new Vector3(Movement.Instance.Direction.x, Movement.Instance.Direction.y, 0))* 2f;
        Mathf.Clamp(current_target.x, target.position.x - Max_Offset, target.position.x + Max_Offset);
        Mathf.Clamp(current_target.y, target.position.y - Max_Offset, target.position.y + Max_Offset);
        Mathf.Clamp(current_target.z, target.position.z - Max_Offset, target.position.z + Max_Offset);
        //Vector3 current_target = target.position + offset;
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, current_target, step);
        }
        else
        {
            transform.position = target.transform.position + offset;
        }
        


    }

    
}
