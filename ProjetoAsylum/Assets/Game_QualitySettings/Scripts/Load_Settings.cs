// Game Quality Settings
// AliyerEdon in Winter 2022
//				
//

// This script used to load game settings in the gameplay scene
using UnityEngine;
using System.Collections;

public class Load_Settings : MonoBehaviour
{
	#region Variables
	[Space(7)]
	[Header("and quality only on the first scene of the game")]
	[Header("the first scene .You need to apply resolution")]
	[Header("Use this to apply resolution/quality in ")]
	public bool isFirstScene = true;

	[Space(7)]
	[Header("FPS Display")]
	public Color fpsColor = Color.yellow;
	public TextAnchor alignment = TextAnchor.UpperRight;
	public FontStyle fontStyle = FontStyle.Bold;

	[Space(7)]
	[Header("Effects Volume")]
	public UnityEngine.Rendering.PostProcessing.PostProcessVolume globalVolume;

	#endregion

	void Start ()
	{
		#region Default Settings

		// Set the game default setting when it is the first run on the device
		if (PlayerPrefs.GetInt("The First Run") != 1) // 1 = true; others = 0
		{
			// Se the default settings for effects
			PlayerPrefs.SetInt("Display FPS", 0);
		
			PlayerPrefs.SetInt("vSync", 0);
			

			// Set the default quality level
			PlayerPrefs.SetInt("Quality Level", 0);

			// Store the device original resolution
			PlayerPrefs.SetInt("OriginalX", Screen.width);

			PlayerPrefs.SetInt("OriginalY", Screen.height);

			// The is not the first run anymore
			PlayerPrefs.SetInt("The First Run", 1);
		}
		
		#endregion

		#region Apply Settings

		Camera[] cams = GameObject.FindObjectsOfType<Camera>();
		//_________________________________________________
		if (PlayerPrefs.GetInt("Display FPS") == 1)
		{
			if (!gameObject.GetComponent<Display_FPS>())
				gameObject.AddComponent<Display_FPS>();

			gameObject.GetComponent<Display_FPS>().color = fpsColor;
			gameObject.GetComponent<Display_FPS>().fontStyle = fontStyle;
			gameObject.GetComponent<Display_FPS>().alignment = alignment;
		}
		else
		{
			Display_FPS[] dFPS = GameObject.FindObjectsOfType<Display_FPS>();

			for (int a = 0; a < dFPS.Length; a++)
				Destroy(dFPS[a]);
		}

		
		//_________________________________________________
		if (PlayerPrefs.GetInt("vSync") == 0)
			QualitySettings.vSyncCount = 0;
		else
			QualitySettings.vSyncCount = 1;
		//_________________________________________________
		for (int a = 0; a < cams.Length; a++)
		{
			if (PlayerPrefs.GetInt("HDR") == 1)
				cams[a].allowHDR = true;
			if (PlayerPrefs.GetInt("HDR") == 0)
				cams[a].allowHDR = false;
		}
		//_________________________________________________
		#endregion

	}

	// Call this from settings menu script tp update displat fps settings durring menu
	public void Update_DisplayFPS()
    {
		//_________________________________________________
		if (PlayerPrefs.GetInt("Display FPS") == 1)
		{
			if (!gameObject.GetComponent<Display_FPS>())
				gameObject.AddComponent<Display_FPS>();

			gameObject.GetComponent<Display_FPS>().color = fpsColor;
			gameObject.GetComponent<Display_FPS>().fontStyle = fontStyle;
			gameObject.GetComponent<Display_FPS>().alignment = alignment;
		}
		else
		{
			Display_FPS[] dFPS = GameObject.FindObjectsOfType<Display_FPS>();

			for (int a = 0; a < dFPS.Length; a++)
				Destroy(dFPS[a]);
		}
	}

	// Use the below function to enable / disable / toggle menu objects
	public void Enable_Object(GameObject target)
	{
		target.SetActive(true);
	}

	public void Disable_Object(GameObject target)
	{
		target.SetActive(false);
	}

	public void Toggle_Object(GameObject target)
	{
		target.SetActive(!target.activeSelf);
	}
}
