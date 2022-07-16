using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public static GameController instance;


    private RaycastHit hit;
    public GameObject selectButton;
    public Camera diceCam;

    IDice obj;
    Vector3 hitP = Vector3.zero;

    public List<IDice> playerDiceList = new List<IDice>();

    private void Awake()
    {
        if(instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var scp = diceCam.ScreenToWorldPoint(Input.mousePosition);

            if (Physics.Raycast(scp, diceCam.transform.forward, out hit, 50f, 1 << 3))
            {
                //Debug.DrawLine(scp, hit.point, Color.green, 2);
                hitP = hit.point;
                
                if (obj != null)
                {
                    if(hit.collider.CompareTag("Select"))
                    {
                        //Debug.Log("a");
                        DiceSelect();
                    }
                    obj = null;
                    HideSelection();
                }
                else
                {
                    if (hit.collider.TryGetComponent(out obj))
                    {
                        obj.OnClick();
                    }
                }    
            }

        }
    }

    public void PlayDice(bool player)
    {
        if(player)
        {
            foreach (var dice in playerDiceList)
            {
                dice.ChangeState(DiceState.playing);
            }
        }
    }

    public static void BuildLevel(int level)
    {

    }

    public static void TopButton()
    {

    }

    public static void ShowSelection()
    {
        //if(instance.selectButton == null)
        //    instance.selectButton = GameObject.Find("Select");

        instance.selectButton.SetActive(true);
        instance.selectButton.transform.position = instance.hitP + new Vector3(1.5f, 0.2f, -0.2f);

    }

    public static void HideSelection()
    {
        instance.selectButton.SetActive(false);
    }

    public static void DiceSelect()
    {
        instance.obj?.OnSelect();
    }

    public static void AddPlayerDice(IDice dice)
    {
        instance.playerDiceList.Add(dice);
    }
    public static void RemovePlayerDice(IDice dice)
    {
        instance.playerDiceList.Remove(dice);
    }
}
