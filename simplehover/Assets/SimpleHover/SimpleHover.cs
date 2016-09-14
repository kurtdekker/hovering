/*
    The following license supersedes all notices in the source code.
*/

/*
    Copyright (c) 2016 Kurt Dekker/PLBM Games All rights reserved.

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

using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Rigidbody))]
public class SimpleHover : MonoBehaviour
{
	public float MinDistance = 2.0f;
	public float MaxDistance = 4.0f;
	public float MaxForce = 25.0f;

	float RaycastDownwardsFromMe()
	{
		RaycastHit rch;
		if (Physics.Raycast ( transform.position, Vector3.down, out rch, MaxDistance))
		{
			return rch.distance;
		}
		return 100;
	}

	void FixedUpdate ()
	{
		float distance = RaycastDownwardsFromMe();
		float fractionalPosition = (MaxDistance - distance) / (MaxDistance - MinDistance);
		if (fractionalPosition < 0) fractionalPosition = 0;
		if (fractionalPosition > 1) fractionalPosition = 1;
		float force = fractionalPosition * MaxForce;
		gameObject.GetComponent<Rigidbody>().AddForce( Vector3.up * force);	
	}
}
