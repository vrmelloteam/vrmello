using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectRatioOptimizer : MonoBehaviour
{

	[SerializeField] CanvasScaler _canvasScaler;
	[SerializeField] Camera _camera;
	
	// Use this for initialization
	void Start ()
	{
		if(_camera.aspect < 0.51f)
			_canvasScaler.matchWidthOrHeight = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
