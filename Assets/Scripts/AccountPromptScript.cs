using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class AccountPromptScript : MonoBehaviour
{

    [SerializeField]
    private InputField accountName;
    
    public GameObject pBox;
    // Start is called before the first frame update
    void Start()
    {
        DeactivatePrompt();
        accountName.text = "";
    }

    public void OKPrompt(){
        pBox.SetActive(true);
    }

    public void DeactivatePrompt(){
        pBox.SetActive(false);
    }

    public void ContinuePrompt(){
        PlayerPrefs.SetString("PlayerName", accountName.text);
        SceneManager.LoadScene(sceneName:"GamePlayScene");
    }
}
