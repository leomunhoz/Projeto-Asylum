using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResoluçoesEQualidade : MonoBehaviour
{
   private FullScreenMode fullScreenMode;
   public Dropdown displayMode;
  
   
   
   public void DisplayMode()
    {
        if (displayMode.value == 0)
        {
            fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if (displayMode.value == 1)
        {
            fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    
    }
   

   
   
}
