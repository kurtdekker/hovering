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

public class Mainmenu : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown( KeyCode.Alpha1))
		{
			StartSimpleHoverCube();
		}

		if (Input.GetKeyDown( KeyCode.Alpha2))
		{
			StartHoverCraft();
		}

		if (Input.GetKeyDown( KeyCode.Alpha3))
		{
			StartHoverRace();
		}

		if (Input.GetKeyDown( KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void GotoTwitter()
	{
		Application.OpenURL( "https://www.twitter.com/kurtdekker");
	}

	public void GotoBitbucket()
	{
		Application.OpenURL( "https://www.bitbucket.org/kurtdekker");
	}

	public void GotoGithub()
	{
		Application.OpenURL( "https://www.github.com/kurtdekker");
	}

	public void StartSimpleHoverCube()
	{
		GotoScene( "SimpleHoverCubeScene");
		GotoScene( "Level1", true, true);
	}

	public void StartHoverCraft()
	{
		GotoScene( "HoverCraftScene");
		GotoScene( "Level1", true, true);
	}

	public void StartHoverRace()
	{
		HoverRaceConfigure.LoadSceneStack( "Level1");
	}

	public static void GotoScene( string s, bool additive = false, bool select = false)
	{
		if (s == null)
		{
			s = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name;
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene (
			s, additive ? UnityEngine.SceneManagement.LoadSceneMode.Additive : 0);

		if (select)
		{
			CallAfterDelay.Create( 0, () => {
				UnityEngine.SceneManagement.SceneManager.SetActiveScene(
					UnityEngine.SceneManagement.SceneManager.GetSceneByName( s));
			});
		}
	}
}
