using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class VRPlayerMove_old : MonoBehaviour{
    // 변수       
    // public float moveSpeed = 2f;        // 이동속도     
    // public float jumpPower = 600f;        // 점프       

    // public Camera carmera;


    // Rigidbody rigidbody;

    
    // 변수        
    private Transform centerEyeAnchorTransform;     // VR 중앙 시야 Transform    
    public float moveSpeed = 0.5f;                    // 이동속도                  


    
    private void Start()
    {
        
        centerEyeAnchorTransform = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();

        // rigidbody = GetComponent<Rigidbody>();
        // carmera = Camera.main;

    }
    private void Update()
    {
        
        // 트리거 버튼을 누를 경우
        // 왼쪽 스틱
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)){
            Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            transform.Translate(centerEyeAnchorTransform.right* touchVector.x * moveSpeed * Time.deltaTime);
            transform.Translate(centerEyeAnchorTransform.forward* touchVector.y * moveSpeed * Time.deltaTime);

            if(transform.transform.position.z>=-7.7f){
                transform.transform.position = new Vector3(transform.transform.position.x,transform.transform.position.y,-7.7f);
            }
            if(transform.transform.position.z<=-12.2f){
                transform.transform.position = new Vector3(transform.transform.position.x,transform.transform.position.y,-12.2f);
            }
            if(transform.transform.position.y<=3.3f){
                transform.transform.position = new Vector3(transform.transform.position.x,3.3f,transform.transform.position.z);
            }
            if(transform.transform.position.y>=3.3){
                transform.transform.position = new Vector3(transform.transform.position.x,3.3f,transform.transform.position.z);
            }
            if(transform.transform.position.x<=-1.9f){
                transform.transform.position = new Vector3(-1.9f,transform.transform.position.y,transform.transform.position.z);
            }
            if(transform.transform.position.x>=3.5f){
                transform.transform.position = new Vector3(3.5f,transform.transform.position.y,transform.transform.position.z);
            }


            //transform.Translate(carmera.transform.right * (moveSpeed * touchVector.x * Time.deltaTime));
            //transform.Translate(carmera.transform.forward * (moveSpeed * touchVector.y * Time.deltaTime));
        }




        // 카메라의 포워드를 플레이어의 포워드로 변경
        //transform.forward = carmera.transform.forward;
        
        // 왼쪽 스틱
        // if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick)){
        //     Vector2 touchVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //     print ("#### - 왼쪽 스틱");

        //     transform.Translate(carmera.transform.right * (moveSpeed * touchVector.x * Time.deltaTime));
        //     transform.Translate(carmera.transform.forward * (moveSpeed * touchVector.y * Time.deltaTime));
        // }

        // // 왼쪽 이동        
        // if (touchVector.x <= -0.1f) transform.Translate(carmera.transform.right * (moveSpeed * touchVector.x * Time.deltaTime));
        //     // transform.Translate(Vector3.left * (moveSpeed * Mathf.Abs(touchVector.x) * Time.deltaTime));

        // // 오른쪽 이동      
        // if (touchVector.x >= 0.1f) transform.Translate(carmera.transform.right * (moveSpeed * touchVector.x * Time.deltaTime));
        // //transform.Translate(Vector3.right * (moveSpeed * Mathf.Abs(touchVector.x) * Time.deltaTime));

        // // 위쪽 이동        
        // if (touchVector.y >= 0.1f) transform.Translate(carmera.transform.forward * (moveSpeed * touchVector.y * Time.deltaTime));
        // //transform.Translate(Vector3.forward * (moveSpeed * Mathf.Abs(touchVector.y) * Time.deltaTime));

        // // 오른쪽 이동      
        // if (touchVector.y <= -0.1) transform.Translate(carmera.transform.forward * (moveSpeed * touchVector.y * Time.deltaTime));
        // //transform.Translate(Vector3.back * (moveSpeed * Mathf.Abs(touchVector.y) * Time.deltaTime));

        // 점프             
        // if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        //     rigidbody.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);

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
