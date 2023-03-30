using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Curtain : MonoBehaviour
{
    private Image CurtainObject;
    private float fillAmount;
    public bool isGameOn;
    private int currentScore;

    private void Start()
    {
        CurtainObject = GetComponent<Image>();
        fillAmount = 1f;
        isGameOn = false;
    }
    private void Update()
    {
        if(fillAmount >0 && isGameOn ==true)
        {
            fillAmount -= Time.deltaTime * 0.05f;
            CurtainObject.fillAmount = fillAmount;
            if(fillAmount>0.66f)
            {
                currentScore = 50;
            }else if(fillAmount > 0.33)
            {
                currentScore = 40;
            }
            else if(fillAmount > 0){
                currentScore = 25;
            }
            else
            {
                currentScore = 10;
            }
        }
    }

    public void StartGame()
    {
        isGameOn = true;
    }
    public void EndGame()
    {
        CurtainObject.fillAmount = 0f;
        GameManager.Instance.AddScore(currentScore);
        fillAmount = 1f;
        isGameOn = false;
    }
}
