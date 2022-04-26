using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScript : VirtualSingleton<GamePlayScript>
{
    [SerializeField]
    private Text accountDisplay;
    [SerializeField]
    private GameObject prompt;
    // Start is called before the first frame update
    void Start()
    {
        accountDisplay.text = "";
        AccountDisplayText();
    }

    public void AccountDisplayText(){
        accountDisplay.text = PlayerPrefs.GetString("PlayerName");
    }

    public void PromptMenu(){
        prompt.SetActive(true);
    }

    public void Testing()
    {
        Debug.Log("Testing!!!");
    }
}
