using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string targetScene = SceneNames.STORY_LIST;

    // Jika Anda memakai TouchDispatcher dari Modul 2, ganti fungsi ini 
    // menjadi public override void OnInteract() (dan wariskan dari InteractiveObject)
    private void OnMouseDown() 
    {
        Debug.Log($"[SceneTrigger] Mengklik objek, pindah ke {targetScene}");
        NavigationManager.Instance.LoadTargetScene(targetScene);
    }
}