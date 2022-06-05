using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
   public int rows = 5;
   public int cols = 8;
   public float tileSize = 1f;
   public int sizeMultiplier;
   public FoodManager _FoodManager;

   public Vector3[,] gridPos;
   public Camera mainCamera;

   
   [SerializeField]private GameObject referenceTile;


    void Start()
    {
        rows *= sizeMultiplier;
        cols *= sizeMultiplier;
        gridPos = new Vector3[cols, rows];
        GenerateGrid();
        _FoodManager.SpawnFood();
    }

    private void GenerateGrid() {
        for (int row = 0; row < rows; row++) {
            for (int col = 0; col < cols; col++) {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize; 

                tile.transform.position = new Vector2(posX, posY);
                gridPos[col, row] = new Vector3(posX, posY);
            }
        }

        float gridW = cols * tileSize;
        float gridH = rows * tileSize;
        //transform.position = new Vector2(-gridW / 2 + tileSize / 2, gridH / 2 - tileSize / 2);
    }
    
    void Update() {
    }
}
