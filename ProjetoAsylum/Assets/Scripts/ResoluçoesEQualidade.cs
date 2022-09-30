using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoluçoesEQualidade : MonoBehaviour
{
    public void Reso01()
    {
        Screen.SetResolution(1920, 1080, true);
    }
   
    public void Reso04()
    {
        Screen.SetResolution(1280, 720, true);
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
