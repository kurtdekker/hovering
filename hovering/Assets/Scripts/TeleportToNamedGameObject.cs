using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToNamedGameObject : MonoBehaviour
{
	public string GameObjectNameToSearchFor = "<none>";		

	void Update ()
	{
		GameObject go = GameObject.Find(GameObjectNameToSearchFor);

		if (go)
		{
			transform.position = go.transform.position;
			transform.rotation = go.transform.rotation;
			
			Destroy(this);
		}
	}
}
