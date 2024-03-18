// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class VRPointer : MonoBehaviour
// {

//     // 변수           
//     private LineRenderer lineRendererComp;  // 레이 객체
//     private RaycastHit raycastHit;          // 충돌 대상

//     public float raycastDistance = 300f;    // 표시되는 레이의 길이

//     public GameObject lockTaget;// 스피어 타겟 
//     public GameObject point00;  // iWteen 포인트 1
//     public GameObject point01;  // iWteen 포인트 2
//     public GameObject point02;  // iWteen 포인트 3

//     bool leftTriggerClicking = false;   // 왼쪽 트리거 버튼이 클릭중

//     bool rightTriggerClicking = false;  // 오른쪽 트리거 버튼이 클릭중
//     bool rightTriggerClicking1 = false;  // 오른쪽 트리거 버튼이 클릭중
//     bool rightTriggerClicking2 = false;  // 오른쪽 트리거 버튼이 클릭중
//     bool rightTriggerClicking3 = false;  // 오른쪽 트리거 버튼이 클릭중

//     public GameObject fireButton;       // 캐논에 발사 버튼

//     public GameObject canon;     //스프레이트 매니저를 이용하기 위해서 캐논을 가져옴 (아이콘 변경)

//     public AudioClip[] audioClips;
//     private AudioSource audioSource;

//     private Animator animator;  // 아미콘 마우스 오버할 경우 커지는 애니메이션 용
//     public GameObject targetScale = null; // 마우스 오버한 아이콘 (아이콘을 벗어나거나 다른 아이콘에 갈때 체크용)


//     // 초기화          
//     private void Awake()
//     {
//         lineRendererComp = this.gameObject.AddComponent<LineRenderer>();
//         //lineRendererComp = GetComponent<LineRenderer>();
//         // 라인 설정        
//         Material mat = new Material(Shader.Find("Standard"));
//         mat.color = new Color(0, 251, 255, 0.5f);

//         lineRendererComp.material = mat;
//         lineRendererComp.positionCount = 2;
//         lineRendererComp.startWidth = 0.01f;
//         lineRendererComp.endWidth = 0.01f;

//         audioSource = GetComponent<AudioSource>();
//     }


//     private void Update()
//     {
//         // 시작 위치        
//         lineRendererComp.SetPosition(0, transform.position);
//         Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

//         // 충돌 감지 시      
//         if (Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance)) {
//             lineRendererComp.SetPosition(1, raycastHit.point);

//             // 스프레이트(아이콘) 충돌 ( 장전된 코드 다았을때 )      
//             if (raycastHit.collider.gameObject.CompareTag("SPRITE_ICON")&&!fireButton.activeSelf){
//                 if(targetScale==null){  // 공백이면 현재 애를 넣음 
//                     targetScale = raycastHit.collider.gameObject;
//                     animator = targetScale.GetComponent<Animator>();
//                     animator.SetBool("isPointer",true);
//                 }else if(targetScale!=raycastHit.collider.gameObject){ 
//                     // 전에 체크한 애랑 다른 타겟이면 전에 타겟의 크기를 줄이고 현재 타겟을 넣는다.
//                     animator.SetBool("isPointer",false); 
//                     targetScale = raycastHit.collider.gameObject;
//                     animator = targetScale.GetComponent<Animator>();
//                     animator.SetBool("isPointer",true);
//                 }
                
//                 ButtonRayProcess4(raycastHit.collider.gameObject);
//             }else{
//                 if(targetScale!=null) {
//                     animator.SetBool("isPointer",false); 
//                     targetScale = null;
//                 }

//                 // 스프레이트(아이콘)의 설명 부분에 충돌
//                 if (raycastHit.collider.gameObject.CompareTag("SPRITE_TEXT") && !fireButton.activeSelf) {
//                     ButtonRayProcess5(raycastHit.collider.gameObject);
//                 }
//                 // 버튼 충돌        
//                 if (raycastHit.collider.gameObject.CompareTag("BUTTON")) {
//                     if (raycastHit.collider.gameObject.name == "BulletLoad") {  // 장전 완료 버튼
//                         ButtonRayProcess3(raycastHit.collider.gameObject);
//                     }

//                     if (raycastHit.collider.gameObject.name == "FireButton") {   // 발사 버튼
//                         ButtonRayProcess();
//                     }
//                     if (raycastHit.collider.gameObject.name == "Retry")
//                     {
//                         ButtonRayProcess6();
//                     }

//                     if (raycastHit.collider.gameObject.name == "NextStage")
//                     {
//                         ButtonRayProcess7();
//                     }
//                 }
//                 // 대포 최종 충돌위치!!
//                 if (raycastHit.collider.gameObject.CompareTag("LOCK_POINT")){
//                     ButtonRayProcess2();
//                 }
//             }
//         } else { //레이가 충돌하지 않았을때
//             lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));
        
//             if (targetScale!=null) {
//                 animator.SetBool("isPointer", false);
//                 targetScale = null;
//             }
//         }
//     }

//     // 발사 버튼 (왼손 트리거)           
//     public void ButtonRayProcess()
//     {
//         if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && !leftTriggerClicking)
//         {
//             leftTriggerClicking = true;

//             canon.GetComponent<CanonFire>().Fire();
//             audioSource.clip = audioClips[0];
//             audioSource.Play();
//         }
//         if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) && leftTriggerClicking)
//         {
//             leftTriggerClicking = false;
//         }
//     }


//     // 발사하면 날아갈 최종 위치 (오른손 트리거)
//     public void ButtonRayProcess2()
//     {
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking)
//         {
//             rightTriggerClicking = true;

//             // 스피어를 이용한 타겟 표시
//             lockTaget.transform.position = raycastHit.point;
//             // 3번째 대포가 날아가는 위치 지정
//             point02.transform.position = raycastHit.point;
//             point01.transform.position = point00.transform.position + ((point02.transform.position - point00.transform.position) / 2) + new Vector3(0, 0.5f, 0);
//         }
//         if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && rightTriggerClicking)
//         {
//             rightTriggerClicking = false;
//         }
//     }


//     // 장전 완료 버튼 - 누르면 야채를 소비할때까지 포탄 변경 불가  (오른손 트리거)
//     public void ButtonRayProcess3(GameObject gameObject)
//     { //클릭한 게임 오브젝트
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking1)
//         {
//             rightTriggerClicking1 = true;
//             gameObject.SetActive(false);    // 장전완료 버튼 숨기기
//             fireButton.SetActive(true);     // 발사 버튼을 보이게 하기
//             canon.GetComponent<CanonInputCode>().bulletLoad = true;     // 장전 버튼을 눌러서 더이상 코드 추가 불가/
//         }
//         if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && rightTriggerClicking1)
//         {
//             rightTriggerClicking1 = false;
//         }
//     }

//     // 장전한 야채 빼기 버튼 - (오른손 트리거)
//     public void ButtonRayProcess4(GameObject gameObject)
//     { //클릭한 게임 오브젝트
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking2)
//         {
//             rightTriggerClicking2 = true;


//             targetScale = gameObject;
//             animator = targetScale.GetComponent<Animator>();
//             animator.SetBool("isPointer", false);

//             int num = int.Parse(gameObject.name.Substring(7));
//             canon.GetComponent<BulletSpriteManager>().SpriteDelet(num);
//             fireButton.SetActive(false);    // 발사 버튼 숨기기

//         }
//         if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && rightTriggerClicking2)
//         {
//             rightTriggerClicking2 = false;
//         }
//     }

//     // 장전한 야채 빼기 버튼(텍스트 이용) - (오른손 트리거)
//     public void ButtonRayProcess5(GameObject gameObject)
//     { //클릭한 게임 오브젝트
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking3)
//         {
//             rightTriggerClicking3 = true;

//             targetScale = gameObject;
//             animator = targetScale.GetComponent<Animator>();
//             animator.SetBool("isPointer", false);

//             int num = int.Parse(gameObject.name.Substring(5));
//             canon.GetComponent<BulletSpriteManager>().SpriteDelet(num);
//             fireButton.SetActive(false);    // 발사 버튼 숨기기

//         }
//         if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && rightTriggerClicking3)
//         {
//             rightTriggerClicking3 = false;
//         }
//     }

//     public void ButtonRayProcess6()
//     {
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking)
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

//     }

//     public void ButtonRayProcess7()
//     {
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !rightTriggerClicking)
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

//     }
// }
