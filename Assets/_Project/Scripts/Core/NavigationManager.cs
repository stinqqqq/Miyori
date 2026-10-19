using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager Instance { get; private set; }

    private void Awake()
    {
        // Pola Singleton seperti GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Memanggil proses pemuatan scene secara asinkron (di latar belakang).
    /// </summary>
    public void LoadTargetScene(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        Debug.Log($"[Navigation] Mulai memuat scene: {sceneName}");
        
        // Memulai pemuatan di latar belakang
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        // Tahan scene agar tidak otomatis pindah sebelum pemuatan benar-benar selesai
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Nilai progress asinkron Unity maksimal berhenti di 0.9
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log($"[Navigation] Progress: {progress * 100}%");

            // Jika progress sudah mencapai 0.9 (artinya memuat data selesai)
            if (operation.progress >= 0.9f)
            {
                // Izinkan Unity untuk mengaktifkan scene dan berpindah layar
                operation.allowSceneActivation = true;
            }

            yield return null; // Tunggu ke frame berikutnya
        }
        
        Debug.Log($"[Navigation] Berhasil pindah ke scene: {sceneName}");
    }
}