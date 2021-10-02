using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Main
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if(_instance == null)
                {
                    _instance = new GameObject("Board").AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }


    public enum GameState{OnBattle}

    public GameState State {get; private set;}
}
