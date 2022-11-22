using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResoluçoesEQualidade : MonoBehaviour
{
   private FullScreenMode fullScreenMode;
    public Toggle toggle;
    public void FullHD()
    {
        Screen.SetResolution(1920, 1080, true);
    }
   
    public void HD()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void QuadHD()
    {
        Screen.SetResolution(2560, 1600, true);
    }

    public void QuatroK() 
    {
        Screen.SetResolution(3840, 2160, true);
    }
    public void Fullscream() 
    {
        fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    
    }

    public void Windowed() 
    {
        fullScreenMode = FullScreenMode.Windowed;
    
    }

    public void Vysinc() 
    {
       

        if (toggle.isOn)
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 1;

        }
        else
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = -1;
        }

    }
    public void Grafico01()
    {
        QualitySettings.SetQualityLevel(0, true);
        Debug.Log("baixo");
    }
    public void Grafico02()
    {
        QualitySettings.SetQualityLevel(1, true);
        Debug.Log("medio");
    }
    public void Grafico03()
    {
        QualitySettings.SetQualityLevel(3, true);
        Debug.Log("Alto");
    }
    
}
