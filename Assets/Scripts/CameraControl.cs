﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    CameraControl()
    {
        
    }
    public float smoothMotionValue;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(transform.position != Target.position)
        {
            Vector3 TargetPositon = new Vector3(Target.position.x, Target.position.y, transform.position.z);




            transform.position = Vector3.Lerp(transform.position, TargetPositon, smoothMotionValue);
        }
    }

}
