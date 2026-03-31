using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float Health = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.GetComponent<PlayerHealth>().AddHealth(Health);
        Destroy(gameObject);
        Debug.Log(Health);
    }
}
