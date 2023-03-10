using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour{
    //just some stats
    public int deaths;
    
    //important stuff
    private DeathScreen ds;
    public static GameMan GM=null;
    private void Awake(){
        ds = GameObject.FindGameObjectWithTag("DeathScreen").GetComponent<DeathScreen>();
        DontDestroyOnLoad(gameObject);
        
        if (GM == null){
            GM = this;
            
        }
        else{
            Destroy(gameObject);
        }
        
        
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        ds = GameObject.FindGameObjectWithTag("DeathScreen").GetComponent<DeathScreen>();
    }

    public void Die(){
        deaths++;
        ds.enabled = true;
        ds.deaths = deaths;

    }

    public void Restart(){
        SceneManager.LoadScene(1);
    }

    public void Win(){
        FadeToBlack.fb.toA = 1;
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }


}