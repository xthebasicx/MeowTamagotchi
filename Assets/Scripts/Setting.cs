using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Toggle fullscreenToggle;
    HashSet<string> uniqueResolutions = new HashSet<string>();
    void Start()
    {
        ResolutionDropdown();
        fullscreenToggle.isOn = Screen.fullScreen;
    }
    public void SetFullscreen(bool isFullscreen)
    {
         if (isFullscreen){
            resolutionDropdown.value = resolutions.Length;
            resolutionDropdown.RefreshShownValue();
            Screen.fullScreen = isFullscreen;
         }
         Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        List<Resolution> filteredResolution = new List<Resolution>(uniqueResolutions.Count);
        foreach (string resolutionStr in uniqueResolutions)
        {
            Resolution res = ResolutionFromString(resolutionStr);
            filteredResolution.Add(res);
        }

        Resolution selectedResolution = filteredResolution[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
    public void ResolutionDropdown()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        uniqueResolutions.Clear();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionStr = $"{resolutions[i].width} x {resolutions[i].height}";
            uniqueResolutions.Add(resolutionStr);
        }

        List<string> options = new List<string>(uniqueResolutions);

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = 0;
        resolutionDropdown.RefreshShownValue();
    }
    private Resolution ResolutionFromString(string resolutionStr)
    {
        string[] parts = resolutionStr.Split('x');
        int width = int.Parse(parts[0]);
        int height = int.Parse(parts[1]);
        return new Resolution { width = width, height = height };
    }



}
