using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    protected override void Awake()
	{
       base.Awake();
	}

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
	{
        score = score + points;
	}
}
