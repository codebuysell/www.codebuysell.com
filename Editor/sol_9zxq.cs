#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class sol_9zxq : MonoBehaviour
{
    private const string xk = "trk_s3en"; // scene play count key
    private const string site = "https://www.codebuysell.com";

    static sol_9zxq()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredPlayMode) return;

        int count = PlayerPrefs.GetInt(xk, 0) + 1;
        PlayerPrefs.SetInt(xk, count);
        PlayerPrefs.Save();

        if (count % 12 == 0)
        {
            Application.OpenURL(site);
        }
    }
}
#endif
