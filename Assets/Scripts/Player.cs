using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _horizontalInput;

    [SerializeField]
    private Transform customSpawnPoint;

    [SerializeField]
    private string spikeTag = "Spike";

    private Rigidbody2D rb;
    private Vector3 respawnPosition;
    private float respawnFreeze = 0f;
    private float respawnDelay = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPosition = customSpawnPoint ? customSpawnPoint.position : transform.position;
    }

    void Update()
    {
        if (respawnFreeze > 0f) 
        {
            respawnFreeze -= Time.deltaTime;
            return; 
        }

        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(_horizontalInput, 0, 0) * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.collider.CompareTag(spikeTag))
        {        
            Debug.Log("spike respawn");
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
        respawnFreeze = respawnDelay;
        if (Physics2D.gravity == -1)
        {
            Physics2D.gravity = 1f;
        }
    }

}
