using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Start,
    Play,
    Pause,
    GameOver
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public class GameManager : Singleton<GameManager>
{
    public GameState state;
    public Difficulty difficulty;
    public Slider timeSlider;
    

    public int score = 0;
    public int time = 30;

    public Text timeText;
    public GameObject uiMan;
    public Dropdown difficultyMenu;




    protected override void Awake()
	{
       base.Awake();
	}

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            difficulty = Difficulty.Easy;
            difficultyMenu.value = 0;
            uiMan.GetComponent<UiManager>().DifficultyChange();
        }


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            difficulty = Difficulty.Medium;
            difficultyMenu.value = 1;
            uiMan.GetComponent<UiManager>().DifficultyChange();
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            difficulty = Difficulty.Hard;
            difficultyMenu.value = 2;
            uiMan.GetComponent<UiManager>().DifficultyChange();
        }
    }

    public void AddScore(int points)
	{
        score = score + points;
        uiMan.GetComponent<UiManager>().UpdateScore();

    }

    public void AddTime(int tick)
    {
        time = time + tick;
        if(time > 30)
        {
            time = 30;
        }
        timeText.text = ("Time: " + time);
        timeSlider.value = time;
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);

        time = time - 1;
        if (time <= 0)
        {
            time = 0;
            uiMan.GetComponent<UiManager>().StartCoolScore();
        }
        timeText.text = ("Time: " + time);
        timeSlider.value = time;
        


        StartCoroutine(CountDown());
    }
}
