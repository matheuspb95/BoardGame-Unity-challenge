using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAttack : MonoBehaviour
{
    private PlayerManager Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if(other.tag == "Player"){
            Enemy = other.gameObject.GetComponent<PlayerManager>();
            gameObject.SetActive(true);
        } else {
            Enemy = null;
        }
    }

    // void OnMouseDown(){
    //     if(Enemy != null){
    //         Enemy.ReceiveDamage();
    //     } else {
    //         Debug.Log("No enemy");
    //     }
    // }
}
