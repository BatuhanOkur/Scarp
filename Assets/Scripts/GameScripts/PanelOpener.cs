using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{

    public GameObject panel;
    
    public void panelOpener()
    {
        if(panel != null)
        {
            bool isActive = panel.activeSelf;
            if(isActive == false)
            {
                PauseGame();
            }

            if(isActive == true)
            {
                ContinueGame();
            }

        }
    }

    private void PauseGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        //enable the scripts again
    }

    private void Update() {
        if (Input.GetKeyDown("escape"))
        {
            panelOpener();
        }
    }
    
    
}
