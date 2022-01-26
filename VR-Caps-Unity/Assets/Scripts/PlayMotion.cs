using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class PlayMotion : MonoBehaviour
{
    private String fileName = "/home/jjgomez/Documents/VirtualCapsuleEndoscopy/position_rotation.csv";

    private Rigidbody rb;
    private StreamReader sr;
    private String line;
    private float fire_start_time;

    void Start()
    {
        fire_start_time = Time.time;
        rb = GetComponent<Rigidbody>();
        sr = new StreamReader(fileName);
        Debug.Log(fileName);
        sr.ReadLine();
        line = sr.ReadLine();
        setLocation(line);
        Debug.Log("Time.fixedDeltaTime: " + Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        if (line != null)
        {
            setLocation(line);
        }
        line = sr.ReadLine();
    }

    void setLocation(String line) {
        String[] lineArr = line.Split(";"[0]);
        transform.position = new Vector3(
            float.Parse(lineArr[0]), 
            float.Parse(lineArr[1]), 
            float.Parse(lineArr[2]));
        transform.rotation = new Quaternion(
            float.Parse(lineArr[3]),
            float.Parse(lineArr[4]),
            float.Parse(lineArr[5]),
            float.Parse(lineArr[6]));
    }

    void OnApplicationQuit()
    {
        sr.Close();
    }
}
