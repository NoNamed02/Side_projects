using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_rotate : MonoBehaviour
{
    public MessageReceiver_custom mriseve;
    public float speed = 0.5f;
    public int is_move;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1f, 0.1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(mriseve.Y1 > 20 && mriseve.Y2 > 20){
            is_move = 1;
            transform.Rotate(Vector3.up, Time.deltaTime * speed);
            //gameObject.transform.position += new Vector3(0f,0f,-0.01f);
        }
        else if(mriseve.Y1 < -20 && mriseve.Y2 < -20){
            is_move = -1;
            transform.Rotate(Vector3.down, Time.deltaTime * speed);
            //gameObject.transform.position += new Vector3(0f,0f,-0.01f);
        }
        else if(mriseve.Y1 > 20){
            is_move = 2;
            transform.Rotate(Vector3.up, Time.deltaTime * speed);
        }
        else if(mriseve.Y1 < -20){
            is_move = 3;
            transform.Rotate(Vector3.down, Time.deltaTime * speed);
        }
        /*
        else if(mriseve.Y2 < -20 && mriseve.Y2 < -20){
            is_move = 1;
            transform.Rotate(Vector3.down, Time.deltaTime * speed);
            //gameObject.transform.position += new Vector3(0f,0f,0.01f);
            }
        else if(mriseve.Y2 > 20){
            is_move = -2;
            transform.Rotate(Vector3.up, Time.deltaTime * speed);
        }
        else if(mriseve.Y2 < -20){
            is_move = -3;
            transform.Rotate(Vector3.down, Time.deltaTime * speed);
        }
        */
        else
            is_move = 0;
    }
}
