/* +++++++++++
 * Open source
 * +++++++++++
 * 
 * Developed by: JPD-Games
 * Author: Jan-Philip Duering
 * API: Unity
 * 
 * Version: 21211 DevBuild
 * 
 * Description
 * ##################################################
 * set graphic settings:
 * - fullscreen
 * - vsync
 * - antialiasing
 * - fps display
 * - resolution
 * - texture quality
 * ##################################################
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class GraphicSettings : MonoBehaviour
{
    private void Start()
    {
        detectResolution();
        loadSettingsData();
    }

    #region SaveLoadSystem
    public void saveSettingsData()
    {
        //save toggle
        PlayerPrefs.SetString("save_toggle_fullscreen", fullscreenToggle.isOn.ToString());
        PlayerPrefs.SetString("save_toggle_antialiasing", antialiasingToggle.isOn.ToString());
        PlayerPrefs.SetString("save_toggle_vsync", vsyncToggle.isOn.ToString());
        PlayerPrefs.SetString("save_toggle_showFps", showFpsToggle.isOn.ToString());

        //save value
        PlayerPrefs.SetInt("save_value_resolution", resDropDown.value);
        PlayerPrefs.SetInt("save_value_textureQuality", textureQualityDropDown.value);
    }

    public void loadSettingsData()
    {
        try
        {
            //load toggle
            fullscreenToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_fullscreen"));
            antialiasingToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_antialiasing"));
            vsyncToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_vsync"));
            showFpsToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_showFps"));
        }
        catch { }

        //load value
        resDropDown.value = PlayerPrefs.GetInt("save_value_resolution");
        textureQualityDropDown.value = PlayerPrefs.GetInt("save_value_textureQuality");

        //Update settings
        fullscreenOnOff();
        antialiasingOnOff();
        vsyncOnOff();
        showFpsOnOff();
        resDropDownControl();
        textureQualityDropDownControl();
    }
    #endregion SaveLoadSystem
    #region Toggle
    //enable/disable fullscreenmode
    public Toggle fullscreenToggle;
    bool isFullscreen = true;

    public void fullscreenOnOff()
    {
        if (fullscreenToggle.isOn)
        {
            isFullscreen = true;
            detectResolution();
        }
        else
        {
            isFullscreen = false;
            detectResolution();
        }
    }

    //enable/disable antialiasing
    public Toggle antialiasingToggle;

    public void antialiasingOnOff()
    {
        if (antialiasingToggle.isOn)
        {
            QualitySettings.antiAliasing = 8;
        }
        else
        {
            QualitySettings.antiAliasing = 0;
        }
    }

    //enable/disable vsync
    public Toggle vsyncToggle;

    public void vsyncOnOff()
    {
        if (vsyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 2;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    //enable/disable fps display
    public Toggle showFpsToggle;
    public GameObject fpsDisplay;

    public void showFpsOnOff()
    {
        if (showFpsToggle.isOn)
        {
            if (fpsDisplay) //Only if an object has been assigned
            {
                fpsDisplay.SetActive(true);
            }
        }
        else
        {
            if (fpsDisplay)
            {
                fpsDisplay.SetActive(false);
            }
        }
    }

    #endregion Toggle
    #region Resolution
    public Dropdown resDropDown;

    public void resDropDownControl()
    {
        //set the resolution with the value of the drop down field
        //isFullscreen is taken from the toggle
        switch(resDropDown.value)
        {
            case 0:detectResolution(); break;
            case 1:Screen.SetResolution(800, 600, isFullscreen); break;
            case 2:Screen.SetResolution(1366, 768, isFullscreen); break;
            case 3:Screen.SetResolution(1600, 900, isFullscreen); break;
            case 4:Screen.SetResolution(1920, 1080, isFullscreen); break;
            case 5:Screen.SetResolution(1920, 1200, isFullscreen); break;
            case 6:Screen.SetResolution(2560, 1440, isFullscreen); break;
            case 7:Screen.SetResolution(2560, 1600, isFullscreen); break;
            case 8:Screen.SetResolution(3840, 2160, isFullscreen); break;
            default:detectResolution(); break;
        }
    }

    //detect your current main screen resolution and use it to set the resolution with it
    public void detectResolution()
    {
        Resolution resolution = Screen.currentResolution;
        Screen.SetResolution(resolution.width, resolution.height, isFullscreen);
    }

    #endregion Resolution
    #region TextureQuality
    //set the texture quality with the value of the drop down field
    public Dropdown textureQualityDropDown;
    public void textureQualityDropDownControl()
    {
        switch(textureQualityDropDown.value)
        {
            default: QualitySettings.masterTextureLimit = 1; break;
            case 0: QualitySettings.masterTextureLimit = 3; break;
            case 1: QualitySettings.masterTextureLimit = 2; break;
            case 2: QualitySettings.masterTextureLimit = 1; break;
            case 3: QualitySettings.masterTextureLimit = 0; break;
        }
    }

    #endregion TextureQuality
}
