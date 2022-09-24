using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public PlayerManager Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable(){
        if((transform.position.x < 0 || transform.position.z < 0) ||
            (transform.position.x > 15 || transform.position.z > 15)){
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            gameObject.SetActive(false);
        }
    }

    void OnMouseDown(){
        Player.MoveChar(transform.position);
    }
}
