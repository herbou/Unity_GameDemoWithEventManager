using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] string damageAnim;
    [SerializeField] string deathAnim;


    private void OnEnable() {
        GEventsManager.AddListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
        GEventsManager.AddListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

    private void OnPlayerDamagedHandler(GData data) {
        animator.Play(damageAnim);
    }

    private void OnPlayerKilledHandler(GData data) {
        animator.Play(deathAnim);
    }


    private void OnDisable() {
        GEventsManager.RemoveListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
        GEventsManager.RemoveListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }
}
