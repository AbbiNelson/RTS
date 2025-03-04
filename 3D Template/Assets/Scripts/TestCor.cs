using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestCor : MonoBehaviour
{
    public Transform[] path;
    IEnumerator currentMoveCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string[] messages = { "Remember", "Bloody", "Ukraine" };
        StartCoroutine(PrintMessages(messages, .5f));
        StartCoroutine(FollowPath());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentMoveCoroutine != null)
            {
                StopCoroutine (currentMoveCoroutine);
            }
            currentMoveCoroutine = Move(Random.onUnitSphere * 5, 8);
            StartCoroutine (currentMoveCoroutine);
        }
    }

    IEnumerator FollowPath()
    {
        foreach (Transform waypoint in path)
        {
            yield return StartCoroutine (Move (waypoint.position, 8));
        }
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
        
    }

    IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach (string msg  in messages)
        {
            print(msg);
            yield return new WaitForSeconds(delay);
        }
    }     
}
