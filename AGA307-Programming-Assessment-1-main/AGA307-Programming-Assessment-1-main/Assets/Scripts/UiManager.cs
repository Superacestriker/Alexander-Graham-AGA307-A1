using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    /* gonna be honest i see no real reason for this script since it just seems easier to have each script be able to access its own aspect of the canvas, but the assessment asks i do it.
       in my opinion target manager should get to keep track of number of targets and gamemanager should get to keep track of score and difficulty. 
       there is probably somethign im missing, but i think we should just cut the middle man.
    */

    public Text difficultyText;
    public Text TargetCountText;
    public Text ScoreText;
    public Text coolScoreText;
    public GameObject coolScoreContainer;
    public Dropdown difficultyMenu;

    public GameObject regularMenu;
    public GameObject difficultyMenuParent;
    public GameObject player;

    public int targetsLeft = 5;

    public GameObject gManager;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        ScoreText.text = ("Score: " + gManager.GetComponent<GameManager>().score);
    }

    public void DifficultyChange()
    {
        switch (gManager.GetComponent<GameManager>().difficulty)
        {
            case Difficulty.Easy:
                difficultyText.text = ("Difficulty: easy");
                break;
            case Difficulty.Medium:
                difficultyText.text = ("Difficulty: Medium");
                break;
            case Difficulty.Hard:
                difficultyText.text = ("Difficulty: HARD");
                break;
        }
    }

    public void TargetNumberChange(int Change)
    {
        targetsLeft = targetsLeft + Change;
        TargetCountText.text = ("Targets Left: "+ targetsLeft);
    }

    public void StartCoolScore()
    {
        StartCoroutine(CoolScore());
    }
    IEnumerator CoolScore()
    {
        coolScoreText.text = (gManager.GetComponent<GameManager>().score + " POINTS");
        coolScoreContainer.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gManager.GetComponent<GameManager>().AddTime(30);
        gManager.GetComponent<GameManager>().score = 0;
        ScoreText.text = ("Score: " + gManager.GetComponent<GameManager>().score);
        coolScoreContainer.gameObject.SetActive(false);
    }

    public void MenuDifficultyChange()
    {
        if(difficultyMenu.value == 0)
        {
            gManager.GetComponent<GameManager>().difficulty = Difficulty.Easy;
        }
        if (difficultyMenu.value == 1)
        {
            gManager.GetComponent<GameManager>().difficulty = Difficulty.Medium;
        }
        if (difficultyMenu.value == 2)
        {
            gManager.GetComponent<GameManager>().difficulty = Difficulty.Hard;
        }
        DifficultyChange();
        regularMenu.gameObject.SetActive(true);
        difficultyMenuParent.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<Player>().enabled = true;
    }

    

}
