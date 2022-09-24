using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerManager Player1;
    public PlayerManager Player2;
    private int turn = 2;
    // Start is called before the first frame update
    void Start()
    {
        ChangeTurn();
    }

    public void ChangeTurn(){
        if(turn == 1){
            turn = 2;
            Player2.EnableMove();
        } else if(turn == 2){
            turn = 1;
            Player1.EnableMove();
        }
    }
}
