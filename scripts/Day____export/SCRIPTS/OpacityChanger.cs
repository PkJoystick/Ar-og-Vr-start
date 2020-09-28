using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityChanger : MonoBehaviour
{
    public GameObject cube;

    private Color color;
    public Slider opacitySlider;
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;

    // Start is called before the first frame update
    void Start()
    {
        color = cube.GetComponent<Renderer>().sharedMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        color.a = opacitySlider.value;
        color.r = redSlider.value;
        color.g = greenSlider.value;
        color.b = blueSlider.value;
    }

    public void ChangeObjectColor()
    {
        cube.GetComponent<Renderer>().sharedMaterial.color = color;
    }
}
