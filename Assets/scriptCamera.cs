﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{

    public GameObject pc;
    public float offset_x = 1;
    public float offset_y = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pc.transform.position.x + offset_x, pc.transform.position.y + offset_y,-10);
    }
}
