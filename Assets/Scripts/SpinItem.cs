using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinItem: MonoBehaviour
{
    public float rotationFactor;

	void Update () 
	{
		transform.Rotate(0, 0, rotationFactor * Time.deltaTime);
	}
}
