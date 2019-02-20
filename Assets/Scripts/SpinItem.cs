using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationFactor;

	void Update () 
	{
		transform.Rotate(0, 0, rotationFactor * Time.deltaTime);
	}
}
