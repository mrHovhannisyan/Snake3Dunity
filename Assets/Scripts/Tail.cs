using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Tail : MonoBehaviour
{
    public float Speed;

    public Vector3 tailTarget;

    public Snake mainSnake;

    //public GameObject tailPrefab;
    public GameObject tailObj;

    // Use this for initialization
    void Start()
    {
        mainSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<Snake>();
        Speed = mainSnake.Speed - 0.5f;
        tailObj = mainSnake.tail[mainSnake.tail.Count - 2];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tailTarget = tailObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * Speed);
    }
}
