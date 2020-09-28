using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    public enum Axis
    {
        Up,
        Forward,
        Right
    }

    public float revolutionSpeed;
    public Axis revolutionAxis;

    //[HideInInspector]
    public bool spinning = true;

    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        revolutionAxis = Axis.Up;
    }

    // Update is called once per frame
    void Update()
    {
        axis = (revolutionAxis == Axis.Up) ? Vector3.up : ((revolutionAxis == Axis.Forward) ? Vector3.forward : ((revolutionAxis == Axis.Right) ? Vector3.right : Vector3.zero));
        transform.Rotate(axis, revolutionSpeed * Time.deltaTime);
    }
}
