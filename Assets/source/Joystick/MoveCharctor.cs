using UnityEngine;
using System.Collections;

public class MoveCharctor : MonoBehaviour
{

    //先ほど作成したJoystick
    [SerializeField]
    private Joystick _joystick = null;

    //移動速度
    private const float SPEED = 0.1f;

    private void Update()
    {
        Vector3 pos = transform.position;

        float h = _joystick.Position.x;
        float v = _joystick.Position.y;

        if (h != 0 || v != 0){
			var direction = new Vector3(h, 0, v);
			transform.localRotation = Quaternion.LookRotation(direction);

			pos.x += _joystick.Position.x * SPEED;
			pos.z += _joystick.Position.y * SPEED;

			transform.position = pos;
        }
	}

}