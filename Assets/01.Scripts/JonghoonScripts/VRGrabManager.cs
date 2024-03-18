using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrabManager : MonoBehaviour{
    private GameObject grabObject;
    public bool isTouched = false;
    public FixedJoint joint;

    void Start()
    {
        joint = GetComponent<FixedJoint>();
    }
    private void Update()
    {
        //  Object 잡았을때
        if(isTouched ==true && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)) {
            joint.connectedBody = grabObject.GetComponent<Rigidbody>();
        }

        //  Object 놓았을때
        if(isTouched ==true && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)) {
            //  오른손에 있는 속도 산출
            Vector3 _velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);

            grabObject.GetComponent<Rigidbody>().velocity = _velocity;
            
            joint.connectedBody = null;
            isTouched = false;
        }

        // // 왼쪽 스틱
        // if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)){
        //     Vector2 vector2 = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //     print ("#### - 왼쪽 스틱");
        // }
        
        // // 오른쪽 스틱
        // if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick)){
        //     Vector2 vector2 = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //     print ("#### - 오른쪽 스틱 ");
        // }

        // // 왼쪽 앞 버튼
        // if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
        //     print("#### - 왼쪽 앞 버튼");
        // }
        // // 오른쪽 앞 버튼
        // if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)){
        //     print("#### - 오른쪽 앞 버튼");
        // }
        
        // // 왼쪽 옆 버튼
        // if(OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)){
        //     print("#### - 왼쪽 옆 버튼");
        // }
        // // 오른쪽 옆 버튼
        // if(OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)){
        //     print("#### - 오른쪽 옆 버튼");
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        //  충돌한 Obejct의 Tag가 "CUBE_"를 가지고 있을때 
        if(other.gameObject.tag=="COLL_MOVE"||other.gameObject.tag=="COLL_TURN_RIGHT"||other.gameObject.tag=="COLL_TURN_LEFT")
        {
            isTouched = true;
            grabObject = other.gameObject.transform.parent.gameObject;

        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //         //  충돌한 Obejct의 Tag가 "CUBE_"를 가지고 있을때 
    //     if(other.gameObject.tag.Contains("CUBE"))
    //     {
    //         isTouched = false;
    //         grabObject = null;

    //     }
    // }
}
