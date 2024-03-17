using UnityEngine;

public class PlayerSoundFX : MonoBehaviour {
    [SerializeField] AudioSource damageAudioSource;
    [SerializeField] AudioSource deathAudioSource;


    private void OnEnable() {
        GEventsManager.AddListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
        GEventsManager.AddListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

    private void OnPlayerDamagedHandler(GData data) {
        damageAudioSource.Play();
    }

    private void OnPlayerKilledHandler(GData data) {
        deathAudioSource.Play();
    }


    private void OnDisable() {
        GEventsManager.RemoveListener(GEvents.PlayerDamaged, OnPlayerDamagedHandler);
        GEventsManager.RemoveListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }
}


