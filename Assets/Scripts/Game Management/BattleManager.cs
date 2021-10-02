using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager _instance;
    public static BattleManager Main
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<BattleManager>();

                if(_instance == null)
                {
                    _instance = new GameObject("Board").AddComponent<BattleManager>();
                }
            }

            return _instance;
        }
    }
    

    public List<BattleActorTemplate> ActorsInBattle {get; private set;} = new List<BattleActorTemplate>();
}
