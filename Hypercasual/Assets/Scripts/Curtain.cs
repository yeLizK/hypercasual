using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Curtain : MonoBehaviour
{
    private Image CurtainObject;
    private float fillAmount;
    public bool isGameOn;

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
            if(fillAmount>0.6f)
            {
                GameManager.Instance.score = 50;
            }else if(fillAmount > 0.3)
            {
                GameManager.Instance.score = 40;
            }else if(fillAmount > 0){
                GameManager.Instance.score = 25;
            }
            else{
                GameManager.Instance.score = 10;
            }
        }
    }

    public void StartGame()
    {
        isGameOn = true;
    }
    public void EndGame()
    {
        fillAmount = 1f;
        isGameOn = false;
    }
}
