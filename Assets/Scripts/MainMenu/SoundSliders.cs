using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider musicSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("SFX Volume")){
            PlayerPrefs.SetFloat("SFX Volume", 1);
            PlayerPrefs.SetFloat("MusicVolume", 1);
            load();
        }
        else{
            load();
        }
    }
    public void changeVolume(){
        AudioListener.volume = sfxSlider.value;
        AudioListener.volume = musicSlider.value;
        save();
    }

    private void load(){
        sfxSlider.value = PlayerPrefs.GetFloat("SFX Volume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    
    private void save(){
        PlayerPrefs.SetFloat("SFX Volume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
}
