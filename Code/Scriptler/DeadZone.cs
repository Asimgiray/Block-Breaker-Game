using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "BallTag")
        {
            GameManager.instance.loseLife();
            //Destroy(gameObject);

        }
    }
}