using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform Projectile;
    public Transform DrawFrom;
    public Transform DrawTo;

    public String slingshotString;
    public int NrDrawIncrements = 10;

    public Transform Slingshotgun;

    private Transform currentProjectile;

    private bool draw;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DrawSlingShot(1);
        if (Input.GetKeyUp(KeyCode.Space))
            ReleaseAndShoot(50);
        if (Input.GetKeyDown(KeyCode.R))
            RotateSlingShotR(5);
        if (Input.GetKeyDown(KeyCode.L))
            RotateSlingShotL(5);
    }

    public void RotateSlingShotL(float speed)
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Slingshotgun.transform.Rotate(0, -speed, 0);
        Debug.Log(Slingshotgun + " turned left");
    }

    public void RotateSlingShotR (float speed)
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Slingshotgun.transform.Rotate(0, speed, 0);
        Debug.Log(Slingshotgun + " turned right");
    }

    public void ReleaseAndShoot(float shotForce)
    {
        FindObjectOfType<AudioManager>().Play("Snap");
        draw = false;
        currentProjectile.transform.parent = null;
        Rigidbody projectileRigidBody = currentProjectile.GetComponent<Rigidbody>();
        projectileRigidBody.isKinematic = false;
        projectileRigidBody.AddForce(transform.forward * shotForce, ForceMode.Impulse);
        slingshotString.CenterPoint = DrawFrom;
        Debug.Log("shooting");
    }

    public void DrawSlingShot(float speed)
    {
        FindObjectOfType<AudioManager>().Play("PullBack");
        draw = true;
        currentProjectile = Instantiate(Projectile, DrawFrom.position, Quaternion.identity, transform);
        currentProjectile.forward = transform.forward;
        slingshotString.CenterPoint = currentProjectile.transform;

        float waitTimeBetweenDraws = speed / NrDrawIncrements;
        StartCoroutine(drawSlingShotWithIncrements(waitTimeBetweenDraws));
        Debug.Log("drawing");
    }

    private IEnumerator drawSlingShotWithIncrements(float waitTimeBetweenDraws)
    {
        for (int i = 0; i < NrDrawIncrements; i++)
        {
            if (draw)
            {
                currentProjectile.transform.position = Vector3.Lerp(DrawFrom.position, DrawTo.position, (float)i / NrDrawIncrements);
                yield return new WaitForSeconds(waitTimeBetweenDraws);
            }
            else
            {
                i = NrDrawIncrements;
            }
        }
    }

}