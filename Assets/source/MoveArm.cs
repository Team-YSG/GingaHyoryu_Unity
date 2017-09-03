using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour {

    GameObject cylinder1, cylinder2, cylinder3, right, left;
    Transform initPositon1, initPositon2;
	Transform muzzle;
    float speed = 1000;

    int status;
	float time;
    // Use this for initialization
	void Start () {
        status = 0;
        cylinder1 = transform.Find("Arm1").gameObject;
        cylinder2 = transform.Find("Arm1/Arm2").gameObject;
        cylinder3 = transform.Find("Arm1/Arm2/Arm3").gameObject;
        right = transform.Find("Arm1/Arm2/Arm3/rightarm").gameObject;
        left = transform.Find("Arm1/Arm2/Arm3/leftarm").gameObject;
        muzzle = transform.Find("Muzzle");

	}
	
	// Update is called once per frame
	void Update () {
       
        if(status == 0 && Input.GetMouseButtonUp(0))
		{
            time = 0;
            status = 1;
        }
        switch(status){
            case 0:
                time = 0;
                break;
			case 1:
				cylinder1.transform.position += this.transform.forward * 0.1f;
                time += Time.deltaTime;
                if (time >= 0.4f)
				{
                    time = 0;
					status = 2;
				}
				break;
			case 2:
				cylinder2.transform.position += this.cylinder1.transform.forward * 0.1f;
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 3;
				}
				break;
			case 3:
				cylinder3.transform.position += this.cylinder2.transform.forward * 0.1f;
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 4;
				}
				break;
			case 4:
                right.transform.localPosition -= new Vector3(0.05f, 0, 0);
                left.transform.localPosition += new Vector3(0.05f, 0, 0);
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 5;
				}
				break;
			case 5:
				cylinder3.transform.position -= this.transform.forward * 0.1f;
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 6;
				}
				break;
			case 6:
				cylinder2.transform.position -= this.cylinder1.transform.forward * 0.1f;
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 7;
				}
				break;
			case 7:
				cylinder1.transform.position -= this.cylinder2.transform.forward * 0.1f;
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 8;
				}
				break;
			case 8:
				right.transform.localPosition += new Vector3(0.05f, 0, 0);
				left.transform.localPosition -= new Vector3(0.05f, 0, 0);
				time += Time.deltaTime;
				if (time >= 0.4f)
				{
					time = 0;
					status = 0;
				}
                break;
            default :
                break;
        }
	}
}
