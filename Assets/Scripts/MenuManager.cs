using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate {OnValueChanged(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChanged(){
        SoundManager.volume = volumeSlider.value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
