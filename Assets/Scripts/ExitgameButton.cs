using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip DM_CGS_20;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitGame()
    {
        audioSource.PlayOneShot(DM_CGS_20);
        SceneManager.LoadScene("StartScene");
    }
}
