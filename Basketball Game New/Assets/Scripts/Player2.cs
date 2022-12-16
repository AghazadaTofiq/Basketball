using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 10;

    private bool isGrounded = true;
    private Quaternion toRotation;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("HorizontalRight"), 0, Input.GetAxisRaw("VerticalRight"));

        transform.position += direction * MoveSpeed * Time.fixedDeltaTime;

        if (direction != Vector3.zero)
        {
            toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.fixedDeltaTime);
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.RightAlt))
            {
                StartCoroutine(Jump());
                isGrounded = false;
            }
        }
    }

    private IEnumerator Jump()
    {
        transform.position += Vector3.up;
        yield return new WaitForSeconds(0.1f);
        transform.position -= Vector3.up;
        isGrounded = true;
    }
}