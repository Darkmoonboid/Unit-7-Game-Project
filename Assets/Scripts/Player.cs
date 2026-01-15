using UnityEngine;
public class Player : MonoBehaviour

{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _horizontalInput;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(_horizontalInput, 0, 0) * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }
    }

    private void FlipGravity()
    {
        //Debug.log("Flip!");
        _rigidbody2D.gravityScale *= -1f;

        Vector3 scale = transform.localScale;
        scale.y *= -1f;
        transform.localScale = scale;
    }



}
