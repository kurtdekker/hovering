using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneHelper
{
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
