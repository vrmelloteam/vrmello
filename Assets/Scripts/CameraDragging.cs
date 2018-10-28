using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragging : MonoBehaviour
{

    public float speedH = 0f;
    public float speedV = 0f;
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    public bool set;
    public bool Drag;
    // Use this for initialization

    public Transform target;
    void Start()
    {

    }

    // Drag camera from mouse Click
    public IEnumerator moveScene()
    {

        yield return new WaitForEndOfFrame();

        yaw -= speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        

        transform.transform.parent.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


    void Update()
    {

        if (Drag)
        {

            speedH = 0.5f;
            speedV = 5f;

            if (Input.GetMouseButton(0))
            {

                //StartCoroutine (moveScene ());
                target = gameObject.transform.parent.transform;
                target.LookAt(target);
                target.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speedH, -Input.GetAxis("Mouse X") * speedV, 0));
                pitch = target.rotation.eulerAngles.x;
                yaw = target.rotation.eulerAngles.y;
                target.rotation = Quaternion.Euler(pitch, yaw, 0);

            }
            else
            {
                //  GetComponent<RotateCamera>().enabled = true;
                // GetComponent<GyroCamera>().enabled = true;
            }
        }

    }

    }

