using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public GameObject connon;
    private CanonInputCode canonInput;


    private void Start()
    {
        canonInput = connon.GetComponent<CanonInputCode>();
    }
    
    private void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.layer == LayerMask.NameToLayer("PLAYER_CRASH")){
            Debug.Log("#### : PLAYER_CRASH - "+coll.gameObject.tag);
            if(coll.gameObject.tag=="BULLET_MOVE"){
                Debug.Log("#### : BULLET_MOVE : "+ canonInput);
                canonInput.carrotDestroyCnt++;
                Destroy(coll.gameObject);
            }
            if(coll.gameObject.tag=="BULLET_TURN_LEFT"){
                canonInput.radishDestroyCnt++;
                Destroy(coll.gameObject);
            }
            if(coll.gameObject.tag=="BULLET_TURN_RIGHT"){
                canonInput.pumpkinDestroyCnt++;
                Destroy(coll.gameObject);
            }
        }
    }
}
