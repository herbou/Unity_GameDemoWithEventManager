using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 3f;


    private void OnEnable() {
        GEventsManager.AddListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

    private void OnPlayerKilledHandler(GData data) {
        enabled = false;
    }

    private void FixedUpdate() {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.position += direction * speed * Time.fixedDeltaTime;
    }


    private void OnDisable() {
        GEventsManager.AddListener(GEvents.PlayerKilled, OnPlayerKilledHandler);
    }

}
