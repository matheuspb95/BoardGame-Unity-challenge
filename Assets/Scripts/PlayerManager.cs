using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject MoveControl;
    public GameManager manager;
    int moves = 3;
    int life = 10;
    int attack = 1;
    public TMP_Text movesTXT;
    public int dicesCount = 3;
    public RectTransform DiceResultsPanel;
    public GameObject DiceTXT;
    public TMP_Text lifeTXT;
    public TMP_Text attackTXT;
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
            moves = 3;
            manager.ChangeTurn();
        }
    }

    public void EnableMove(){
        movesTXT.text = "Moves: " + moves;
        lifeTXT.text = "Life: " + life;
        attackTXT.text = "Attack: " + attack;
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

    public int ReceiveDamage(PlayerManager Enemy){
        life -= Enemy.attack;
        lifeTXT.text = "Life: " + life;
        return life;
    }

    public void CleanDices(){
        for(int i = 1; i< DiceResultsPanel.childCount; i++){
            Destroy(DiceResultsPanel.GetChild(i).gameObject);
        }        
    }

    public int[] RollDices(){
        int[] DicesResults = new int[dicesCount];
        int i;
        for(i = 0; i < dicesCount; i++){
            DicesResults[i] = UnityEngine.Random.Range(1, 7);
        }

        Array.Sort(DicesResults);
        Array.Reverse(DicesResults);

        CleanDices();
        for(i = 0; i < DicesResults.Length; i++)
        {
            GameObject diceRes = Instantiate(DiceTXT, DiceResultsPanel);
            diceRes.GetComponent<TMP_Text>().text = "" + DicesResults[i];
            diceRes.transform.localPosition -= Vector3.up * 50 * i;
            diceRes.SetActive(true);
        }
        return DicesResults;
    }

    public void Collect(){
        switch (UnityEngine.Random.Range(0, 3)){
            case 1:
                Debug.Log("Recover Health");
                life += 1;
            break;
            case 2:
                Debug.Log("Increase Next Attack");
                attack += 1;
            break;
            case 3:
                Debug.Log("Add a dice");
                dicesCount += 1;
            break;
            case 4:
                Debug.Log("Extra Move");
                moves += 1;
            break;
            default:
                Debug.Log("No collectible");
            break;
        }
    }
}
