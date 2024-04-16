using UnityEngine;


public class Player : MonoBehaviour {
    [SerializeField] float health = 100f;
    [SerializeField] float damageAmount = 11.71f;

    private float defaultHealth; // this will always equal to 100 in this case

    private bool isAlive = true;


    private void Start() {
        defaultHealth = health;
    }

    public void TakeDamage() {
        health = Mathf.Max(health - damageAmount, 0);

        GEventsManager.Invoke(GEvents.PlayerDamaged, new GData(health, defaultHealth));

        if (health <= 0f) {
            isAlive = false;
            GEventsManager.Invoke(GEvents.PlayerKilled);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isAlive) {
            if (collider.TryGetComponent(out Bullet bullet)) {
                TakeDamage();
                bullet.Remove();
            }
        }
    }

}
