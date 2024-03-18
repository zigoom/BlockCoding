using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Title_ControllerRayCast_Left : MonoBehaviour 
{

    // 변수           
    private LineRenderer lineRendererComp;
    private RaycastHit raycastHit;
    private BoxCollider boxCollider;
    private GameObject currentRay;

    public GameObject angel;
    public GameObject gotRay;
    public float raycastDistance = 1000f;
    bool TriggerClicking = false;    // 왼쪽 트리거 버튼이 클릭중


    // 초기화          
    private void Awake() 
    {
        boxCollider = GetComponent<BoxCollider>();
        lineRendererComp = this.gameObject.AddComponent<LineRenderer>();
        // 라인 설정        
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(0, 251, 255, 0.5f);

        lineRendererComp.material = mat;
        lineRendererComp.positionCount = 2;
        lineRendererComp.startWidth = 0.01f;
        lineRendererComp.endWidth = 0.01f;


    }

    private void Update() 
    {
        // 시작 위치        
        lineRendererComp.SetPosition(0, transform.position);
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        //OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&!TriggerClicking


        // 충돌 감지 시      
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) 
        {
            lineRendererComp.SetPosition(1, raycastHit.point);
            

            angel.SetActive(true);
            gotRay.SetActive(true);       // 버튼 충돌

            if (raycastHit.collider.gameObject.CompareTag("BUTTON")){
                ButtonRayProcess();
            }
            
        }

        else
        {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));
            angel.SetActive(false);
            gotRay.SetActive(false);

            boxCollider.transform.position =transform.position + (transform.forward * raycastDistance); 

        }


        
    }

    // 왼손 정면 트리거 감지            
    public void ButtonRayProcess() 
    {    
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)&&!TriggerClicking)
        {
            TriggerClicking = true;
            SceneManager.LoadScene(3);
        }

 
        
        if ((OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)&&TriggerClicking))
            TriggerClicking = false;
        
    }
}
