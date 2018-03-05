using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBall : MonoBehaviour {
    float unitTime;
    public float number;
    float circleTime;
    float angle;
    float radius;
    float angleSpeed;
    public float startTime = 0;
    public bool isRotate = true;

    public void SetParam(float unitTime, int number){
        this.unitTime = unitTime;
        this.number = number; 
        this.circleTime = unitTime * number;
        this.radius = GetRadius(number);
        this.angle = 0;
        this.angleSpeed = (2 * Mathf.PI)/ this.circleTime;


    }

    public void SetPosition(float time){
        //float nowTime = time;

        this.transform.position = new Vector3(Mathf.Cos(this.angleSpeed*time),Mathf.Sin(this.angleSpeed*time),0)*this.radius;
        //float x = Mathf.Cos(this.angleSpeed * nowTime);
        //this.transform.localScale = Vector3.one * (x + 1.5f)/4;
        //if (x >= 0.999f){
        //    GetComponent<Renderer>().material.color = Color.red;
        //}else{
        //    GetComponent<Renderer>().material.color = Color.blue;
        //}

    
    }

    void Update(){
        if(startTime > 0){
            if (isRotate)
            {
                SetPosition(Time.time - startTime);
            }else{
                if (transform.position.y < 14)
                {
                    transform.position += Vector3.up * Time.deltaTime * this.angleSpeed * radius;
                }else{
                    transform.position = new Vector3(transform.position.x, 14, 0);
                }
            }
        }
    }




    float GetRadius(int number){
        if(number == 1){
            return 1;
        }
        return 1 + Mathf.Log(number, 2)* 1.5f;
    }

    bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2 || number == 3) return true;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }

        }
        return true;

    }
}
