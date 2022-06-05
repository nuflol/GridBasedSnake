using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodManager : MonoBehaviour
{
   public Vector2Int FoodGridPosition;
   [SerializeField]private GameObject FoodPiece;
   [SerializeField]private GridManager _gridmanager;

   public GameObject currentFoodPiece;

   public void SpawnFood()
   {
      int x = Random.Range(0, _gridmanager.cols);
      int y = Random.Range(0, _gridmanager.rows);
      Vector3 position = _gridmanager.gridPos[x, y];
      currentFoodPiece = Instantiate(FoodPiece, position, Quaternion.identity);
      FoodGridPosition = new Vector2Int(x, y);
   }

   private void FixedUpdate()
   {
     
   }
}
