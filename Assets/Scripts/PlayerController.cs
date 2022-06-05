using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    
    Vector2Int dir = Vector2Int.right;
    
    public Vector2Int GridPos;
    
    public GridManager _gridManager;
    public FoodManager _foodManager;
    public SnakeManager _snakeManager;

    public AudioClip pickup;
    public AudioClip death;
    private AudioClip _audioClip;
    void Start()
    {
        InvokeRepeating("Move", 0.1f, 0.1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            dir = Vector2Int.right;
        if (Input.GetKeyDown(KeyCode.A))
            dir = Vector2Int.left;
        if (Input.GetKeyDown(KeyCode.S))
            dir = Vector2Int.up;
        if (Input.GetKeyDown(KeyCode.W))
            dir = Vector2Int.down;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Move()
    { 
        _snakeManager.UpdateTail();
        GridPos += dir;
        if (GridPos.x < 0)
        {
            GridPos.x = _gridManager.cols - 1;
        }
        if (GridPos.x > _gridManager.cols -1)
        {
            GridPos.x = 0;
        }
        if (GridPos.y > _gridManager.rows -1)
        {
            GridPos.y = 0;
        }
        if (GridPos.y < 0)
        {
            GridPos.y = _gridManager.rows - 1;
        }
        transform.position = _gridManager.gridPos[GridPos.x, GridPos.y];
        if (GridPos == _foodManager.FoodGridPosition)
        {
            _snakeManager.SnakeGrow();
            Destroy(_foodManager.currentFoodPiece);
            _foodManager.SpawnFood();
            AudioSource.PlayClipAtPoint(pickup, transform.position);
        }
        if (_snakeManager.CheckCollision(transform.position))
        {
            AudioSource.PlayClipAtPoint(death, transform.position);
            SceneManager.LoadScene("SampleScene");   
            

        }
    }
}
