/*
    The following license supersedes all notices in the source code.

	Copyright (c) 2018 Kurt Dekker/PLBM Games All rights reserved.

    http://www.twitter.com/kurtdekker
    
    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are
    met:
    
    Redistributions of source code must retain the above copyright notice,
    this list of conditions and the following disclaimer.
    
    Redistributions in binary form must reproduce the above copyright
    notice, this list of conditions and the following disclaimer in the
    documentation and/or other materials provided with the distribution.
    
    Neither the name of the Kurt Dekker/PLBM Games nor the names of its
    contributors may be used to endorse or promote products derived from
    this software without specific prior written permission.
    
    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS
    IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
    TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
    PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
    HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
    SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
    TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
    PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
    NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
	public	Transform	target;

	public	float		Snappiness;

	public	bool		StayBehind;

	public	float		Above = 10;
	public	float		Behind = 15;

	void Reset()
	{
		Snappiness = 3.0f;
	}

	Vector3 offset
	{
		get
		{
			return new Vector3( 0, Above, -Behind);
		}
	}

	Vector3 DesiredPosition;

	IEnumerator Start()
	{
		yield return null;		// gives teleport to spawn a chance to act

		ManualUpdate( 1.0f);
	}

	void ManualUpdate( float SnapTweenAmount)
	{
		Vector3 UsableOffset = offset;

		if (StayBehind)
		{
			float YRotation = target.rotation.eulerAngles.y;

			UsableOffset = Quaternion.Euler( 0, YRotation, 0) * UsableOffset;
		}

		DesiredPosition = target.position + UsableOffset;

		transform.position = Vector3.Lerp(
			transform.position, DesiredPosition, SnapTweenAmount);

		transform.LookAt( target);
	}

	void FixedUpdate()
	{
		ManualUpdate( Snappiness * Time.deltaTime);
	}

// turning this OFF so we can use two cameras for the race scene
//	void OnGUI()
//	{
//		float sz = Mathf.Min( Screen.width, Screen.height) * 0.15f;
//
//		float aspect = 1.5f;
//
//		Rect r = new Rect( Screen.width - sz * aspect, 0, sz * aspect, sz);
//
//		GUI.color = StayBehind ? Color.green : Color.white;
//
//		if (GUI.Button( r, "CAMERA\nBEHIND"))
//		{
//			StayBehind = !StayBehind;
//		}
//	}
}
