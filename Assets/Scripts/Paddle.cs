using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
   
    // configuration parameters
    [SerializeField] float screenWidthInUnits = 16;
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;

    // cached references
    GameController theGameController;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameController = FindObjectOfType<GameController>();
        theBall = FindObjectOfType<Ball>();
       
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits); // Screen Width --> The current width of the screen window in pixels
       // float mousePosInUnit = Input.mousePosition.x/ Screen.width * screenWidthInUnits;

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(/*mousePosInUnit*/GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameController.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
