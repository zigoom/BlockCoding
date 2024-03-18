using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRotation : MonoBehaviour
{
    public Material material;
    float rotateMaterial=0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",-1*Time.time);
    }
}
