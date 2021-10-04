using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour
{
  
    // config param
    [Range(0.1f,10)] [SerializeField] float gameSpeed = 1;
    [SerializeField] int pointsPerBlocksDestroys = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;


    private void Awake()
    {
        int gameControllerCount = FindObjectsOfType<GameController>().Length;
        if (gameControllerCount > 1)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
      

    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        Cursor.visible = false;
    }



    private void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlocksDestroys;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
