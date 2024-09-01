using UnityEngine;
using System.Collections;

public class FlyCamera : MonoBehaviour {

	private Vector3 transfer;

	public float mouse_sensitivity = 3.0f;
	public float speed = 2.0f;

	Quaternion original_rotation;
	float rotation_x = 0F;
	float rotation_y = 0F;

	public float minimum_x = -360F;
	public float maximum_x = 360F;
	public float minimum_y = -60F;
	public float maximum_y = 60F;



	void Start() {
		original_rotation = transform.rotation;
	}

	void Update() {
		// Движения мыши,и вращение камеры
		rotation_x += Input.GetAxis("Mouse X") * mouse_sensitivity;
		rotation_y -= Input.GetAxis("Mouse Y") * mouse_sensitivity;
		rotation_x = ClampAngle (rotation_x, minimum_x, maximum_x);
		rotation_y = ClampAngle (rotation_y, minimum_y, maximum_y);
		Quaternion xQuaternion = Quaternion.AngleAxis (rotation_x, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotation_y, Vector3.right);
		transform.rotation = original_rotation * xQuaternion * yQuaternion;
		 
		//Клавиатура WSAD и курсорные клавиши
		transfer = transform.forward * Input.GetAxis("Vertical");
		transfer += transform.right * Input.GetAxis("Horizontal");
		transform.position += transfer * speed * Time.deltaTime;
	}

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F) angle += 360F;
		if (angle > 360F) angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}

}