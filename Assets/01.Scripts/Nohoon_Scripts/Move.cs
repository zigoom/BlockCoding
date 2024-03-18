using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 _position;
    public GameObject angel;


    // Start is called before the first frame update
    void Start()
    {            
        _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(angel.activeSelf == true)
            transform.position = new Vector3(transform.position.x,angel.transform.position.y,transform.position.z);
        
        else
            transform.position = _position;

    }




}
