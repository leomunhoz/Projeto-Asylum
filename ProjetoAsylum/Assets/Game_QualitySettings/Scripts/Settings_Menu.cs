// Game Quality Settings
// AliyerEdon in Winter 2022
//				
//

// This script used for game settings menu
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings_Menu : MonoBehaviour
{

	#region Variables

	[Space(7)]
	[Header("FPS Display")]
	public Color fpsColor = Color.yellow;
	public TextAnchor alignment = TextAnchor.UpperRight;
	public FontStyle fontStyle = FontStyle.Bold;

	[Space(7)]
	[Header("Effects Toggles")]
	public Toggle displayFPS;
	public Toggle bloomEffect;
	public Toggle postEffects;
	public Toggle fogEffect;
	public Toggle dynamicResolution;
	public Toggle temporalAntiAliasing;
	public Toggle vSync;
	public Toggle HDR;

	[Space(7)]
	[Header("Dropdown")]
	public Dropdown qualityLevel;
	public Dropdown resolutionQuality;
	public Dropdown TextureQuality;
	public Dropdown antiAliasing;
	public Dropdown ShadowQuality;

	[Space(7)]
	[Header("Effects Volume")]
	public UnityEngine.Rendering.PostProcessing.PostProcessVolume globalVolume;
	#endregion

	void Start()
	{
		#region Load Settings
		// Read starting setting values
		// 		
		if (PlayerPrefs.GetInt("Display FPS") == 1) // 1 = true , 0 = false
			displayFPS.isOn = true;
		else
			displayFPS.isOn = false;
		
		//_________________________________________________
		if (PlayerPrefs.GetInt("vSync") == 1) // 1 = true , 0 = false
			vSync.isOn = true;
		else
			vSync.isOn = false;
		//_________________________________________________
		
		//_________________________________________________

		qualityLevel.value = PlayerPrefs.GetInt("Quality Level");

		resolutionQuality.value = PlayerPrefs.GetInt("Resolution Quality");

		antiAliasing.value = PlayerPrefs.GetInt("Anti Aliasing");

		TextureQuality.value = PlayerPrefs.GetInt("Quality Lvel");
		//_________________________________________________

		#endregion
	}

	#region Quality Level
	// Public functions to use on UI.Button's OnClick() event
	public void Set_Quality_Level()
	{
		PlayerPrefs.SetInt("Quality Level", qualityLevel.value);

		QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality Level"), false);
	}
	//_________________________________________________
	#endregion

	#region Resolution Quality
	public void Set_Resolution_Quality()
	{
		if (resolutionQuality.value == 0)
		{
			Screen.SetResolution((int)(PlayerPrefs.GetInt("OriginalX") * 1),
				(int)(PlayerPrefs.GetInt("OriginalY") * 1), true);
		}
		if (resolutionQuality.value == 1)
		{
			Screen.SetResolution((int)(PlayerPrefs.GetInt("OriginalX") * 0.7f),
				(int)(PlayerPrefs.GetInt("OriginalY") * 0.7f), true);
		}
		if (resolutionQuality.value == 2)
		{
			Screen.SetResolution((int)(PlayerPrefs.GetInt("OriginalX") * 0.5f),
				(int)(PlayerPrefs.GetInt("OriginalY") * 0.5f), true);
		}

		PlayerPrefs.SetInt("Resolution Quality", resolutionQuality.value);
	}
    //______________________________________________
    #endregion

    #region TextureQuality

	public void Set_Texture_Quality() 
	{
		

        if (TextureQuality.value == 0)
        {
			QualitySettings.masterTextureLimit = 0;
        }
        else if (TextureQuality.value == 1)
        {
			QualitySettings.masterTextureLimit = 1;
        }
        else if (TextureQuality.value == 2)
        {
			QualitySettings.masterTextureLimit = 2;
        }
        else
        {
			QualitySettings.masterTextureLimit = 3;
        }

		PlayerPrefs.SetInt("Texture Quality", TextureQuality.value);
		
	}

    #region ShadowQuality

	


    #region Anti-Aliasing
    public void Set_Anti_Aliasing()
	{
		PlayerPrefs.SetInt("Anti Aliasing", antiAliasing.value);

		if (PlayerPrefs.GetInt("Anti Aliasing") == 0)
			QualitySettings.antiAliasing = 0;
		if (PlayerPrefs.GetInt("Anti Aliasing") == 1)
			QualitySettings.antiAliasing = 2;
		if (PlayerPrefs.GetInt("Anti Aliasing") == 2)
			QualitySettings.antiAliasing = 4;
		if (PlayerPrefs.GetInt("Anti Aliasing") == 3)
			QualitySettings.antiAliasing = 8;
	}
	//______________________________________________
	#endregion

	#region Display FPS
	public void Set_Display_FPS()
	{
		StartCoroutine(Display_FPS());
	}

	IEnumerator Display_FPS()
	{
		yield return new WaitForEndOfFrame();
		if (displayFPS.isOn)
			PlayerPrefs.SetInt("Display FPS", 1);  // 1 = true;
		else
			PlayerPrefs.SetInt("Display FPS", 0);// 0 = false;

		if (GameObject.FindObjectOfType<Load_Settings>())
			GameObject.FindObjectOfType<Load_Settings>().Update_DisplayFPS();

	}
	
	


	
	

	

	

	#region V-Sync
	public void Set_vSync()
	{
		StartCoroutine(v_Sync());
	}

	IEnumerator v_Sync()
	{
		yield return new WaitForEndOfFrame();
		if (vSync.isOn)
			PlayerPrefs.SetInt("vSync", 1);  // 1 = true;
		else
			PlayerPrefs.SetInt("vSync", 0);// 0 = false;

		if (PlayerPrefs.GetInt("vSync") == 0)
			QualitySettings.vSyncCount = 0;
		else
			QualitySettings.vSyncCount = 1;
	}
	//______________________________________________
	#endregion


	//______________________________________________
	

	#region Close Window
	public void Disable_Object(GameObject target)
    {
		target.SetActive(false);

	}
	#endregion

	#region OpenWindow

	public void Enable_Object(GameObject target) 
	{
		target.SetActive(true);
	
	
	}

}
#endregion
#endregion
#endregion

