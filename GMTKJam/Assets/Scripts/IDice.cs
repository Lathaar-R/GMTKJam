using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDice : IClickable
{
    void OnSelect();

    public void ChangeState(DiceState state);

}
