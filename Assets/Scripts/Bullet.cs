using UnityEngine;


public class Bullet : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;


    public Bullet CreateInstance(Vector2 position, Transform parent) {
        return Instantiate(this, position, Quaternion.identity, parent);
    }

    public void Shoot(Vector2 direction, float speed) {
        rb.velocity = direction * speed;
    }

    public void Remove() {
        Destroy(gameObject);
    }
}
