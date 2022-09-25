using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerManager Player1;
    public PlayerManager Player2;
    private int turn = 2;
    public GameObject attackPanel;
    public TMP_Text resultTXT;
    public TMP_Text GameOverTXT;
    public Transform cameraPivot;
    // Start is called before the first frame update
    void Start()
    {
        ChangeTurn();
    }

    public void ChangeTurn() 
    {
        SetCameraPos();
        if(turn == 1){
            turn = 2;
            Player2.EnableMove();

        } else if(turn == 2){
            turn = 1;
            Player1.EnableMove();
        }
    }

    public void RollDices() 
    {
        attackPanel.SetActive(true);
        
        int[] Player1Results = Player1.RollDices();
        int[] Player2Results = Player2.RollDices();

        int compareResult = 0;

        for(int i = 0; i < 3; i++){
            if(Player1Results[i] >= Player2Results[i]){
                compareResult += 1;
            } else if(Player1Results[i] < Player2Results[i]){
                compareResult -= 1;
            }
        }
        
        if(compareResult > 0){
            resultTXT.text = "Player1 Wins";
            int lifePlayer2 = Player2.ReceiveDamage(Player1);
            if(lifePlayer2 <= 0){
                EndGame("Player1 Wins");
            }
        } else if(compareResult < 0){
            resultTXT.text = "Player2 Wins";
            int lifePlayer1 = Player1.ReceiveDamage(Player2);
            if(lifePlayer1 <= 0){
                EndGame("Player2 Wins");
            }
        }
    }

    void EndGame(string text){
        GameOverTXT.transform.parent.gameObject.SetActive(true);
        GameOverTXT.text = text;
    }

    public void GoMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SetCameraPos(){
        Vector3 playersDir = turn == 2 ?  Player2.transform.position - Player1.transform.position 
                                  :  Player1.transform.position - Player2.transform.position;
        float cameraAngle = Vector3.Angle(new Vector3(1,0,1), playersDir);
        cameraPivot.position = 0.5f * (Player2.transform.position + Player1.transform.position);
        StartCoroutine(MoveCamera(new Vector3(0, cameraAngle, 0)));
        cameraPivot.localScale = Vector3.one * (5 + playersDir.magnitude) * 0.035f;
    }

    IEnumerator MoveCamera(Vector3 Dest){
        Vector3 Start = cameraPivot.eulerAngles;
        float t = 0;
        while(t < 1){
            yield return new WaitForFixedUpdate();
            t += Time.fixedDeltaTime;
            cameraPivot.eulerAngles = Vector3.Lerp(Start, Dest, t);
        }
    }
}
