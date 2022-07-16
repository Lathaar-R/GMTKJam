using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum DiceState
{
    idle,
    playing
}
[System.Serializable]
public class PlayerDice : MonoBehaviour, IDice
{
    //[SerializeField] Vector3[] faces;
    [SerializeField] Face[] faces;

    //private DiceState state = DiceState.idle;
    [SerializeField] Vector3 selectedPoint;
    [SerializeField] float speed;
    [SerializeField] GameObject diceCam;
    float force;


    private Rigidbody rb;
    private BoxCollider cl;
    DiceState state = DiceState.playing;
    public bool selected;
    GameObject upFace;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    ChangeState(DiceState.idle);
        //}

        //if(Input.GetKeyDown(KeyCode.A))
        //{
        //    ChangeState(DiceState.playing);
        //}
        
    }
    

    public void ChangeState(DiceState state)
    {
        if (state == DiceState.idle)
        {
            rb.isKinematic = true;
            cl.isTrigger = true;
            transform.DOMove(selectedPoint, speed);
            transform.DORotateQuaternion(faces[System.Convert.ToInt16(upFace.name)].look, speed);
        }
        else if (state == DiceState.playing)
        {
            rb.isKinematic = false;
            cl.isTrigger = false;
            var dir = selectedPoint - new Vector3(selectedPoint.x - 1, selectedPoint.y - 1, selectedPoint.z - 1);
            dir.x += Random.Range(-1f, 0.2f);
            dir.z += Random.Range(-1f, 0.2f);
            force = Random.Range(7, 10);
            rb.AddForce(dir * force, ForceMode.VelocityChange);
            rb.AddTorque(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)));
        }

        this.state = state;
    }

    public void OnClick()
    {
        if (state == DiceState.playing)
        {
            state = DiceState.idle;
            GameController.ShowSelection();
            //selected = on;
        }
    }

    public void OnSelect(GameObject face)
    {
        //if(selected)
        upFace = face;
        ChangeState(DiceState.idle);

        

        //Debug.Log(GameController.CheckFace());

    }
}
