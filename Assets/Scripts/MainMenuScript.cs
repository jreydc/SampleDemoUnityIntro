using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    public void StartPlay(){
        SceneManager.LoadScene(sceneName:"AccountScene");
    }
}
