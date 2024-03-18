using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    private Transform camTr;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        tr = GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        // 카메라를 처다볼때 180도 뒤집어 지는것을 해결
         transform.LookAt(2 * transform.position - tr.position);    

        //tr.LookAt(camTr.position);




    }
}
