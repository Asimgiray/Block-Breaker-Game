using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


    //public float distance = 10;
    public float PaddleSpeed = 1f;

    private Vector3 PlayerPos = new Vector3(0, -6.79f, -6.7f);

    
    void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Mouse X") * PaddleSpeed);
        PlayerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -6.79f, -6.7f);
        transform.position = PlayerPos;


        


    }
   /* void onMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,0,distance);
        Vector3 objPosition = Camera.main.ScreenToViewportPoint(mousePosition);
        transform.position = objPosition;
    }*/
}
