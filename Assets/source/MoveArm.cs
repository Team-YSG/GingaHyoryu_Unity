using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArm : MonoBehaviour {

    GameObject cylinder1, cylinder2, cylinder3, right, left;
    public float distance1, distance2, distance3, distance4;
    public float speed;
    public bool isHold;
    public bool isHit;
    bool isCollition;

    int status;
	float time;
    // Use this for initialization
	void Start () {
        isHit = false;
        isHold = false;
        status = 0;
        isCollition = false;
        speed = 0.4f;
        cylinder1 = transform.Find("Arm1").gameObject;
        cylinder2 = transform.Find("Arm1/Arm2").gameObject;
        cylinder3 = transform.Find("Arm1/Arm2/Arm3").gameObject;
        right = transform.Find("Arm1/Arm2/Arm3/rightarm").gameObject;
        left = transform.Find("Arm1/Arm2/Arm3/leftarm").gameObject;
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
				right.transform.localPosition += new Vector3(0.4f, 0, 0);
				left.transform.localPosition -= new Vector3(0.4f, 0, 0);
				distance4 = Vector3.Distance(right.transform.position, left.transform.position);
				time += Time.deltaTime;
				if (distance4 > 8.0f)
				{
                    isCollition = true;
					time = 0;
					status = 2;
				}
                break;
			case 2:
				cylinder1.transform.position += this.transform.forward * speed;
                distance1 = Vector3.Distance(this.transform.position, cylinder1.transform.position);
                time += Time.deltaTime;
                if (distance1 > 6)
				{
                    time = 0;
					status = 3;
				}
				break;
			case 3:
				cylinder2.transform.position += this.cylinder1.transform.forward * speed;
                distance2 = Vector3.Distance(cylinder1.transform.position, cylinder2.transform.position);
				if (distance2 > 6)
				{
					time = 0;
					status = 4;
				}
				break;
			case 4:
				cylinder3.transform.position += this.cylinder2.transform.forward * speed;
				distance3 = Vector3.Distance(cylinder2.transform.position, cylinder3.transform.position);
				if (distance3 > 6)
				{
					time = 0;
					status = 5;
				}
				break;
			case 5:
                right.transform.localPosition -= new Vector3(0.4f, 0, 0);
                left.transform.localPosition += new Vector3(0.4f, 0, 0);
                distance4 = Vector3.Distance(right.transform.position, left.transform.position);
				time += Time.deltaTime;
				if (distance4 < 0.8)
				{
					time = 0;
					status = 6;
				}
				break;
			case 6:
				cylinder3.transform.position -= this.transform.forward * speed;
				distance3 = Vector3.Distance(cylinder3.transform.position, cylinder2.transform.position);
                if (distance3 < 0.2f)
				{
                    isCollition = false;
					time = 0;
					status = 7;
				}
				break;
			case 7:
				cylinder2.transform.position -= this.cylinder1.transform.forward * speed;
				distance2 = Vector3.Distance(cylinder1.transform.position, cylinder2.transform.position);
                if (distance2 < 0.2f)
				{
					time = 0;
					status = 8;
				}
				break;
			case 8:
				cylinder1.transform.position -= this.cylinder2.transform.forward * speed;
				distance1 = Vector3.Distance(cylinder1.transform.position, this.transform.position);
                if (distance1 < 0.2f)
				{
                    
					time = 0;
                    if(isHold){
                        status = 9;
                    } else {
                        status = 0;   
                    }
				}
				break;
			case 9:
                if(isHit){
					right.transform.localPosition += new Vector3(0.4f, 0, 0);
					left.transform.localPosition -= new Vector3(0.4f, 0, 0);
					distance4 = Vector3.Distance(right.transform.position, left.transform.position);
					time += Time.deltaTime;
					if (distance4 > 8.0f)
					{
						time = 0;
						status = 10;
					}
                }
				
                break;
			case 10:
				right.transform.localPosition -= new Vector3(0.4f, 0, 0);
				left.transform.localPosition += new Vector3(0.4f, 0, 0);
				distance4 = Vector3.Distance(right.transform.position, left.transform.position);
				time += Time.deltaTime;
				if (distance4 < 0.8)
				{
                    isHit = false;
                    isHold = false;
					time = 0;
					status = 0;
				}

				break;
            default :
                break;
        }
	}

    public void setHit(){
        isHit = true;
    }

    public void setHold(bool isHold){
        this.isHold = isHold;
    }

    public int getStatus(){
        return status;
    }

    public bool getCollisiotn(){
        return isCollition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(status == 9 && other.gameObject.name == "SpaceShip"){
            this.setHit();
        }
    }


}
