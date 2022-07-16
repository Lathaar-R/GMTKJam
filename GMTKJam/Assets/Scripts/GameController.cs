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

    public List<PlayerDice> playerDiceList = new List<PlayerDice>();

    private void Awake()
    {
        if(instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var scp = diceCam.ScreenToWorldPoint(Input.mousePosition);

            if (Physics.Raycast(scp, diceCam.transform.forward, out hit, 50f, (1 << 3) | (1 << 7)))
            {
                //Debug.DrawLine(scp, hit.point, Color.green, 2);
                hitP = hit.point;
                
                if (obj != null)
                {
                    if(hit.collider.CompareTag("Select"))
                    {
                        //Debug.Log("a");
                        var upFace = CheckFace();
                        DiceSelect(upFace);
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

    public static GameObject CheckFace()
    {
        GameObject[] faces = GameObject.FindGameObjectsWithTag("face");

        GameObject nearFace = faces[0].gameObject;
        foreach (var face in faces)
        {
            if((Camera.main.transform.position - face.transform.position).magnitude < (Camera.main.transform.position - nearFace.transform.position).magnitude)
            {
                nearFace = face;
            }
        }

        return nearFace;
    }

    public static void BuildLevel(int level)
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

    public static void DiceSelect(GameObject face)
    {
        instance.obj.OnSelect(face);
    }

    public static void AddPlayerDice(PlayerDice dice)
    {
        instance.playerDiceList.Add(dice);
    }
    public static void RemovePlayerDice(PlayerDice dice)
    {
        instance.playerDiceList.Remove(dice);
    }
}
