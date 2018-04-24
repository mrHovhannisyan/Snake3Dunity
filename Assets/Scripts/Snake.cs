using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    // Score
    public int score;
    public Text TextScore;

    // Speed
    public float Speed = 1;
    public int RotateSpeed;

    public GameObject tailPrefab;
    public GenerateFood food;

    // Direction to top(forward)
    Vector3 dir = Vector3.forward;

    // List of Tail
    public List<GameObject> tail = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        food.Generate();
        tail.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * RotateSpeed * Time.deltaTime);
        }
    }

    public void AddTail()
    {
        Vector3 newTailPos = tail[tail.Count - 1].transform.position;
        tail.Add(GameObject.Instantiate(tailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }

    void OnTriggerEnter(Collider coll)
    {
        // Collision with Food
        if (coll.CompareTag("Food"))
        {
            score++;
            TextScore.text = score.ToString();

            AddTail();

            // Destroy the Food
            Destroy(coll.gameObject);

            // And generate again
            food.Generate();
        }
        if (coll.CompareTag("Border") || coll.CompareTag("Tail"))
        {
            Debug.Log("Game over");
        }
    }
}
