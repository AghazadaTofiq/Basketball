using System.Collections;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 10;

    private bool isGrounded = true;
    private Quaternion toRotation;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("HorizontalLeft"), 0, Input.GetAxisRaw("VerticalLeft"));

        transform.position += direction * MoveSpeed * Time.fixedDeltaTime;

        if (direction != Vector3.zero)
        {
            toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500 * Time.fixedDeltaTime);
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
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
