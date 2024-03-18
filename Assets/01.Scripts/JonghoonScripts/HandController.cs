using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform rightHand;
    public float catchRange = 0.2f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject grabbedObj;
    //bool isGrip = false;
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)){
            Ray ray = new Ray(rightHand.position,rightHand.forward);
            int layer = 1<<LayerMask.NameToLayer("PLAYER_CRASH");
            Collider[] hitInfo = Physics.OverlapSphere(rightHand.position,catchRange,layer);

            //for(int i=0;i<hitInfo.Length;i++){
            foreach(Collider hit in hitInfo){
                //hitInfo[i].transform.parent = rightHand.transform;
                hit.transform.parent = rightHand.transform;
                // 잡은애를 기억
                //grabbedObj = hitInfo[i].transform.gameObject;  
                grabbedObj = hit.transform.gameObject;  
                grabbedObj.transform.localPosition = Vector3.zero;
                break;
            }

            // isGrip = true;
        }
        
        if(OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)){
            
            if(grabbedObj){
                grabbedObj.transform.parent = null;
                grabbedObj = null;
            }
            
            // isGrip = false;
        }
    }


    // 잡을수 있는 영역 화면에 표시
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rightHand.position,catchRange);
    }


}
