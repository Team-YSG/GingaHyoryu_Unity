using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDummy : MonoBehaviour {
	bool isMove;
	float speed;
    MoveArm arm;

	// Use this for initialization
	void Start () {
        arm = GameObject.Find("Player").GetComponent<MoveArm>();
		isMove = true;
		speed = 0.2f;
	}
	void OnTriggerEnter(Collider collision)
	{
		bool isArmCollsion = arm.getCollisiotn();
		if (isArmCollsion && (collision.gameObject.name == "CollisionUp" || collision.gameObject.name == "CollisionDown" ||
							  collision.gameObject.name == "CollisionRight" || collision.gameObject.name == "CollisionLeft"))
		{
            Destroy(gameObject);
		}

        if(collision.gameObject.name == "Player"){
            Destroy(gameObject);
        }
	}
	// Update is called once per frame
	void Update () {
		if (isMove)
		{
			transform.position -= new Vector3(0, 0, speed);
			if (transform.localPosition.z < -20)
			{
				Destroy(gameObject);
			}
		}
	}
}
