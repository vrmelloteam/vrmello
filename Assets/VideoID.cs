using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoID : MonoBehaviour {

    public CameraDragging CameraDrag;
    public int VideoIndex;
	// Use this for initialization
	void Start () {
        CameraDrag.Drag = false;
    }
	
	// Update is called once per frame
	
    public void TouchOnVideo() {
        CameraDrag.Drag = true;
        GameManger.ActiveVideoIndex = VideoIndex;
        Debug.Log(GameManger.ActiveVideoIndex + "Touched Video");
    }
    public void UnTouchOnVideo()
    {
        CameraDrag.Drag = false;
    }
}
