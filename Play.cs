using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Play : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
        public void BtnPlay()
        {
            SceneManager.LoadScene("Platform");

        }
        public void BtnAbout()
        {
            SceneManager.LoadScene("Introduction");


        }
    public void BtnCredtis()
    {
        SceneManager.LoadScene("Credits");


    }
    public void BtnVoltar()
        {
            SceneManager.LoadScene("Main Menu");

        }
     
    
}
