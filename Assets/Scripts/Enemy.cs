using System.Collections;
using UnityEngine;


public class Enemy : MonoBehaviour {
    [SerializeField] Transform bulletsHolder;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] float bulletSpeed=7f;
    [SerializeField] float shotBulletsDelay = 0.3f;


    private void OnEnable() {
        GEventsManager.AddListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

    private void Start() {
        StartCoroutine(ShotBulletsCoroutine());
    }

    private void OnPlayerKilledHandler(GData data) {
        StopCoroutine(ShotBulletsCoroutine());
        bulletsHolder.gameObject.SetActive(false);
    }

    private IEnumerator ShotBulletsCoroutine() {
        while (true) {
            Bullet bullet = bulletPrefab.CreateInstance(bulletsHolder.position, bulletsHolder);
            bullet.Shoot(bulletsHolder.localPosition, bulletSpeed);
            yield return new WaitForSeconds(shotBulletsDelay);
        }
    }


    private void OnDisable() {
        GEventsManager.RemoveListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

}
