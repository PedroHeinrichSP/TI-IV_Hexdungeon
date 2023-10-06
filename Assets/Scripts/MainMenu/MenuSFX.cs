using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField] private AudioSource itemClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playSound(){
        itemClick.Play();
    }
}
