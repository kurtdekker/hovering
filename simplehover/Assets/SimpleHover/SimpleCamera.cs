using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
	public	Transform	target;

	public	float		Snappiness;

	public	bool		StayBehind;

	void Reset()
	{
		Snappiness = 3.0f;
	}

	Vector3 offset;

	Vector3 DesiredPosition;

	void Start ()
	{
		offset = transform.position - target.position;
	}
	
	void FixedUpdate ()
	{
		Vector3 UsableOffset = offset;

		if (StayBehind)
		{
			float YRotation = target.rotation.eulerAngles.y;

			UsableOffset = Quaternion.Euler( 0, YRotation, 0) * UsableOffset;
		}

		DesiredPosition = target.position + UsableOffset;

		transform.position = Vector3.Lerp(
			transform.position, DesiredPosition, Snappiness * Time.deltaTime);

		transform.LookAt( target);
	}

	void OnGUI()
	{
		float sz = Mathf.Min( Screen.width, Screen.height) * 0.15f;

		float aspect = 1.5f;

		Rect r = new Rect( Screen.width - sz * aspect, 0, sz * aspect, sz);

		GUI.color = StayBehind ? Color.green : Color.white;

		if (GUI.Button( r, "CAMERA\nBEHIND"))
		{
			StayBehind = !StayBehind;
		}
	}
}
