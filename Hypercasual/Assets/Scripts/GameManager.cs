using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private Camera MainCamera;
    [SerializeField] private ReferenceCharSO references;
    public Curtain curtainObject;
    private Vector3 referenceObjectPosition;
    public GameObject ReferenceObject;
    public Transform ReferenceObjectParent;
    public int score;
    public bool isGameOn;

    //Panels
    public GameObject StartGamePanel;
    public TMP_Text InfoText, ScoreText;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        MainCamera = Camera.main;
    }
    private void Start()
    {
        referenceObjectPosition = new Vector3(-2.47f, 3.43f, 12.46f);
        score = 0;
    }
    private void Update()
    {
        if(StartGamePanel.activeSelf == false  && isGameOn ==true)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    string name = hit.collider.gameObject.name + "(Clone)";
                    if (hit.collider.gameObject.tag.Equals(ReferenceObject.tag) && name.Equals(ReferenceObject.name))
                    {
                        Win();
                    }
                    else if(hit.collider.gameObject.tag.Equals(ReferenceObject.tag))
                    {
                        Lose();
                    }
                }
            }
        }
    }

    public void ChooseAReferenceChar()
    {
        if(ReferenceObjectParent.childCount>0)
        {
            Destroy(ReferenceObjectParent.GetChild(0).gameObject);
        }
        int index = Random.Range(0, references.ReferenceCharList.Count);
        ReferenceObject =Instantiate(references.ReferenceCharList[index], referenceObjectPosition, Quaternion.Euler(new Vector3(0,180f,0)));
        ReferenceObject.transform.parent = ReferenceObjectParent;
    }

    public void StartGame()
    {
        InfoText.text = "";
        isGameOn = true;
        ChooseAReferenceChar();
        curtainObject.StartGame();
    }

    public void EndGame()
    {
        isGameOn = false;
        curtainObject.EndGame();
        ScoreText.text = score.ToString();
        StartGamePanel.SetActive(true);
    }
    private void Lose()
    {
        InfoText.text = "You LOSE!";
        EndGame();
    }

    private void Win()
    {
        InfoText.text = "You WIN!";
        EndGame();
    }

    public void AddScore(int additionalAmount)
    {
        score += additionalAmount;
    }
}
