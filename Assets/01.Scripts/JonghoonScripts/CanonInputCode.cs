using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonInputCode : MonoBehaviour
{
    /******************************************

     # 대포에서 야체(코드)를 받았을때 처리하는 클래스

     @ 사용 클래스
     . BulletSpriteManager : 장전된 야채의 값을 보내서
      스프래이트로 UI를 표시해주기 위해 호출
     - VRGrabManager : 

    
    *******************************************/


    // 코드 야채 프리팹
    public GameObject pumpkin; 
    public GameObject radish; 
    public GameObject carrot; 
    
    // 드딩 야채들 생성 위치
    public GameObject pumpkinRePoint; 
    public GameObject radishRePoint; 
    public GameObject carrotRePoint; 

    public List<string> bulletList = new List<string>();    // 대포에 들어가는 코드 리스트
    
    public GameObject fireButton;           // 발사 버튼
    public GameObject bulletLoadButton;     // 장전 완료 확인
    public bool bulletLoad = false;         // 탄장이 가득함

    public BulletSpriteManager bulletSpriteManager;         // 스르레이트 표시에 대한 클래스
    public VRGrabManager vRGrabManager;                         // VR매니저 스크립트
    public GameObject oculusTouchForQuestAndRiftSRightModel;    // 스크립트를 가져오기 위해 사용

    public AudioClip[] audioClips;
    AudioSource audioSource;

    private bool isFail = false;
    public GameObject failText;
    public GameObject fail_waterText;
    public GameObject clearText;

    int bulletNum = 0;          

    float currentTime=0f;

    // 삭제한 코드 개수( 5개 이상 삭제 됬다면 1개씩 추가!!)
    public int pumpkinDestroyCnt = 0;
    public int radishDestroyCnt = 0;
    public int carrotDestroyCnt = 0;

    private void Start()
    {
        bulletSpriteManager = gameObject.GetComponent<BulletSpriteManager>();
        vRGrabManager = oculusTouchForQuestAndRiftSRightModel.GetComponent<VRGrabManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 없어진 야채가 5개 이상일 경우 프리팹 새로 생성
        if(carrotDestroyCnt>=5){     // move
            Instantiate(carrot,carrotRePoint.transform);
            carrotDestroyCnt--;
        }
        if(radishDestroyCnt>=5){     // left
            Instantiate(radish,radishRePoint.transform);
            radishDestroyCnt--;
        }
        if(pumpkinDestroyCnt>=5){    // right
            Instantiate(pumpkin,pumpkinRePoint.transform);
            pumpkinDestroyCnt--;
        }

        if(bulletList.Count == 0 && isFail && bulletLoad)
        {
            currentTime += Time.deltaTime;

            if(2 <= currentTime && (clearText.activeSelf==false && fail_waterText.activeSelf==false))
            {
                isFail = false;
                failText.SetActive(true);
                currentTime  = 0f;

            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(bulletList.Count<1){     //대포 안에 내용물이 0개면 발사 버튼 숨기기 + 야채 입력 불가
            
            fireButton.SetActive(false);
            bulletLoad = false;
            bulletSpriteManager.SpriteRemove( bulletList );
        }else if(bulletList.Count>=12){
            bulletLoad = true;
        }

        // 코드는 12개까지만 넣을 수 있고, 다 소비해야 다시 채울 수 있다.
        if(bulletList.Count<12&&!bulletLoad){
            bulletNum = 0;

            if (other.gameObject.tag == "COLL_MOVE") {   // 당근  BULLET_MOVE
                bulletList.Add("BULLET_MOVE");

                vRGrabManager.joint.connectedBody = null;   // 대포에 닿았을때 해당 오브젝트를 
                vRGrabManager.isTouched = false;            // 삭제 해서 오류가 남으로 이를 추가

                bulletNum = 1+((bulletList.Count-1)*3);
                bulletSpriteManager.SpriteUpdate(bulletNum);


                audioSource.clip = audioClips[0];
                audioSource.Play();
                Destroy(other.gameObject.transform.parent.gameObject);

                carrotDestroyCnt++;

            }else if(other.gameObject.tag=="COLL_TURN_LEFT") {   // 무  BULLET_TURN_LEFT
                bulletList.Add("BULLET_TURN_LEFT");
                
                vRGrabManager.joint.connectedBody = null;   
                vRGrabManager.isTouched = false;            
                
                bulletNum = 2+((bulletList.Count-1)*3);
                bulletSpriteManager.SpriteUpdate(bulletNum);

                audioSource.clip = audioClips[0];
                audioSource.Play();
                Destroy(other.gameObject.transform.parent.gameObject);

                radishDestroyCnt++;

            }else if (other.gameObject.tag == "COLL_TURN_RIGHT") {  // 호박 BULLET_TURN_RIGHT
                bulletList.Add("BULLET_TURN_RIGHT");

                vRGrabManager.joint.connectedBody = null;
                vRGrabManager.isTouched = false;
                
                bulletNum = 3+((bulletList.Count-1)*3);
                bulletSpriteManager.SpriteUpdate(bulletNum);

                audioSource.clip = audioClips[0];
                audioSource.Play();
                Destroy(other.gameObject.transform.parent.gameObject);

                pumpkinDestroyCnt++;
            }
        }

        if(bulletList.Count==1&&!bulletLoad){ // 총알이 1이며 && 발사중이 아닐경우
            bulletLoadButton.SetActive(true);
            isFail= true;
        }
    }
}
