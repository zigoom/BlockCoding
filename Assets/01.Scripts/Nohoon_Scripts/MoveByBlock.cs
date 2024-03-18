// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Default_Project;
// using UnityEngine.UI;
// using TMPro;
// using System;

// public class MoveByBlock : MonoBehaviour
// {

//     private enum STATE {MOVE,TURN_RIGHT,END};
//      노훈 테스트 변수들

//      class
//     Node rootNode = null;

//     Queue<int> BFX_Queue;

//     List<Node> nodeList;
    
//      state
//     private List<BlockState> stateList; //  Game에서 받은 enum list   
    
//      Component
//     Animator animator;
//     public AudioClip[] audioClip;
//     AudioSource audioSource;
//     public GameObject bgm;
//     private Rigidbody dargon_Rigidbody;


//     Variable
//     private bool isMoveDone = true; //  움직이는 조건문 한번만 돌게 하는 변수
//     private bool isWall = false;    //  앞에 벽이 있는지 확인하는 변수
//     private int stateCount = 0;     //  list의 count를 담는 변수
//     private string strForCnt;   //  Enum 을 string로 담을 변수
//     private int forCnt; // Enum으로 받은 strForCnt를 int형으로 담을 변수
//     private bool isDie = false;   //  죽었을때 true 변수
//     private bool isDieCnt = false;

//      결과 성공 ,  실패 TMP
//     public GameObject resultText;    

//     Start is called before the first frame update
//     void Start()
//     {       

//          class
//         nodeList = new List<Node>();
//         stateList = new List<BlockState>();    

//          Component
//         animator = GetComponent<Animator>();
//         audioClip = GetComponent<AudioClip[]>();
//         audioSource = GetComponent<AudioSource>();
//         dargon_Rigidbody = GetComponent<Rigidbody>();
//         audioSource.Stop();

//         stateList.Add(BlockState.MOVE);
//         stateList.Add(BlockState.MOVE);
//         stateList.Add(BlockState.IF_WALL);
//         stateList.Add(BlockState.IF_TURN_RIGHT);
//         stateList.Add(BlockState.TURN_RIGHT);
//         stateList.Add(BlockState.MOVE);
//         stateList.Add(BlockState.MOVE);

//          가정
//         stateList.Add(BlockState.FOR_START);
//         stateList.Add(BlockState.FOR_CNT_2);
//         stateList.Add(BlockState.FOR_MOVE_FORWARD);
//         stateList.Add(BlockState.FOR_END);

//         stateList.Add(BlockState.IF_WALL);

//         stateList.Add(BlockState.IF_TRUE);
//         stateList.Add(BlockState.IF_TURN_RIGHT);

//         stateList.Add(BlockState.IF_FALSE);
//         stateList.Add(BlockState.IF_MOVE);

//         stateList.Add(BlockState.MOVE);
//         stateList.Add(BlockState.MOVE);

//         stateList.Add(BlockState.IF_END);        
        
//         audioSource.clip = audioClip[0];       


//         StartCoroutine(this.MoveBlock());                                                            
//     }

//      list의 count만큼 반복하는 코루틴 함수
//     IEnumerator MoveBlock()
//     {
//         if(isDie)
//             yield return null;           

//          list의 count만큼만 반복문을 돌리기 위한 조건
//         while(stateCount < stateList.Count ) 
//         {
//               list안에 있는 enum값으로 분기 태우는 switch
//             switch(stateList[stateCount])  
//             {
//                 case BlockState.MOVE:
//                     Move();

//                 break;

//                 case BlockState.TURN_RIGHT:
//                     우회전
//                     Rotate();

//                 break;

//                 case BlockState.IF_TRUE :

//                     if(!isWall)
//                     {
//                         ++stateCount;
//                         break;
//                     }
                        

//                     if(BlockState.IF_TURN_RIGHT == stateList[stateCount+1])
//                         Rotate();
                
//                     if(BlockState.IF_MOVE == stateList[stateCount+1])
//                         Move();

//                 break;

//                 case BlockState.IF_FALSE :

//                     if(isWall)
//                     {
//                         ++stateCount;
//                         break;
//                     }

//                     if(BlockState.IF_TURN_RIGHT == stateList[stateCount+1])
//                         Rotate();
                
//                     if(BlockState.IF_MOVE == stateList[stateCount+1])
//                         Move();

//                 break;

//                 case BlockState.FOR_START:
//                     SetFor();
//                 break;

//                 default:  
//                     ++stateCount; 
//                 break;
//             }
            
//             yield return null;           
//         }
//     }

//     private void LateUpdate()
//     {
//         SetAnimation("isMove",false);
        
//     }

//     private void SetFor()
//     {
//         forCnt = int.Parse(stateList[stateCount+1].ToString().Substring(8));

//         for(int i=0; i<forCnt; ++i)
//         {
//             stateList.Insert(stateCount+2,BlockState.MOVE);
//         }

//         ++stateCount;
//     }

//     void Move()
//     {
//         if (isMoveDone)
//         {
//             SetAnimation("isMove",true);          
//             audioSource.Play();
//             isMoveDone = false;
//             iTeween을 쓰면 1 프레임안에 자연스러운 움직임 쌉가능
//             iTween.MoveBy(this.gameObject , iTween.Hash( "z",1.0f
//                                                         ,"time",1.0f
//                                                         ,"delay",0.2f
//                                                         ,"oncompletetarget", this.gameObject
//                                                         ,"oncomplete", "IsMoveDone"));

//         }

//     }

//     void Rotate()
//     {
//          우회전
//         transform.eulerAngles += new Vector3(0f,90f,0f);
//         ++stateCount;

//     }


//     Update is called once per frame
//     void Update(){}

//     void IsMoveDone()
//     {
//         isMoveDone = true;
//         ++stateCount;
//     }

//     private void OnCollisionEnter(Collision other)
//     {
//         if(isDie)
//             return;

//         if(other.gameObject.CompareTag("DEATHZONE"))    //  충돌한 Obejct가 DeathZone 
//         {
//             resultText.SetActive(true); //  실패했다 Object 활성화
//             resultText.GetComponent<TextMeshPro>().text = "FAIL!!"; //   Text 값 변경
//             animator.SetTrigger("isDeath");
//             isDie = true;
//             bgm.SetActive(false);  
//             stateList.Clear();
//             PlayAudioClip(1);            
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if(other.gameObject.CompareTag("WALL"))    //  앞에 벽이 있다면
//         {
//             Debug.Log("앞에 벽이 있단다");
//             isWall = true;

//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         Debug.Log("벽에서 탈출 했단다");
//         isWall = false;
//     }

//     private void SetAnimation(string name , bool value)
//     {
//        animator.SetBool(name,value);

//     }

//     private void PlayAudioClip(int idx)
//     {
//         audioSource.clip = audioClip[idx];
//         audioSource.Play();

//     }

//     private void InsertNode(int idx)
//     {
//         //Debug.Log("Idx : " + idx);

//         if(stateList.Count <= idx) return;

//         if(rootNode == null)
//         {
//             rootNode = new Node();
//             rootNode.blockState = stateList[idx];
//         }
//         else
//         {
//             Node temp = new Node();
//             temp.blockState = BlockState.STATE_END;
//             nodeList.Add(temp);
//             Debug.Log(nodeList.Count);
//         }        

//         //InsertNode(idx+1);
//     }
// }
