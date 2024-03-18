using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Default_Project;


public class Title_ControllerRayCast_Right : MonoBehaviour 
{

    // 변수           
    private LineRenderer lineRendererComp;
    private RaycastHit raycastHit;
    private BoxCollider boxCollider;
    private GameObject currentRay;

    GameObject angel;
    GameObject godRay;
    public float raycastDistance = 1000f;
    int sceneNumber;
    float upDown=0.3f;

    Vector3 angelOriginPosition;
    
    bool TriggerClicking = false;    // 왼쪽 트리거 버튼이 클릭중


    // 초기화          
    private void Awake() 
    {
        lineRendererComp = this.gameObject.AddComponent<LineRenderer>();
        // 라인 설정        
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(0, 251, 255, 0.5f);

        lineRendererComp.material = mat;
        lineRendererComp.positionCount = 2;
        lineRendererComp.startWidth = 0.01f;
        lineRendererComp.endWidth = 0.01f;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;


    }

    private void Start()
    {
                if(sceneNumber == (int)SceneNumber.TITLE)
        {
            angel = GameObject.Find("Angel");
            godRay = GameObject.Find("Godrays");

            angelOriginPosition = angel.transform.position;

            angel.SetActive(false);
            godRay.SetActive(false);
        }
        else
        {
            angel = null;
            godRay = null;
        }
    }

    private void Update() 
    {
        // 시작 위치        
        lineRendererComp.SetPosition(0, transform.position);
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        //OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&!TriggerClicking

        switch(sceneNumber)
        {
            case (int)SceneNumber.TITLE:
            Title();

            break;

            case (int)SceneNumber.STATE:

            break;
            default:break;
        }


        


        
    }

    // 왼손 정면 트리거 감지            
    public void ButtonRayProcess() 
    {    
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)&&!TriggerClicking)
        {
            TriggerClicking = true;
            SceneManager.LoadScene(3);
        }

 
        
        if ((OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)&&TriggerClicking))
            TriggerClicking = false;
        
    }

    private void Stage()
    {


    }

    private void Title()
    {
        // 충돌 감지 시      
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) 
        {
            lineRendererComp.SetPosition(1, raycastHit.point);
            
            if(raycastHit.collider.gameObject.tag == "BUTTON")
            {
                angel.SetActive(true);
                godRay.SetActive(true);       // 버튼 충돌

                if (angel.transform.position.y > angelOriginPosition.y + 0.2 || angel.transform.position.y < angelOriginPosition.y - 0.2)
                {
                    upDown *= -1;
                }

            

            angel.transform.position = Vector3.Lerp(angel.transform.position,
                                                    new Vector3(angel.transform.position.x,angel.transform.position.y+upDown,angel.transform.position.z),
                                                    0.025f);

            if (raycastHit.collider.gameObject.CompareTag("BUTTON")){
                ButtonRayProcess();
            }
            } 

           
            
        }

        else
        {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));
            angel.transform.position = angelOriginPosition;
            angel.SetActive(false);
            godRay.SetActive(false);

            

        }

    }
}
