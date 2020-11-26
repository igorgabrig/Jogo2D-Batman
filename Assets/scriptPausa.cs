using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPausa : MonoBehaviour
{

    private bool pausa = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pausa){
                pausa = false;
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(0);
            }else{
                pausa = true;
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
        }
    }
}
