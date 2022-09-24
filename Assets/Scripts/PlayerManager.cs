using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject MoveControl;
    public GameManager manager;
    int moves = 3;
    public TMP_Text movesTXT;
    // Start is called before the first frame update
    void Start()
    {
        manager = Camera.main.GetComponent<GameManager>();        
    }

    public void MoveChar(Vector3 targetPosition){
        transform.position = targetPosition;
        moves -= 1;
        EnableMove();
        if(moves <= 0){
            MoveControl.SetActive(false);
            moves = 0;
            manager.ChangeTurn();
        }
    }

    public void EnableMove(){
        movesTXT.text = "Moves: " + moves;
        if(MoveControl != null){
            MoveControl.SetActive(true);
            foreach (Transform child in MoveControl.transform)
            {
                child.gameObject.SetActive(false);
                child.gameObject.SetActive(true);
            }
        } else {
            Debug.LogError("Move Control not found");
        }
    }
}
