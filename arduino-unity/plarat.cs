using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plarat : MonoBehaviour
{
    public Circle_rotate circle1;
    public Circle2 circle2;
    private Rigidbody rb;
    public float move_p = 0.005f;
    public float turnspeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (circle1.is_move == -1 && circle2.is_move == -1)
        {
            rb.MovePosition(transform.position + transform.forward * -move_p);
        }
        else if (circle1.is_move == 1)
        {
            rb.MovePosition(transform.position + transform.forward * move_p);
        }
        else if (circle1.is_move == 3 && circle2.is_move == -2)
        {
            // 오브젝트 회전
            Quaternion deltaRotation = Quaternion.Euler(0, turnspeed * Time.deltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        else if (circle1.is_move == 2 && circle2.is_move == -3)
        {
            // 오브젝트 회전
            Quaternion deltaRotation = Quaternion.Euler(0, -turnspeed * Time.deltaTime, 0);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }
}
