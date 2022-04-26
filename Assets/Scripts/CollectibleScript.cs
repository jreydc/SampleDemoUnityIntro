using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    [SerializeField]private int value;

    private int result;

    private void Start()
    {
        result = 0;
        scoreText.text = "000" ;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            ScoreManagement();
        }
    }

    private void ScoreManagement()
    {
        result = result + value;
        scoreText.text = result.ToString();
    }

}
