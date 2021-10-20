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

public class GameManager : MonoBehaviour
{
    public GameState state;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Start;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
