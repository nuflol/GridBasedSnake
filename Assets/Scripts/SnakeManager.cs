using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeManager : MonoBehaviour
{
    public LList<GameObject> Snake = new LList<GameObject>();
    public PlayerController _playerController;
    public FoodManager _foodManager;
    
    public GameObject playerHead;
    public GameObject snakeTail;

    public Text snakeLenght;

    public int tailAmout;

    private void Start()
    {
        Debug.Log(playerHead);
        Snake.AddFront(playerHead);
        SnakeGrow();
        SnakeGrow();

    }

    private void FixedUpdate()
    {
        tailAmout = Snake.count - 3;
        snakeLenght.text = "Score: " + tailAmout.ToString();
    }

    public void SnakeGrow()
    {
        Snake.AddLast(Instantiate(snakeTail, Snake.tail.data.transform.position, Quaternion.identity));
        
    }

    public void UpdateTail()
    {
        ListNode<GameObject> currentNode = Snake.head;
        Vector3 previousPos = Snake.head.data.transform.position;
        while (currentNode.next != null)
        {
            (currentNode.next.data.transform.position, previousPos) = (previousPos, currentNode.next.data.transform.position);
            currentNode = currentNode.next;
        }
    }

    public bool CheckCollision(Vector3 position)
    {
        ListNode<GameObject> currentNode = Snake.head.next;
        while (currentNode != null)
        {
            if (currentNode.data.transform.position == position)
            {
                return true;
            }
            currentNode = currentNode.next;
        }
        return false;
    }
}
