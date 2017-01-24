using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class SettingManager : MonoBehaviour {
    public Toggle tam_ekran_toggle;
    public Dropdown cozunurluk_dropdown;
    public Dropdown doku_kalitesi_dropdown;
    public Dropdown kenar_yumusatma_dropdown;
    public Dropdown vSync_dropdown;
    public Slider ses_slider;
    public Button onay_button;

    public AudioSource ses_kaynagi;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();
        tam_ekran_toggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        cozunurluk_dropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        doku_kalitesi_dropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        kenar_yumusatma_dropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSync_dropdown.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        ses_slider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        onay_button.onClick.AddListener(delegate { OnApplyButtonClick(); });
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            cozunurluk_dropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullScreenToggle()
    {
        gameSettings.tam_ekran = Screen.fullScreen = tam_ekran_toggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[cozunurluk_dropdown.value].width, resolutions[cozunurluk_dropdown.value].height, Screen.fullScreen);
        gameSettings.cozunurluk = cozunurluk_dropdown.value;
    }

    public void OnTextureQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.doku_kalitesi = doku_kalitesi_dropdown.value;
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.kenar_yumusatma = (int)Mathf.Pow(2f, kenar_yumusatma_dropdown.value);
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSync_dropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        ses_kaynagi.volume = gameSettings.ses = ses_slider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        ses_slider.value = gameSettings.ses;
        kenar_yumusatma_dropdown.value = gameSettings.kenar_yumusatma;
        vSync_dropdown.value = gameSettings.vSync;
        doku_kalitesi_dropdown.value = gameSettings.doku_kalitesi;
        cozunurluk_dropdown.value = gameSettings.cozunurluk;
        tam_ekran_toggle.isOn = gameSettings.tam_ekran;
        Screen.fullScreen = gameSettings.tam_ekran;

        cozunurluk_dropdown.RefreshShownValue();
    }
}
