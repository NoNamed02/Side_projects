using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_move : MonoBehaviour
{
    public float move_p = 0.005f;
    public MessageReceiver_custom Cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cube.Y1 < -40 && Cube.Y2 < -40)
            gameObject.transform.position += new Vector3(0f,0f,-move_p);
        else if(Cube.Y1 > 20 && Cube.Y2 > 20)
            gameObject.transform.position += new Vector3(0f,0f,move_p);
    }
}
