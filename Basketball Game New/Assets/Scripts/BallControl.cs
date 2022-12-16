using System;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private float prepareSpeed;
    [SerializeField] private Transform BallInHandsLeft;
    [SerializeField] private Transform BallOverHeadLeft;
    [SerializeField] private Transform DestinationPoint;
    [SerializeField] private Transform ArmsLeft;
    [SerializeField] private Transform PlayerLeft;
    [SerializeField] private Transform BallInHandsRight;
    [SerializeField] private Transform BallOverHeadRight;
    [SerializeField] private Transform ArmsRight;
    [SerializeField] private Transform PlayerRight;
    [SerializeField] private Rigidbody rb;

    private float yLeft;
    private float zLeft;
    private float yRight;
    private float zRight;

    private Quaternion handsUpLeft;
    private Quaternion handsDownLeft;
    private Quaternion handsUpRight;
    private Quaternion handsDownRight;

    private bool prepare = true;

    private bool IsBallInHandsLeft = true;
    private bool IsBallInHandsRight = false;

    private void Start()
    {
        handsUpLeft = Quaternion.Euler(180, yLeft, zLeft);
        handsDownLeft = Quaternion.Euler(0, yLeft, zLeft);
        handsUpLeft = Quaternion.Euler(180, yRight, zRight);
        handsDownLeft = Quaternion.Euler(0, yRight, zRight);
    }

    void Update()
    {
        yLeft = PlayerLeft.eulerAngles.y;
        zLeft = PlayerLeft.eulerAngles.z;
        yRight = PlayerLeft.eulerAngles.y;
        zRight = PlayerLeft.eulerAngles.z;

        if (IsBallInHandsLeft)
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                if (prepare)
                {
                    transform.position = BallOverHeadLeft.position;
                    
                    ArmsLeft.rotation = Quaternion.Slerp(ArmsLeft.rotation, handsUpLeft, prepareSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (prepare)
                {
                    transform.position = BallInHandsLeft.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));

                    ArmsLeft.rotation = Quaternion.Slerp(ArmsLeft.rotation, handsDownLeft, prepareSpeed * Time.deltaTime);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                prepare = false;

                ArmsLeft.rotation = Quaternion.Slerp(ArmsLeft.rotation, handsUpLeft, prepareSpeed * Time.deltaTime);

                transform.position = BallOverHeadLeft.position;

                Debug.Log(Vector3.Distance(transform.position, DestinationPoint.position));

                switch (Vector3.Distance(transform.position, DestinationPoint.position))
                {
                    case < 10:
                        rb.AddForce(PlayerLeft.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.5f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.5f, 0), ForceMode.Impulse);
                        break;
                    case < 30:
                        rb.AddForce(PlayerLeft.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.1f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.1f, 0), ForceMode.Impulse);
                        break;
                    case < 50:
                        rb.AddForce(PlayerLeft.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.25f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.25f, 0), ForceMode.Impulse);
                        break;
                }
            }

            if (transform.position != BallInHandsLeft.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5)) && transform.position != BallOverHeadLeft.position)
            {
                ArmsLeft.rotation = Quaternion.Slerp(ArmsLeft.rotation, handsDownLeft, prepareSpeed * Time.deltaTime);
                IsBallInHandsLeft = false;
                prepare = true;
            }
        }

        if (IsBallInHandsRight)
        {
            if (Input.GetKey(KeyCode.RightControl))
            {
                if (prepare)
                {
                    transform.position = BallOverHeadRight.position;

                    ArmsRight.rotation = Quaternion.Slerp(ArmsRight.rotation, handsUpRight, prepareSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (prepare)
                {
                    transform.position = BallInHandsRight.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5));
                    ArmsRight.rotation = Quaternion.Slerp(ArmsRight.rotation, handsDownRight, prepareSpeed * Time.deltaTime);
                }
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                prepare = false;

                ArmsRight.rotation = Quaternion.Slerp(ArmsRight.rotation, handsUpRight, prepareSpeed * Time.deltaTime);

                transform.position = BallOverHeadRight.position;

                Debug.Log(Vector3.Distance(transform.position, DestinationPoint.position));

                switch (Vector3.Distance(transform.position, DestinationPoint.position))
                {
                    case < 10:
                        rb.AddForce(PlayerRight.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.5f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.5f, 0), ForceMode.Impulse);
                        break;
                    case < 30:
                        rb.AddForce(PlayerRight.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.1f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.1f, 0), ForceMode.Impulse);
                        break;
                    case < 50:
                        rb.AddForce(PlayerRight.forward * (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.25f + new Vector3(0, (float)Math.Sqrt(Vector3.Distance(transform.position, DestinationPoint.position)) * 2.25f, 0), ForceMode.Impulse);
                        break;
                }
            }

            if (transform.position != BallInHandsRight.position + Vector3.up * Mathf.Abs(Mathf.Sin(Time.time * 5)) && transform.position != BallOverHeadRight.position)
            {
                ArmsRight.rotation = Quaternion.Slerp(ArmsRight.rotation, handsDownRight, prepareSpeed * Time.deltaTime);
                IsBallInHandsRight = false;
                prepare = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!IsBallInHandsLeft)
            {
                IsBallInHandsLeft = true;
                IsBallInHandsRight = false;
            }
        }
        if (other.CompareTag("PlayerRight"))
        {
            if (!IsBallInHandsRight)
            {
                IsBallInHandsRight = true;
                IsBallInHandsLeft = false;
            }
        }
    }
}
