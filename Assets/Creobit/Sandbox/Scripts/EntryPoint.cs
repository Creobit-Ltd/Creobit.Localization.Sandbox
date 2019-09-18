using UnityEngine;
using Creobit.Localization;

public class EntryPoint : MonoBehaviour
{
    #region MonoBehaviour

    private void Awake()
    {
        Debug.Assert(_localizationData != null);

        var key = "text";

        var value = _localizationData.GetString(key, English);
        Debug.LogFormat("English: {0}", value);

        value = _localizationData.GetString(key, Russian);
        Debug.LogFormat("Russian: {0}", value);

        value = _localizationData.GetString(key, German);
        Debug.LogFormat("German: {0}", value);

        _localizationSystem = new LocalizationSystem(_localizationData)
        {
            DefaultLanguage = English
        };

        Localizer.LocalizationSystem = _localizationSystem;

        _localizationSystem.CurrentLanguage = English;
    }

    #endregion
    #region EntryPoint

    private readonly string Russian = "ru-RU";
    private readonly string English = "en-US";
    private readonly string German = "de-DE";

    [SerializeField]
    private LocalizationData _localizationData = null;

    [SerializeField]
    private AudioSource _audioSource = null;

    private ILocalizationSystem _localizationSystem;

    public void OnButtonClick()
    {
        var language = _localizationSystem.CurrentLanguage;

        if (language == Russian)
            language = English;
        else if (language == English)
            language = German;
        else if (language == German)
            language = Russian;

        _localizationSystem.CurrentLanguage = language;

        _audioSource?.Play();
    }

    #endregion
}
