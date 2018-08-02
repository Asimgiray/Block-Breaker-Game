using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float velocity = -20f;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        if(transform.position.y <= -15)
        {
            Destroy(gameObject);
        }

        rb.isKinematic = false;
        rb.AddForce(new Vector3(0, velocity, 0));

        gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("PaddleTag").transform.position, 9f * Time.deltaTime);
		
	}
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "PaddleTag")
        {
            GameManager.instance.loseLife();
            Destroy(this.gameObject);

            GameObject ball = GameObject.FindGameObjectWithTag("BallTag");
            if(ball != null)
            {
                Destroy(ball);
            }

        }
    }
}
