using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	private GUIStyle labelStyle;
	float initpositionx = -9;
	float initpositiony = 0.3f;
	float initpositionz = -21;
	Quaternion gyro;
	bool goal = false;
	private Vector3 acceleration;
	int count = 0;
	public float Speed = 0.3f;
	void Update () {
		if (goal == false) {
			Input.gyro.enabled = true;
			if (Input.gyro.enabled) {
				Quaternion gyro = Input.gyro.attitude;
				Quaternion action_gyro = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));
				Vector3 p = new Vector3 (0, 0, Speed);
				GetComponent<Rigidbody> ().AddForce (p);
				Vector3 c = new Vector3 (transform.position.x - 0.1f*action_gyro.z, initpositiony, transform.position.z);
				transform.position = c;
				Vector3 r = new Vector3 (0, 180 + action_gyro.z * 180 / Mathf.PI, 0);
				transform.rotation = Quaternion.Euler (r);
			}else{
				//シュミレーター上で動かすための、キーボードの入力を受け付ける
				if(Input.GetKey ("up")){
					Vector3 up = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Speed);
					transform.position = up;
				}
				
				if(Input.GetKey ("down")){
					Vector3 down = new Vector3 (transform.position.x, transform.position.y, transform.position.z - Speed);
					transform.position = down;
				}
				
				if(Input.GetKey ("right")){
					Vector3 right = new Vector3 (transform.position.x +Speed, transform.position.y, transform.position.z);
					transform.position = right;
				}
				
				if(Input.GetKey ("left")){
					Vector3 left = new Vector3 (transform.position.x - Speed, transform.position.y, transform.position.z);
					transform.position = left;
				}
				
			}
		} else {

			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}
	}

	void OnGoal() {
		goal = true;
	}
	
	
}