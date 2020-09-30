using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneName;
    public Animator anim;
    public void OnClick()
    { 
         StartCoroutine(LoadScene());
    }

    //Timer for translation
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }


    //Exiting the game
    public void OnClickExit()
    {
        Application.Quit();
    }
}
