using UnityEngine;
using System.Collections.Generic;
using System;

#if UNITY_EDITOR
using System.Diagnostics;
using UnityEditor;
using System.IO;
#endif

public class Parameters : MonoBehaviour  
{
    // Singleton instance
    public static Parameters Instance { get; private set; }

    public interface IBonusGameSettings
    {
        TornadoSettings TornadoSettings { get; }
        FogSettings FogSettings { get; }
        RainSettings RainSettings { get; }
        // You can add more properties if needed
    }


    public string ParametersVersion = "1.0.0";

    [System.Serializable]
    public class TornadoSettings
    {
        public bool isTornadoActive = true;
        public float tornadoAppearanceTime = 10.0f;
        public int tornadoTravelSpeed = 5;
        public int tornadoRotationSpeed = 5;
        public int tornadoGrowthRate = 1;
    }

    [System.Serializable]
    public class FogSettings
    {
        public bool isFogActive = true;
        public List<float> fogAppearanceTimes = new List<float> { 10.0f };
        public float fogDurationTime = 60.0f;  // time in seconds the fog remains on the scene
    }

    [System.Serializable]
    public class RainSettings
    {
        public bool isRainActive;
        public List<float> rainAppearanceTimes;
        public float rainFallDuration;
        public float riverRiseSpeed;
        public float riverDrainSpeed;  
    }

    [System.Serializable]
    public class CannonSettings
    {
        public float cannonLaunchForce = 500f;
        public float cannonRotationSpeed = 100f;
        public int cannonMaximumRocks = 10;
        public int cannonNumberOfTrajectoryPoints = 30;
    }

    [System.Serializable]
    public class PrizeSettings
    {
        public float lifeTimeOfShatteredPieces = 30f;
        public float fruitFloatSpeed = 2f;
        public int prizeYellowBoxIncrementValue = 5;
        public int prizeChestIncrementValue = 5;
    }

    [System.Serializable]
    public class PlayerAvatarCommsSettings
    {
        public List<string> messagesPerBottle = new List<string> { "Hello", "How are you?" };
        public List<float> messageBottleAppearanceTimes = new List<float> { 10.0f, 20.0f };
    }

    [System.Serializable]
    public class OtherSettings
    {
        public float dinoFlightSpeed = 1.0f;
        public float totalGameDurationInSeconds = 3600;
    }

    [System.Serializable]
    public class WavesBonusGameSettings : IBonusGameSettings
    {
        public TornadoSettings tornadoSettings = new TornadoSettings();
        public FogSettings fogSettings = new FogSettings();
        public RainSettings rainSettings = new RainSettings();
        public CannonSettings cannonSettings = new CannonSettings();
        public PrizeSettings prizeSettings = new PrizeSettings();
        public PlayerAvatarCommsSettings playerAvatarCommsSettings = new PlayerAvatarCommsSettings();
        public OtherSettings otherSettings = new OtherSettings();

        // Implementing the IBonusGameSettings interface properties
        TornadoSettings IBonusGameSettings.TornadoSettings => tornadoSettings;
        FogSettings IBonusGameSettings.FogSettings => fogSettings;
        RainSettings IBonusGameSettings.RainSettings => rainSettings;
    }

    [System.Serializable]
    public class VolcanoBonusGameSettings : IBonusGameSettings
    {
        public TornadoSettings tornadoSettings = new TornadoSettings();
        public FogSettings fogSettings = new FogSettings();
        public RainSettings rainSettings = new RainSettings();
        public CannonSettings cannonSettings = new CannonSettings();
        public PrizeSettings prizeSettings = new PrizeSettings();
        public PlayerAvatarCommsSettings playerAvatarCommsSettings = new PlayerAvatarCommsSettings();
        public OtherSettings otherSettings = new OtherSettings();

        // Implementing the IBonusGameSettings interface properties
        TornadoSettings IBonusGameSettings.TornadoSettings => tornadoSettings;
        FogSettings IBonusGameSettings.FogSettings => fogSettings;
        RainSettings IBonusGameSettings.RainSettings => rainSettings;
    }

    [System.Serializable]
    public class SantoriniBonusGameSettings : IBonusGameSettings
    {
        public TornadoSettings tornadoSettings = new TornadoSettings();
        public FogSettings fogSettings = new FogSettings();
        public RainSettings rainSettings = new RainSettings();
        public CannonSettings cannonSettings = new CannonSettings();
        public PrizeSettings prizeSettings = new PrizeSettings();
        public PlayerAvatarCommsSettings playerAvatarCommsSettings = new PlayerAvatarCommsSettings();
        public OtherSettings otherSettings = new OtherSettings();

        // Implementing the IBonusGameSettings interface properties
        TornadoSettings IBonusGameSettings.TornadoSettings => tornadoSettings;
        FogSettings IBonusGameSettings.FogSettings => fogSettings;
        RainSettings IBonusGameSettings.RainSettings => rainSettings;
    }

    [System.Serializable]
    public class ShellBonusGameSettings : IBonusGameSettings
    {
        public TornadoSettings tornadoSettings = new TornadoSettings();
        public FogSettings fogSettings = new FogSettings();
        public RainSettings rainSettings = new RainSettings();
        public CannonSettings cannonSettings = new CannonSettings();
        public PrizeSettings prizeSettings = new PrizeSettings();
        public PlayerAvatarCommsSettings playerAvatarCommsSettings = new PlayerAvatarCommsSettings();
        public OtherSettings otherSettings = new OtherSettings();

        // Implementing the IBonusGameSettings interface properties
        TornadoSettings IBonusGameSettings.TornadoSettings => tornadoSettings;
        FogSettings IBonusGameSettings.FogSettings => fogSettings;
        RainSettings IBonusGameSettings.RainSettings => rainSettings;
    }

    [System.Serializable]
    public class MiningCaveBonusGameSettings : IBonusGameSettings
    {
        public TornadoSettings tornadoSettings = new TornadoSettings();
        public FogSettings fogSettings = new FogSettings();
        public RainSettings rainSettings = new RainSettings();
        public CannonSettings cannonSettings = new CannonSettings();
        public PrizeSettings prizeSettings = new PrizeSettings();
        public PlayerAvatarCommsSettings playerAvatarCommsSettings = new PlayerAvatarCommsSettings();
        public OtherSettings otherSettings = new OtherSettings();

        // Implementing the IBonusGameSettings interface properties
        TornadoSettings IBonusGameSettings.TornadoSettings => tornadoSettings;
        FogSettings IBonusGameSettings.FogSettings => fogSettings;
        RainSettings IBonusGameSettings.RainSettings => rainSettings;
    }

    [SerializeField]
    private WavesBonusGameSettings wavesBonusGameSettings;
    [SerializeField]
    private VolcanoBonusGameSettings volcanoBonusGameSettings;
    [SerializeField]
    private SantoriniBonusGameSettings santoriniBonusGameSettings;
    [SerializeField]
    private ShellBonusGameSettings shellBonusGameSettings;
    [SerializeField]
    private MiningCaveBonusGameSettings miningCaveBonusGameSettings;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleFogActivity()
    {
        ToggleSettingForAllBonusGames(gameSettings => gameSettings.FogSettings.isFogActive = !gameSettings.FogSettings.isFogActive);
    }

    public void ToggleTornadoActivity()
    {
        ToggleSettingForAllBonusGames(gameSettings => gameSettings.TornadoSettings.isTornadoActive = !gameSettings.TornadoSettings.isTornadoActive);
    }

    public void ToggleRainActivity()
    {
        ToggleSettingForAllBonusGames(gameSettings => gameSettings.RainSettings.isRainActive = !gameSettings.RainSettings.isRainActive);
    }

    private void ToggleSettingForAllBonusGames(Action<IBonusGameSettings> toggleAction)
    {
        toggleAction?.Invoke(wavesBonusGameSettings);
        toggleAction?.Invoke(volcanoBonusGameSettings);
        toggleAction?.Invoke(santoriniBonusGameSettings);
        toggleAction?.Invoke(shellBonusGameSettings);
        toggleAction?.Invoke(miningCaveBonusGameSettings);
    }



    #if UNITY_EDITOR

    [System.Serializable]
    public class AllGameSettings
    {
        public string Version;
        public WavesBonusGameSettings WavesSettings;
        public VolcanoBonusGameSettings VolcanoSettings;
        public SantoriniBonusGameSettings SantoriniSettings;
        public ShellBonusGameSettings ShellSettings;
        public MiningCaveBonusGameSettings MiningCaveSettings;
    }

    [CustomEditor(typeof(Parameters))]
    public class ParametersEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Draw the default inspector
            DrawDefaultInspector();

            Parameters parameters = (Parameters)target;

            // Save button
            if (GUILayout.Button("Save"))
            {
                SaveParameters(parameters);
            }

            // Upload button
            if (GUILayout.Button("Upload"))
            {
                UploadParameters();
            }
        }

        void SaveParameters(Parameters parameters)
        {
            // Create a data object that contains all parameters
            AllGameSettings allSettings = new AllGameSettings
            {
                Version = parameters.ParametersVersion,
                WavesSettings = parameters.wavesBonusGameSettings,
                VolcanoSettings = parameters.volcanoBonusGameSettings,
                SantoriniSettings = parameters.santoriniBonusGameSettings,
                ShellSettings = parameters.shellBonusGameSettings,
                MiningCaveSettings = parameters.miningCaveBonusGameSettings
            };

            // Convert to JSON
            string jsonData = JsonUtility.ToJson(allSettings, true);

            // Get path where the Parameters.cs script is located
            string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(parameters));
            string directoryPath = Path.GetDirectoryName(scriptPath);

            // Save to file in the same directory as the script
            string fullPath = Path.Combine(directoryPath, "params.json");
            File.WriteAllText(fullPath, jsonData);
            UnityEditor.AssetDatabase.Refresh();
        }

        #if UNITY_EDITOR
        void UploadParameters()
        {
            Parameters parameters = (Parameters)target;

            UnityEngine.Debug.Log("Upload button clicked! Implement upload functionality here.");

            // Get the path to the Parameters.cs script
            string scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromMonoBehaviour(parameters));
            string directoryPath = Path.GetDirectoryName(scriptPath);

            // Hardcode the python executable path based on your directory structure
            string pythonExecutable = Path.Combine(directoryPath, "pyenv", "bin", "python3");

            // Use the path to call the Python script
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = pythonExecutable; 
            startInfo.Arguments = Path.Combine(directoryPath, "upload_to_db.py");
            startInfo.RedirectStandardOutput = true;  // Capture standard output
            startInfo.RedirectStandardError = true;   // Capture standard error
            startInfo.UseShellExecute = false;        // Needed to redirect
            startInfo.CreateNoWindow = true;          // Don't create a separate window

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                // Read the output (or the error)
                string result = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                    UnityEngine.Debug.Log(result);
                
                if (!string.IsNullOrEmpty(error))
                    UnityEngine.Debug.LogError(error);

                process.WaitForExit();
            }
        }

        #endif


    }

    #endif
}