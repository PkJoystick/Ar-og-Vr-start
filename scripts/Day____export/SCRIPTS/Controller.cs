using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Transform spoiler;
    public Transform turnTable;
    public Text buttonText;

    public Button backButton;

    private Revolution revolution;

    private void OnLevelWasLoaded()
    {
        backButton.onClick.AddListener(
            delegate {
                //MenuManager._instance.LoadScene(0);
            }
        );
    }

    private void Start()
    {
        revolution = turnTable.GetComponent<Revolution>();
    }

    private void Update()
    {
        if (!revolution.spinning)
            buttonText.text = "START";
        else
            buttonText.text = "STOP";
    }

    public void MoveSpoiler(string direction)
    {
        float directionFloat = 1.0f;
        switch (direction)
        {
            case "up":
                directionFloat = 1.0f;
                break;
            case "down":
                directionFloat = -1.0f;
                break;
            default:
                directionFloat = 1.0f;
                break;
        }
        
        spoiler.Rotate(Vector3.right, directionFloat * 100.0f * Time.deltaTime);

        Debug.Log(isWithinRange(spoiler.rotation.eulerAngles.x, 0.0f, 90.0f));

        Vector3 rot = new Vector3(spoiler.rotation.eulerAngles.x - 180.0f, spoiler.rotation.eulerAngles.y - 180.0f, spoiler.rotation.eulerAngles.z - 180.0f);
        Debug.Log(spoiler.rotation.eulerAngles);
    }

    public void StartStop()
    {
        revolution.enabled = !turnTable.GetComponent<Revolution>().enabled;
        revolution.spinning = !revolution.spinning;
    }


    void normalize(float angle)
    {
        while (angle < -180) angle += 360;
        while (angle > 180) angle -= 360;
    }

    bool isWithinRange(float testAngle, float a, float b)
    {
        a -= testAngle;
        b -= testAngle;
        normalize(a);
        normalize(b);
        if (a * b >= 0)
            return false;
        return Mathf.Abs(a - b) < 180;
    }

}
