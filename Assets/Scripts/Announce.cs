using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Announce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Disable(){
        transform.parent.gameObject.SetActive(false);
    }

    public void AddAnnounce(string message){
        GetComponent<TMP_Text>().text = message;
        transform.parent.gameObject.SetActive(true);
        Invoke("Disable", 1f);
    }
}
