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
    

    public int score = 0;
    public int time = 30;

    public Text timeText;



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
        
    }

    public void AddScore(int points)
	{
        score = score + points;
	}

    public void AddTime()
    {
        time = time + 5;
        timeText.text = ("Time: " + time);
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);

        time = time - 1;
        timeText.text = ("Time: " + time);

        StartCoroutine(CountDown());
    }
}
