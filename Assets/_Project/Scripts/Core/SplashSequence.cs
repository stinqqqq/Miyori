using System.Collections;
using UnityEngine;

public class SplashSequence : MonoBehaviour
{
    [SerializeField] private float waitTime = 2f; // Lama menunggu di splash screen

    private IEnumerator Start()
    {
        // Tunggu selama beberapa detik
        yield return new WaitForSeconds(waitTime);

        // Panggil NavigationManager untuk pindah ke Main Menu
        // Memakai konstanta dari SceneNames agar tidak salah ketik
        NavigationManager.Instance.LoadTargetScene(SceneNames.MAIN_MENU);
    }
}