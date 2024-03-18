using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour{
    public Transform[] path;

    public GameObject bullet_Carrot;
    public GameObject bullet_Radish;
    public GameObject bullet_Pumpkin;

    public GameObject bullet;       // 이번에 생성할 야체
    public GameObject bullet_Pre;   // 프리팹으로 생성한 야체(iTween 을 위해서 퍼블릭으로 담음)

    public CanonInputCode canonInputCode;
    public BulletSpriteManager bulletSpriteManager;


    // 발사버튼 숨김
    // 명령어를 대포에 채워주세요 나옴

    private void Start()
    {
        canonInputCode = gameObject.GetComponent<CanonInputCode>();
        bulletSpriteManager = gameObject.GetComponent<BulletSpriteManager>();
    }

    void OnDrawGizmos()
    {
        iTween.DrawPath(path);
    }

    public void Fire(){
        if(canonInputCode.bulletList.Count>0){
            if(canonInputCode.bulletList[0]=="BULLET_MOVE")
            {
                bullet = bullet_Carrot;
            }
            else if (canonInputCode.bulletList[0] == "BULLET_TURN_LEFT")
            {
                bullet = bullet_Radish;
            }
            else if (canonInputCode.bulletList[0] == "BULLET_TURN_RIGHT")
            {
                bullet = bullet_Pumpkin;
            }
            bullet_Pre = Instantiate(bullet, path[0]);
            iTween.MoveTo(bullet_Pre, iTween.Hash("path", path, "time", 1, "easetype", iTween.EaseType.linear, "movetopath", false));
            canonInputCode.bulletList.RemoveAt(0);
            bulletSpriteManager.SpriteFire(canonInputCode.bulletList);
        }
    }
}
