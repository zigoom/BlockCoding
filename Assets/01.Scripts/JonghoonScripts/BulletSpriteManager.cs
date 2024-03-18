using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletSpriteManager : MonoBehaviour
{
    public GameObject[] bulletSprite;
    public GameObject[] codeText;
    // bulletSprite 배열의 내용
    // 0    1번    당근 Move
    // 1    장전   무   TrunLeft
    // 2           호박 TrunRight
    // 3    2번    당근 
    // 4    장전   무   
    // 5           호박
    // 6    3번    당근 
    // 7    장전   무 
    // 8           호박 
    // 9    4번    당근 
    // 10   장전   무   
    // 11          호박 

    public GameObject fail_Bullet;

    public CanonInputCode canonInputCode;
    public GameObject fireButton;   //발사버튼 끄기

    public TextMeshProUGUI bulletCntText;

    private void Start()
    {
        canonInputCode = gameObject.GetComponent<CanonInputCode>();
    }

    // 총알 삭제
    public void SpriteDelet(int num /*삭제 위치 */ ){
        
        if(num/3==0){
            canonInputCode.bulletList.RemoveAt(0);
        }else if(num/3==1){
            canonInputCode.bulletList.RemoveAt(1);
        }else if(num/3==2){
            canonInputCode.bulletList.RemoveAt(2);
        }else if(num/3==3){
            canonInputCode.bulletList.RemoveAt(3);
        }else if(num/3==4){
            canonInputCode.bulletList.RemoveAt(4);
        }else if(num/3==5){
            canonInputCode.bulletList.RemoveAt(5);
        }else if(num/3==6){
            canonInputCode.bulletList.RemoveAt(6);
        }else if(num/3==7){
            canonInputCode.bulletList.RemoveAt(7);
        }else if(num/3==8){
            canonInputCode.bulletList.RemoveAt(8);
        }else if(num/3==9){
            canonInputCode.bulletList.RemoveAt(9);
        }else if(num/3==10){
            canonInputCode.bulletList.RemoveAt(10);
        }else if(num/3==11){
            canonInputCode.bulletList.RemoveAt(11);
        }

        SpriteRemove(canonInputCode.bulletList);
    }
    // 총알 추가
    public void SpriteUpdate(int num){

        bulletSprite[num-1].SetActive(true);
        codeText[num-1].SetActive(true);
        
        SpriteRemove(canonInputCode.bulletList);
    }
    // 총알 발사
    public void SpriteFire(List<string> bulletList ){
        SpriteRemove(bulletList);
    }
    
    // 총알 초기화 및 재배열
    public void SpriteRemove( List<string> bulletList ){
        
        bulletCntText.SetText(bulletList.Count+" / 12");

        for(int i=0;i<bulletSprite.Length;i++){
            bulletSprite[i].SetActive(false);
            bulletSprite[i].transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            
            codeText[i].SetActive(false);
        }

        for(int i=0;i<bulletList.Count;i++){
            if(bulletList[i]=="BULLET_MOVE")
            {
                int num = 1+i*3-1;
                bulletSprite[num].SetActive(true);
                codeText[num].SetActive(true);
            }
            else if (bulletList[i] == "BULLET_TURN_LEFT")
            {
                int num = 2+i*3-1;
                bulletSprite[num].SetActive(true);
                codeText[num].SetActive(true);
            }
            else if (bulletList[i] == "BULLET_TURN_RIGHT")
            {
                int num = 3+i*3-1;
                bulletSprite[num].SetActive(true);
                codeText[num].SetActive(true);
            }
        }

        if(bulletList.Count==0){
            fireButton.SetActive(false);
            
        }
    }

}
