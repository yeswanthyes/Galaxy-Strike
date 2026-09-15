using UnityEngine;
using UnityEngine.InputSystem;

public class FireObject : MonoBehaviour
{
    [SerializeField] GameObject[] bullets;
    [SerializeField] RectTransform CrossHair;
    [SerializeField] Transform TragetPoint;
    [SerializeField] float TragetPosition = 100f;
    
    bool fire = false;
    void Start()
    {
        foreach (GameObject laser in bullets)
        {
            // Keep the beam attached to its emitter while the aim direction changes.
            var laserMain = laser.GetComponent<ParticleSystem>().main;
            laserMain.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
    }
    void OnFire(InputValue value)
    {
        fire = value.isPressed;
    }

    void Update()
    {
        MoveCrossHair();
        MovePointTarget();
        AimLaser();
        Shoot();
    }

    void Shoot()
    {
        foreach (GameObject bullet in bullets)
    {
        var ps = bullet.GetComponent<ParticleSystem>();
        var firing = ps.emission;
        firing.enabled = fire;

        if (fire)
        {
            if (!ps.isPlaying)
                ps.Play();
        }
        else
        {
            if (ps.isPlaying)
                ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                // "StopEmitting" lets existing particles finish naturally instead of vanishing
        }
    }
        
    }

    void AimLaser()
    {
        foreach (GameObject laser in bullets)
        {
            Vector3 direction = TragetPoint.position - laser.transform.position;

            if (direction.sqrMagnitude > 0f)
            {
                laser.transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    void MoveCrossHair() {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        CrossHair.position = mousePosition;

    }
    void MovePointTarget()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

    Vector3 targetPointPosition = new Vector3(
        mousePosition.x,
        mousePosition.y,
        TragetPosition
    );

    TragetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
}
