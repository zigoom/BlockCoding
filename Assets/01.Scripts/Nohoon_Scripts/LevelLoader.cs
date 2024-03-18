using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;

    public float transitionTime = 100f;
    
    private GameObject fireCanvas;

    // Start is called before the first frame update

    void Start()
    {
        //  Logo
        if(SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //  if(Input.GetMouseButtonDown(0))
        //  {
        //      LoadNextLevel();
        //  }
    }

    public void LoadNextLevel()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
        Debug.Log("다음 씬!");
    }

    IEnumerator LoadLevel(int levelIndex)
    {

        //  Play Animation
        animator.SetTrigger("Start");

        //  Wait
        yield return new WaitForSeconds(3);



        //  Load Scene
        SceneManager.LoadScene(levelIndex);

    }

    public void OnClickButton()
    {

    }
}
