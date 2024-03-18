using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBunny : MonoBehaviour
{
    
    //  Object
    public GameObject carrotEffect;
    public GameObject failText;
    public GameObject clearText;
    public GameObject bgm;
    //  Class

    //  Component
    private Animator animator;
    public AudioClip[] audioClip;
    private AudioSource audioSource;

    //  Variable
    bool isDie = false;
    bool isClear = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // audioClip = GetComponent<AudioClip[]>();
        audioSource = GetComponent<AudioSource>();
        
        audioSource.clip = audioClip[0]; 
        audioSource.Stop();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
         animator.SetBool("isMove",false);
         animator.SetBool("isTurn",false);
    }

    private void Move()
    {
        iTween.MoveBy(this.gameObject , iTween.Hash( "z",1.0f
                                                        ,"time",1.0f
                                                        ,"delay",0.2f));
        animator.SetBool("isMove",true);
        

    }

    private void TurnRight()
    {
        iTween.RotateTo(this.gameObject,iTween.Hash("rotation",transform.eulerAngles + new Vector3(0,90,0)
                                                    ,"speed",100.0f
                                                    ,"easetype",iTween.EaseType.linear));
        animator.SetBool("isTurn",true);

    }

    private void TurnLeft()
    {
        iTween.RotateTo(this.gameObject,iTween.Hash("rotation",transform.eulerAngles + new Vector3(0,-90,0)
                                                    ,"speed",100.0f
                                                    ,"easetype",iTween.EaseType.linear));
        animator.SetBool("isTurn",true);

    }

    private void OnTriggerEnter(Collider other)
    {
        //  충돋한게 당근이라면(앞으로 한칸 움직이게하는 총알)
        if(other.gameObject.tag == "BULLET_MOVE")
        {
            Instantiate(carrotEffect);
            carrotEffect.transform.position = other.transform.position;
            Destroy(other.gameObject);
                        audioSource.clip = audioClip[0];
            audioSource.Play();
            Move();


        }

        else if(other.gameObject.tag == "BULLET_TURN_RIGHT")
        {
            Instantiate(carrotEffect);
            carrotEffect.transform.position = other.transform.position;
            Destroy(other.gameObject);
                        audioSource.clip = audioClip[0];
            audioSource.Play();
            TurnRight();


        }

        else if(other.gameObject.tag == "BULLET_TURN_LEFT")
        {
            Instantiate(carrotEffect);
            carrotEffect.transform.position = other.transform.position;
            Destroy(other.gameObject);
                        audioSource.clip = audioClip[0];
            audioSource.Play();
            TurnLeft();
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "BULLET_MOVE")
        {
            Move();
            //Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "DEATHZONE")
        {
            if(!isDie)
            {
                isDie = true;
                animator.SetTrigger("isDie");
                failText.SetActive(true);
                bgm.GetComponent<AudioSource>().Stop();
                audioSource.clip = audioClip[1];
                audioSource.Play();
            }


        }

        if(other.gameObject.tag == "END_OBJECT")
        {
            if(!isClear)
            {
                isClear = true;
                clearText.SetActive(true);
                bgm.GetComponent<AudioSource>().Stop();
                audioSource.clip = audioClip[2];
                audioSource.Play();
            }

        }

    }
}
