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
 * use GUI elemets to open or close tabs and the
 * settings UI.
 * ##################################################
 * 
 */
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    //start with the audio tab
    private void Start()
    {
        openTabAudio();
    }

    //open and close the settings panel
    #region OpenAndCloseSettings
    public GameObject settingsPanel;

    public void openSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettings()
    {
        settingsPanel.SetActive(false);

        //reset the form position, when it's closed
        if (resetWindowOnClose)
        {
            resetFormPosition();
        }
    }
    #endregion openAndCloseSettings

    //open and close the single tabs
    #region OpenTabs
    public Text title;
    public GameObject tabAudio;
    public GameObject tabGraphics;

    public void openTabAudio()
    {
        tabAudio.SetActive(true);
        tabGraphics.SetActive(false);

        //set the title of form to Audio
        title.text = "Audio";
    }

    public void openTabGraphics()
    {
        tabGraphics.SetActive(true);
        tabAudio.SetActive(false);

        title.text = "Graphics";
    }
    #endregion OpenTabs

    //makes form movement possible
    #region MoveableForm
    public bool moveableForm;
    public bool resetWindowOnClose;
    public GameObject titleBox;
    bool isDraged = false;

    public void dragForm()
    {
        if(moveableForm)
        {
            isDraged = true;
        }
    }

    public void dropForm()
    {
        if (moveableForm)
        {
            isDraged = false; 
        }
    }

    public void resetFormPosition()
    {
        titleBox.transform.localPosition = new Vector2(0,100);
    }

    private void Update()
    {
        if(isDraged)
        {
            //get the vector position of mouse
            Vector3 mousePos = Input.mousePosition;

            //locates the mouse position on the screen
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            //set position of titleBox to cursor position
            titleBox.transform.localPosition = new Vector2(mousePos.x * 45, mousePos.y * 45);
        }
    }

    #endregion MoveableForm
}
