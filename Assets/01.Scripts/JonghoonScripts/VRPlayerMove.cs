using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class VRPlayerMove : MonoBehaviour{

    // 변수        
    private Transform centerEyeAnchorTransform;     // VR 중앙 시야 Transform    
    private float moveSpeed = 1f;                   // 이동속도                  

    public CharacterController character;
    public Vector3 moveDir;
    
    private void Start() {
        centerEyeAnchorTransform = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float fRot = moveSpeed * Time.deltaTime;

        // 트리거 버튼을 누를 경우 (왼쪽 스틱)
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)){
            Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            
            moveDir = centerEyeAnchorTransform.right* touchVector.x * fRot;
            moveDir.y -= 9.82f * Time.deltaTime;   
            moveDir += centerEyeAnchorTransform.forward* touchVector.y * fRot;
            moveDir = transform.TransformDirection(moveDir); //로컬 좌표계 -> 월드 좌표계
            
            character.Move(moveDir);

            if(transform.transform.position.z>=-7.6f){
                transform.transform.position = new Vector3(transform.transform.position.x,transform.transform.position.y,-7.6f);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //rigidbody.isKinematic = true;
    }
    private void OnCollisionExit(Collision other)
    {
        //rigidbody.isKinematic = false;
    }
}
