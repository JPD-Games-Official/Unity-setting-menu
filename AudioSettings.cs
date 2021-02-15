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
 * Set the volumes of sounds and music
 * ##################################################
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private void Start()
    {
        loadSettingsData();
    }

    #region SaveLoadSystem
    public void saveSettingsData()
    {
        //save toggle
        PlayerPrefs.SetString("save_toggle_sound", soundToggle.isOn.ToString());
        PlayerPrefs.SetString("save_toggle_music", musicToggle.isOn.ToString());

        //save slider value
        PlayerPrefs.SetFloat("save_volume_sound", soundVolume.value);
        PlayerPrefs.SetFloat("save_volume_music", musicVolume.value);
    }

    public void loadSettingsData()
    {
        try
        {
            //load toggle
            soundToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_sound"));
            musicToggle.isOn = bool.Parse(PlayerPrefs.GetString("save_toggle_music"));
        }
        catch { }

        //load slider value
        soundVolume.value = PlayerPrefs.GetFloat("save_volume_sound");
        musicVolume.value = PlayerPrefs.GetFloat("save_volume_music");

        //Update settings
        soundBlockOnOff();
        musicBlockOnOff();
        soundSlider();
        musicSlider();
    }

    #endregion SaveLoadSystem
    #region Sounds
    public GameObject[] soundPlayer;
    public GameObject soundBlock;
    public Toggle soundToggle;

    public Slider soundVolume;
    public Text percentText;

    //enable or disable the sounds
    public void soundBlockOnOff()
    {
        //if the toggle is on
        if(soundToggle.isOn)
        {
            //turn on the gameobjects
            soundBlock.SetActive(true);

            for (int i = 0; i < soundPlayer.Length; i++)
            {
                soundPlayer[i].SetActive(true);
            }
        }
        else
        {
            //turn off the gameobjects
            soundBlock.SetActive(false);

            for (int i = 0; i < soundPlayer.Length; i++)
            {
                soundPlayer[i].SetActive(false);
            }
        }
    }

    //change the volumes of sounds
    public void soundSlider()
    {
        //change the volumes of all audiosources in array
        for(int i = 0; i < soundPlayer.Length; i++)
        {
            soundPlayer[i].GetComponent<AudioSource>().volume = soundVolume.value;
        }

        percentText.text = Mathf.Round(soundVolume.value * 100) + "%";
    }

    #endregion Sounds
    #region Music
    public GameObject musicPlayer;
    public GameObject musicBlock;
    public Toggle musicToggle;

    public Slider musicVolume;
    public Text percentTextMusic;

    public void musicBlockOnOff()
    {
        if (musicToggle.isOn)
        {
            musicBlock.SetActive(true);
            musicPlayer.SetActive(true);
        }
        else
        {
            musicBlock.SetActive(false);
            musicPlayer.SetActive(false);
        }
    }

    public void musicSlider()
    {
        musicPlayer.GetComponent<AudioSource>().volume = musicVolume.value;
        percentTextMusic.text = Mathf.Round(musicVolume.value * 100) + "%";
    }

    #endregion Music
}
