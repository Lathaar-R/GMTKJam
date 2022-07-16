using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);

    }

    public void TopButton()
    {

    }

    
}
