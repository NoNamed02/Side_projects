using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_move : MonoBehaviour
{
    public MessageReceiver_custom Cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Cube.Y < -40)
            gameObject.transform.position += new Vector3(0f,0f,-0.01f);
        else if(Cube.Y > 20)
            gameObject.transform.position += new Vector3(0f,0f,0.01f);
    }
}
