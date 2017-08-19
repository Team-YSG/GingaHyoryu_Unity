using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

	// bullet prefab
	public GameObject bullet;

	// 弾丸発射点
	public Transform muzzle;

	// 弾丸の速度
	public float speed = 1000;

	Plane plane = new Plane();
	float distance = 0;

    public Joystick joystick;
    public float h = 0;
    public float v = 0;

	void Update()
	{
		h = joystick.Position.x;
		v = joystick.Position.y;
        if (Input.GetMouseButtonUp(0)){
            if((h == 0 && v == 0) || 
                (h > 0.3 && h < -0.3 || 
                  v > 0.3 && v < -0.3)) {
				// カメラとマウスの位置を元にRayを準備
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
				plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
				if (plane.Raycast(ray, out distance))
				{
					// 距離を元に交点を算出して、交点の方を向く
					var lookPoint = ray.GetPoint(distance);
					transform.LookAt(lookPoint);
					Shot();
				}
            }	
        }
	}

    void Shot(){
		// 弾丸の複製
        GameObject bullets = (GameObject) Instantiate(bullet);

		Vector3 force;
		force = this.gameObject.transform.forward * speed;
		// Rigidbodyに力を加えて発射
		bullets.GetComponent<Rigidbody>().AddForce(force);
		// 弾丸の位置を調整
		bullets.transform.position = muzzle.position;
    }


}