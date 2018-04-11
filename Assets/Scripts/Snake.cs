using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    // Score
    public int score;
    public Text TextScore;

    public int RotateSpeed;

    bool ate = false;

    public GameObject tailPrefab;

    public GenerateFood food;

    // Direction to top(forward)
    Vector3 dir = Vector3.forward;

    // Track of Tail
    List<Transform> tail = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Move", 0, 0.5f);
        food.Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * RotateSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        // head current position
        Vector3 v = transform.position;

        transform.Translate(dir);

        // Have eatten something
        if (ate)
        {
            // Load Prefab into the world
            GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);

            // Keep track of it in our tail list
            tail.Insert(0, g.transform);

            ate = false;
        }

        if (tail.Count > 0)
        {
			// Give head's current position to tail's last
            tail.Last().position = v;

            // Add to front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        // Collision with Food
        if (coll.name.StartsWith("Food"))
        {
            ate = true;
            score++;
            TextScore.text = score.ToString();

            // Destroy the Food
            Destroy(coll.gameObject);

			// And generate again
            food.Generate();
        }
        else if (coll.name.StartsWith("Border") || coll.name.StartsWith("Snake"))
        {
            CancelInvoke("Move");
        }
    }
}
