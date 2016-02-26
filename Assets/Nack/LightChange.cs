using UnityEngine;
using System.Collections;

public class LightChange : MonoBehaviour {


	// Use this for initialization
    public Light[] lights;
    private float timebetween = 5f;
    public float minLightTime = 5, maxLightTime = 10;

    // Use this for initialization
    void Start()
    {
        lights[0].enabled = true;
    }

    // Update is called once per frame

    void Update()
    {
        timebetween -= Time.deltaTime;
        if (timebetween <= 0)
        {
            if (lights[1].enabled)
            {
                lights[1].enabled = false;
                lights[0].enabled = true;
                lights[2].enabled = false;
                timebetween = Random.Range(minLightTime, maxLightTime);
            }
            else if (lights[0].enabled)
            {
                lights[0].enabled = false;
                lights[1].enabled = false;
                lights[2].enabled = true;
                timebetween = Random.Range(minLightTime, maxLightTime);
            }
            else if (lights[2].enabled)
            {
                lights[0].enabled = false;
                lights[1].enabled = true;
                lights[2].enabled = false;
                timebetween = 2;
            }
        }
    }

   //WORKING COPY
    /*    */
}
