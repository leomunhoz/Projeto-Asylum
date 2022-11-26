using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TGResolution : MonoBehaviour
{
    readonly string SCREEN_FULLSCREENMODE = "SCREEN_FULLSCREENMODE";
    readonly string SCREEN_RESOLUTION = "SCREEN_RESOLUTION";
    readonly string SCREEN_VSYNC = "SCREEN_VSYNC";

    readonly string QUALITYSETTINGS_QUALITYLEVEL = "QUALITYSETTINGS_QUALITYLEVEL";
    readonly string QUALITYSETTINGS_SHADOWS = "QUALITYSETTINGS_SHADOWS";
    readonly string QUALITYSETTINGS_SHADOWRESOLUTION = "QUALITYSETTINGS_SHADOWRESOLUTION";
    readonly string QUALITYSETTINGS_SHADOWPROJECTION = "QUALITYSETTINGS_SHADOWPROJECTION";
    readonly string QUALITYSETTINGS_ANISOTROPICFILTERING = "QUALITYSETTINGS_ANISOTROPICFILTERING";
    readonly string QUALITYSETTINGS_MASTERTEXTURELIMIT = "QUALITYSETTINGS_MASTERTEXTURELIMIT";
    readonly string QUALITYSETTINGS_ANTIALIASING = "QUALITYSETTINGS_ANTIALIASING";
    readonly string QUALITYSETTINGS_SHADOWCASCADES = "QUALITYSETTINGS_SHADOWCASCADES";
    readonly string QUALITYSETTINGS_SHADOWDISTANCE = "QUALITYSETTINGS_SHADOWDISTANCE";

    public Text actualFrameRate;
    public GameObject background;

    [Header("Display")]
    public Dropdown fullScreenModeDropDown;
    public Dropdown vSyncDropDown;
    public Dropdown resolutionsDropDown;
    public Dropdown graphicsAPIDropDown;

    [Header("Quality")]
    public GameObject qualityTextLabel;
    public Slider qualitySlider;
    public Transform qualityList;
    public Transform qualityCustomGroup;
    public Transform qualityAutomaticGroup;
    public RectTransform sliderStart;
    public RectTransform sliderEnd;

    public Dropdown shadowsDropDown;
    public Dropdown shadowResolutionDropDown;
    public Dropdown shadowProjectionDropDown;
    public Dropdown shadowCascadesDropDown;

    public Dropdown textureQualityDropDown;
    public Dropdown textureAnsitropicDropDown;
    public Dropdown antialisingDropDown;

    public InputField shadowDistanceInput;

    public Button applyCustomButton;

    float totalTime = 0;
    int counts = 0;

    int maxFrameRate;

    //--------------------------------------------------------------------------
    void Update()
    {
        counts++;
        totalTime += Time.unscaledDeltaTime;

        if (totalTime > 1)
        {
            actualFrameRate.text = (1 / (totalTime / counts)).ToString("N0") + " FPS";
            counts = 0;
            totalTime = 0;
        }
    }

    //--------------------------------------------------------------------------
    public void Show()
    {
        background.SetActive(true);
        Time.timeScale = 0;
    }

    //--------------------------------------------------------------------------
    private void OnEnable()
    {
        background.SetActive(false);
        LoadSettings();
    }

    //--------------------------------------------------------------------------
    private void Start()
    {
        LoadSettings();
    }

    //--------------------------------------------------------------------------
    public void LoadSettings()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(QUALITYSETTINGS_QUALITYLEVEL, QualitySettings.names.Length - 1), true);

        if (ActualQualitySettingsIsAutomatic())
        {
            SelectAutomaticQuality();
        }

        CreateGraphicsAPIDropDown();
        CreateFullScreenModeDropDown();
        CreateResolutionDropDown();
        CreateFrameRateDropDown();
        CreateShadowDropDown();
        CreateTextureDropDown();
        CreateQualitySlider();
        System.GC.Collect();
    }

    //--------------------------------------------------------------------------
    private void CreateGraphicsAPIDropDown()
    {
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>
        {
            new Dropdown.OptionData(SystemInfo.graphicsDeviceType.ToString()),
        };
        graphicsAPIDropDown.options = options;
    }

    //--------------------------------------------------------------------------
    private void CreateTextureDropDown()
    {
        //Debug.Log("CreateTextureDropDown");
        //-- TEXTURE QUALITY -- 
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>
        {
            new Dropdown.OptionData("Full"),
            new Dropdown.OptionData("Half"),
            new Dropdown.OptionData("Quarter"),
            new Dropdown.OptionData("Eighth"),
        };
        textureQualityDropDown.options = options;

        //-- TEXTURE ANSITROPIC -- 
        options = new List<Dropdown.OptionData>();
        AnisotropicFiltering[] anisotropicFiltering = (AnisotropicFiltering[])Enum.GetValues(typeof(AnisotropicFiltering));
        for (int i = 0; i < anisotropicFiltering.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(anisotropicFiltering[i].ToString());
            options.Add(option);
        }
        textureAnsitropicDropDown.options = options;

        //-- ANTIALIASING -- 
        options = new List<Dropdown.OptionData>
        {
            new Dropdown.OptionData("Disabled"),
#if UNITY_STANDALONE
            new Dropdown.OptionData("2x Multi Sampling"),
            new Dropdown.OptionData("4x Multi Sampling"),
            new Dropdown.OptionData("8x Multi Sampling"),
#endif
        };
        antialisingDropDown.options = options;
    }
    //--------------------------------------------------------------------------
    private void CreateShadowDropDown()
    {
        //Debug.Log("CreateShadowDropDown");
        //-- SHADOW -- 
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        ShadowQuality[] shadowQuality = (ShadowQuality[])Enum.GetValues(typeof(ShadowQuality));
        for (int i = 0; i < shadowQuality.Length; i++)
        {
            options.Add(new Dropdown.OptionData(shadowQuality[i].ToString()));
        }
        shadowsDropDown.options = options;

        //-- SHADOW RESOLUTION -- 
        options = new List<Dropdown.OptionData>();
        ShadowResolution[] shadowResolutions = (ShadowResolution[])Enum.GetValues(typeof(ShadowResolution));
        for (int i = 0; i < shadowResolutions.Length; i++)
        {
            options.Add(new Dropdown.OptionData(shadowResolutions[i].ToString()));
        }
        shadowResolutionDropDown.options = options;

        //-- SHADOW PROJECTION -- 
        options = new List<Dropdown.OptionData>();
        ShadowProjection[] shadowProjection = (ShadowProjection[])Enum.GetValues(typeof(ShadowProjection));
        for (int i = 0; i < shadowProjection.Length; i++)
        {
            options.Add(new Dropdown.OptionData(shadowProjection[i].ToString()));
        }
        shadowProjectionDropDown.options = options;

        //-- SHADOW CASCADES -- 
        options = new List<Dropdown.OptionData>
        {
            new Dropdown.OptionData("No Cascades"),
            new Dropdown.OptionData("Two Cascades"),
            new Dropdown.OptionData("Four Cascades")
        };
        shadowCascadesDropDown.options = options;
    }

    //--------------------------------------------------------------------------
    void EnableCustomSetting(bool enable, bool hideAll)
    {
        //Debug.Log("EnableCustomSetting: " + enable);
        qualityCustomGroup.gameObject.SetActive(!hideAll);
        qualityAutomaticGroup.gameObject.SetActive(hideAll);

        shadowsDropDown.interactable = enable;
        shadowResolutionDropDown.interactable = enable;
        shadowProjectionDropDown.interactable = enable;
        shadowDistanceInput.interactable = enable;
        shadowCascadesDropDown.interactable = enable;

        textureQualityDropDown.interactable = enable;
        textureAnsitropicDropDown.interactable = enable;
        antialisingDropDown.interactable = enable;
    }
    //--------------------------------------------------------------------------
    private void CreateQualitySlider()
    {
        //Debug.Log("CreateQualitySlider");
        for (int i = qualityList.childCount - 1; i > -1; i--)
        {
            Destroy(qualityList.GetChild(i).gameObject);
        }
        int namesCount = QualitySettings.names.Length - 1;
        if (namesCount == 0) return;
        qualitySlider.maxValue = namesCount;        
        float sliderWidth = sliderEnd.position.x - sliderStart.position.x;
        float step = sliderWidth / (QualitySettings.names.Length - 1) / transform.parent.localScale.x;

        for (int i = 0; i < QualitySettings.names.Length; i++)
        {
            GameObject qualityObj = Instantiate(qualityTextLabel);
            qualityObj.SetActive(true);
            qualityObj.name = QualitySettings.names[i];
            qualityObj.transform.SetParent(qualityList, false);
            Text qualityText = qualityObj.GetComponent<Text>();
            qualityText.text = qualityObj.name;
            if (i == 0)
            {
                qualityText.alignment = TextAnchor.MiddleLeft;
            }
            else if (i == QualitySettings.names.Length - 1)
            {
                qualityText.alignment = TextAnchor.MiddleRight;
            }

            RectTransform rect = qualityObj.GetComponent<RectTransform>();

            rect.localPosition = new Vector3(i * step, 0, 0);
        }

        qualitySlider.value = QualitySettings.GetQualityLevel();
    }

    //--------------------------------------------------------------------------
    public void OnQualitySliderChange(float sliderPosition)
    {
        int position = (int)sliderPosition;

        QualitySettings.SetQualityLevel(position, false);

        EnableCustomSetting(ActualQualitySettingsIsCustom(), ActualQualitySettingsIsAutomatic());
        UpdateCustomComponents();

        PlayerPrefs.SetInt(QUALITYSETTINGS_QUALITYLEVEL, position);
        PlayerPrefs.Save();
    }

    //--------------------------------------------------------------------------
    private void UpdateCustomComponents()
    {
        //Debug.Log("UpdateCustomComponents");
        if (ActualQualitySettingsIsCustom())
        {
            shadowsDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_SHADOWS, 2);
            shadowResolutionDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_SHADOWRESOLUTION, 2);
            shadowProjectionDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_SHADOWPROJECTION, 1);
            textureAnsitropicDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_ANISOTROPICFILTERING, 4);
            textureQualityDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_MASTERTEXTURELIMIT, 0);
            antialisingDropDown.value = PlayerPrefs.GetInt(QUALITYSETTINGS_ANTIALIASING, 4);
            shadowCascadesDropDown.value = (int)Math.Pow(PlayerPrefs.GetInt(QUALITYSETTINGS_SHADOWCASCADES, 4), 2);
            shadowDistanceInput.text = PlayerPrefs.GetInt(QUALITYSETTINGS_SHADOWDISTANCE, 4000).ToString("N0");
            OnSavePressed();
        }
        else
        {
            UpdateDropDown(shadowsDropDown, QualitySettings.shadows.ToString());
            UpdateDropDown(shadowResolutionDropDown, QualitySettings.shadowResolution.ToString());
            UpdateDropDown(shadowProjectionDropDown, QualitySettings.shadowProjection.ToString());
            UpdateDropDown(textureAnsitropicDropDown, QualitySettings.anisotropicFiltering.ToString());
            textureQualityDropDown.value = QualitySettings.masterTextureLimit;
            antialisingDropDown.value = (int)Mathf.Log(QualitySettings.antiAliasing, 2);
            shadowCascadesDropDown.value = (int)Mathf.Log(QualitySettings.shadowCascades, 2);
            shadowDistanceInput.text = QualitySettings.shadowDistance.ToString("N0");
        }
    }

    //--------------------------------------------------------------------------
    void UpdateDropDown(Dropdown dropdown, string newValue)
    {
        //Debug.Log("UpdateDropDown: " + dropdown.name);
        for (int i = 0; i < dropdown.options.Count; i++)
        {
            if (dropdown.options[i].text.Equals(newValue))
            {
                dropdown.value = i;
                break;
            }
        }
    }

    //--------------------------------------------------------------------------
    void CreateFrameRateDropDown()
    {
        //Debug.Log("CreateFrameRateDropDown");
        //-- FRAME RATE -- 
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        for (int i = 0; i <= 4; i++)
        {
            string vSyncText = "Unlimited";
            if (i > 0)
            {
                vSyncText = (maxFrameRate / i).ToString() + " FPS";
            }
            Dropdown.OptionData option = new Dropdown.OptionData(vSyncText);
            options.Add(option);
        }
        vSyncDropDown.options = options;

        vSyncDropDown.value = PlayerPrefs.GetInt(SCREEN_VSYNC, 1);
        OnFrameRateSelected(PlayerPrefs.GetInt(SCREEN_VSYNC, 1));
    }

    //--------------------------------------------------------------------------
    public void OnFrameRateSelected(int res)
    {
        QualitySettings.vSyncCount = res;
        Application.targetFrameRate = res == 0 ? -1 : maxFrameRate;
        PlayerPrefs.SetInt(SCREEN_VSYNC, res);
        PlayerPrefs.Save();
        //Debug.Log("OnFrameRateSelected: " + Application.targetFrameRate);
    }

    //--------------------------------------------------------------------------
    void CreateResolutionDropDown()
    {
        //Debug.Log("CreateResolutionDropDown");
        //-- RESOLUTIONS -- 
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();

        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(Screen.resolutions[i].ToString());
            if (Screen.resolutions[i].refreshRate > maxFrameRate)
            {
                maxFrameRate = Screen.resolutions[i].refreshRate;
            }
            options.Add(option);
        }

        resolutionsDropDown.options = options;

        int lastResolution = PlayerPrefs.GetInt(SCREEN_RESOLUTION, -1);
        if (lastResolution > -1)
        {
            resolutionsDropDown.value = lastResolution;
        }
        else
        {
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                if (Screen.resolutions[i].width.Equals(Screen.currentResolution.width) &&
                    Screen.resolutions[i].height.Equals(Screen.currentResolution.height) &&
                    Screen.resolutions[i].refreshRate.Equals(Screen.currentResolution.refreshRate))
                {
                    resolutionsDropDown.value = i;
                    break;
                }
            }
        }
    }

    //--------------------------------------------------------------------------
    public void OnResolutionSelected(int res)
    {
        //Debug.Log("OnResolutionSelected: " + res);
        bool fullScreen = Screen.fullScreenMode.ToString().ToLower().Contains("full");
        Screen.SetResolution(Screen.resolutions[res].width, Screen.resolutions[res].height, fullScreen, Screen.resolutions[res].refreshRate);
        //Application.targetFrameRate = Screen.resolutions[res].refreshRate;
        //OnFrameRateSelected(Screen.resolutions[res].refreshRate);
        //vSyncDropDown.value = 1;
        PlayerPrefs.SetInt(SCREEN_RESOLUTION, res);
        PlayerPrefs.Save();
        Invoke("CreateQualitySlider", 0.1f);
    }

    //--------------------------------------------------------------------------
    private void CreateFullScreenModeDropDown()
    {
        //Debug.Log("CreateFullScreenModeDropDown");
        //-- FULL SCREEN MODE -- 
        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        FullScreenMode[] screenModes = (FullScreenMode[])Enum.GetValues(typeof(FullScreenMode));
        for (int i = 0; i < screenModes.Length; i++)
        {
            Dropdown.OptionData option = new Dropdown.OptionData(screenModes[i].ToString());
            options.Add(option);
        }
        fullScreenModeDropDown.options = options;

        int lastScreenMode = PlayerPrefs.GetInt(SCREEN_FULLSCREENMODE, -1);
        if (lastScreenMode > -1)
        {
            fullScreenModeDropDown.value = lastScreenMode;
        }
        else
        {
            for (int i = 0; i < screenModes.Length; i++)
            {
                if (screenModes[i] == Screen.fullScreenMode)
                {
                    fullScreenModeDropDown.value = i;
                    break;
                }
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------
    public void MaximizeSwitch()
    {
        OnFullScreenModeSelected((int)(Screen.fullScreen ? FullScreenMode.Windowed : FullScreenMode.ExclusiveFullScreen));
    }

    //--------------------------------------------------------------------------
    public void OnFullScreenModeSelected(int res)
    {
        //Debug.Log("OnFullScreenModeSelected: " + res);
        Screen.fullScreenMode = (FullScreenMode)res;
        try
        {
            PlayerPrefs.SetInt(SCREEN_FULLSCREENMODE, res);
        } catch(Exception e)
        {
            Debug.LogError("OnFullScreenModeSelected: " + e.Message);
        } 
        PlayerPrefs.Save();
    }

    //--------------------------------------------------------------------------
    public void OnClosePressed()
    {
        Time.timeScale = 1;
        background.SetActive(false);
    }

    //--------------------------------------------------------------------------
    public void OnSavePressed()
    {
        //Debug.Log("OnSavePressed");
        try
        {
            int.TryParse(shadowDistanceInput.text, out int shadowDistance);
            shadowDistance = Mathf.Abs(shadowDistance);

            QualitySettings.shadows = (ShadowQuality)shadowsDropDown.value;
            QualitySettings.shadowResolution = (ShadowResolution)shadowResolutionDropDown.value;
            QualitySettings.shadowProjection = (ShadowProjection)shadowProjectionDropDown.value;
            QualitySettings.anisotropicFiltering = (AnisotropicFiltering)textureAnsitropicDropDown.value;
            QualitySettings.masterTextureLimit = textureQualityDropDown.value;
            QualitySettings.antiAliasing = (int)Mathf.Pow(antialisingDropDown.value, 2);
            QualitySettings.shadowCascades = (int)Mathf.Pow(shadowCascadesDropDown.value, 2);
            QualitySettings.shadowDistance = shadowDistance;

            PlayerPrefs.SetInt(QUALITYSETTINGS_SHADOWS, (int)shadowsDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_SHADOWRESOLUTION, (int)shadowResolutionDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_SHADOWPROJECTION, (int)shadowProjectionDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_ANISOTROPICFILTERING, (int)textureAnsitropicDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_MASTERTEXTURELIMIT, (int)textureQualityDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_ANTIALIASING, (int)antialisingDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_SHADOWCASCADES, (int)shadowCascadesDropDown.value);
            PlayerPrefs.SetInt(QUALITYSETTINGS_SHADOWDISTANCE, shadowDistance);
        }
        catch (Exception e)
        {
            Debug.LogError("OnSavePressed: " + e.Message);
        }


        PlayerPrefs.Save();
        applyCustomButton.interactable = false;
    }

    //--------------------------------------------------------------------------
    public void OnCustomChanged()
    {
        applyCustomButton.interactable = ActualQualitySettingsIsCustom();
    }

    //--------------------------------------------------------------------------
    bool ActualQualitySettingsIsCustom()
    {
        return QualitySettings.GetQualityLevel() == QualitySettings.names.Length - 2;
    }

    //--------------------------------------------------------------------------
    bool ActualQualitySettingsIsAutomatic()
    {
        return QualitySettings.GetQualityLevel() == QualitySettings.names.Length - 1;
    }

    //--------------------------------------------------------------------------
    public void SelectAutomaticQuality()
    {
        int overallQuality = 0;
        //        VRAM/Processador
        //              1  2  3  4+   
        //        256   1  2  3  4   
        //        512   2  3  4  5   
        //        1024  3  4  5  6   
        //
        //        Quality (CPU/Processador)/Width*Height  
        //                480x320  640x480  960x640  1280x720  1920x1080+
        //        1       1        1        1        1         1
        //        2       1        1        1        1         2
        //        3       1        1        1        2         3
        //        4       1        1        2        3         4
        //        5       1        2        3        4         5
        //        6       2        3        4        5         6

        int vram = SystemInfo.systemMemorySize - SystemInfo.graphicsMemorySize;
        int cpus = Mathf.Clamp(SystemInfo.processorCount, 1, 4);

        if (vram >= 1024)
        {
            overallQuality = cpus + 2;
        }
        else if (vram >= 512)
        {
            overallQuality = cpus + 1;
        }
        else
        {
            overallQuality = cpus;
        }

        float screenPixelCount = Screen.width * Screen.height;
        if (screenPixelCount >= (1920 * 1080))
        {
            overallQuality = overallQuality * 1;
        }
        else if (screenPixelCount >= (1280 * 720))
        {
            overallQuality -= 1;
        }
        else if (screenPixelCount >= (960 * 640))
        {
            overallQuality -= 2;
        }
        else if (screenPixelCount >= (640 * 480))
        {
            overallQuality -= 3;
        }
        else
        {
            overallQuality -= 4;
        }

#if UNITY_IOS
        overallQuality += 1;
#endif

        //sao 6 niveis de quality que devem ser setado de 0 a 5
        overallQuality = Mathf.Clamp(overallQuality - 1, 0, 5);
        qualitySlider.value = overallQuality;
    }
}