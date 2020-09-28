using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndRotate : MonoBehaviour
{
    public enum MouseButtons
    {
        Left,
        Right,
        Middle
    }

    public enum Axis
    {
        Up,
        Forward,
        Right
    }

    public float rotationSpeed;
    public MouseButtons mouseButton = new MouseButtons();
    public Axis axis;

    private bool spinning = false;
    private string clickableLayerName = "Clickable";
    private Vector3 rotationAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (Input.GetMouseButtonDown((int)mouseButton) && hit.collider.gameObject.layer == LayerMask.NameToLayer(clickableLayerName))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    spinning = spinning ? false : true;
                }
            }
        }
        rotationAxis = (axis == Axis.Up) ? Vector3.up : ((axis == Axis.Forward) ? Vector3.forward : ((axis == Axis.Right) ? Vector3.right : Vector3.zero));
        if (spinning)
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
