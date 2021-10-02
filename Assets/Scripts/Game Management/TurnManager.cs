using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private static TurnManager _instance;
    public static TurnManager Main
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<TurnManager>();

                if(_instance == null)
                {
                    _instance = new GameObject("Board").AddComponent<TurnManager>();
                }
            }

            return _instance;
        }
    }



    [SerializeField] private float turnInterval;
    private Queue<BattleActorTemplate> turnOrder;

    private void GenerateTurnOrder(List<BattleActorTemplate> actorsInBattle)
    {
        IEnumerable<BattleActorTemplate> _list = actorsInBattle.OrderBy(actor => actor.Speed);
        turnOrder = new Queue<BattleActorTemplate>(_list);
    }

    private IEnumerator ManageBattleTurns()
    {
        while(GameManager.Main.State == GameManager.GameState.OnBattle)
        {
            float countdown = 0;

            while(countdown < turnInterval)
            {
                countdown += .1f;
                yield return new WaitForSecondsRealtime(.1f);
            }

            DoTurn();

            //! insert return for callback
        }
    }

    private void DoTurn()
    {
        BattleActorTemplate activeActor = turnOrder.Dequeue();

        activeActor.Act();
    }




}
