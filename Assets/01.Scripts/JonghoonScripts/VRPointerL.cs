using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRPointerL : MonoBehaviour
{

    // 변수           
    private LineRenderer lineRendererComp;  // 레이 객체
    private RaycastHit raycastHit;          // 충돌 대상

    public float raycastDistance = 300f;    // 표시되는 레이의 길이

    bool leftTriggerClicking = false;   // 왼쪽 트리거 버튼이 클릭중
    bool rightTriggerClicking = false;  // 오른쪽 트리거 버튼이 클릭중

    public GameObject fireButton;       // 캐논에 발사 버튼
    public GameObject canon;     //스프레이트 매니저를 이용하기 위해서 캐논을 가져옴 (아이콘 변경)

    public AudioClip[] audioClips;
    private AudioSource audioSource;


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

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        
    }


    private void Update()
    {
        // 시작 위치        
        lineRendererComp.SetPosition(0, transform.position);
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // 충돌 감지 시      
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) {
            lineRendererComp.SetPosition(1, raycastHit.point);

            // BUTTON 태그이면서 이름이 FireButton 일 경우 충돌 - 발사 버튼
            if (raycastHit.collider.gameObject.CompareTag("BUTTON") && raycastHit.collider.gameObject.name == "FireButton") {
                //if (!OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) { }
                ButtonRayProcess();
            }
        } else { //레이가 충돌하지 않았을때
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));
        }
    }

    // 발사 버튼 (왼손 트리거)           
    public void ButtonRayProcess()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !leftTriggerClicking)
        {
            leftTriggerClicking = true;

            canon.GetComponent<CanonFire>().Fire();
            audioSource.clip = audioClips[0];
            audioSource.Play();
        } else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && leftTriggerClicking) {
            leftTriggerClicking = false;
        }
    }
}
