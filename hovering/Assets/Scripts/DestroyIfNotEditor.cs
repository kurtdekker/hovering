using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfNotEditor : MonoBehaviour
{
	void Awake()
	{
		if (!Application.isEditor)
		{
			Destroy(gameObject);
		}
	}
}
