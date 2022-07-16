using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum DiceState
{
    idle,
    playing
}
public class DiceScript : MonoBehaviour
{
    private DiceState state = DiceState.idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(state == DiceState.idle)
        {

        }
        else
        {

        }
    }
}
