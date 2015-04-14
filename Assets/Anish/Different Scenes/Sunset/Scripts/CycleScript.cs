using UnityEngine;
using System.Collections;

public class CycleScript : MonoBehaviour {

    public float rotateAmount = 1f;
    public Material[] boxArray;
    public float timeToChange = 10f;

    private float actualRotation = 0;

    //Extra rotation due to starting at midday.
    private static int derpAdjustment = 90;
    private int activeSkybox = 3;
    private float lerpStart;

	// Use this for initialization
	void Start () {
        lerpStart = Time.time;
	}
	
	// Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Time.deltaTime * rotateAmount, 0, 0, Space.World);

        actualRotation = (actualRotation + Time.deltaTime * rotateAmount) % 360;

        Debug.Log(boxArray[activeSkybox]);
        Debug.Log(activeSkybox);

        //Debug.Log(actualRotation);

        /*
        if (activeSkybox != 0)
        {
            //Debug.Log("Larp");

            RenderSettings.skybox.Lerp(boxArray[activeSkybox - 1], boxArray[activeSkybox], Time.deltaTime * smoothing);//Time.deltaTime * smoothingremainingTransition / skyTransitionTime);
        }

        else
        {
            RenderSettings.skybox.Lerp(boxArray[boxArray.Length-1], boxArray[activeSkybox], Time.deltaTime * smoothing);//Time.deltaTime * smoothingremainingTransition / skyTransitionTime);
        }*/

        if ((actualRotation + derpAdjustment) % 360 >= activeSkybox * 72)
        {
            Debug.Log("Advance!!!");
            lerpStart = Time.time;
            activeSkybox++;
            activeSkybox %= boxArray.Length;

            RenderSettings.skybox = boxArray[activeSkybox];
        }

        //Debug.Log(Time.time / 10);

        float proportion = (Time.time - lerpStart) / timeToChange;//Mathf.Lerp(0.0f, 1.0f, ((Time.time - lerpStart) / timeToChange));

        Debug.Log(proportion);

        RenderSettings.skybox.SetFloat("_Blend", proportion);
        //rend.material.Lerp(first, second, Time.time / 10);
        //RenderSettings.skybox = rend.material; //.Lerp(boxArray[1], boxArray[2], Time.time / 10);

    }
}
