using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleActorTemplate : MonoBehaviour
{
    public float Speed {get; protected set;}

    public void Act()
    {
        Think();
        Move();
        Execute();
        Rest();
    }

    protected abstract void Think();

    protected abstract void Move();

    protected abstract void Execute();

    protected abstract void Rest();
}
