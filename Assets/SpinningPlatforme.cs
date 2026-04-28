using UnityEngine;

public class SpinningPlatforme : MonoBehaviour
{
    int direction = 1;
    float myAngel = 5;
    public float TurnSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float RateOfSpeed = TurnSpeed;

        myAngel += RateOfSpeed = Time.deltaTime * direction;


        transform.rotation = Quaternion.Euler(0, 0,myAngel );


    }
}
