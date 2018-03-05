using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class NumberCircleController : MonoBehaviour
{

	List<GameObject> NumberBallList = new List<GameObject>();
	float startTime;
	float time;
	public float unitTime;
	GameObject numberBallPrefab;
	public bool Prime;
    public LineScript lineScript;
    public int max = 100;
	// public LineRenderer lr;

	IntReactiveProperty circleNumber = new IntReactiveProperty(0);
	// Use this for initialization

	void Awake()
	{
		numberBallPrefab = Resources.Load("NumberBall") as GameObject;

	}
    void Start()
    {
        startTime = 0;
        time = 0;
        //unitTime = 2;
        GenerateNumberBall(max);

        circleNumber.Subscribe(num =>
        {
            Debug.Log(num);

            if (num == 0 || num == 1)
                GetComponent<NumberCircleView>().SetPrimeLabel("");
            else if (IsPrime(num))
            {
                GetComponent<NumberCircleView>().SetPrimeLabel("素数");
                GetComponent<NumberCircleView>().primeLabel.color = Color.red;
            }
            else
            {
                GetComponent<NumberCircleView>().SetPrimeLabel("合成数");
                GetComponent<NumberCircleView>().primeLabel.color = Color.blue;
            }

            if (num >= 2 && num <= max)
            {
                GetComponent<NumberCircleView>().SetLabel(num);
                GameObject obj = NumberBallList.Where(ball => ball.GetComponent<NumberBall>().number == num)
                                                    .First();
                if (obj.GetComponent<NumberBallView>())
                {
                    NumberBallView view = obj.GetComponent<NumberBallView>();
                    if (view != null)
                    {
                        if (IsPrime(num))
                        {
                            view.SetColor(Color.red);
                            lineScript.SetColor( Color.red);
                        }else{
                            view.SetColor(Color.blue);
                            obj.GetComponent<NumberBall>().isRotate = false;
                            lineScript.SetColor(Color.blue);
                        }
                    }
                }
            }
        });
    }

            //lr.materials[0].color = new Color(1, 0, 0);
       


	void Update()
		{



			if (Input.GetKeyDown("s"))
			{

				startTime = Time.time;
				foreach (GameObject ball in NumberBallList)
				{
					NumberBall script = ball.GetComponent<NumberBall>();
                    script.startTime = startTime;
				}
                
			}

			time = Time.time - startTime;



			if (NumberBallList.Count >= 1 && startTime > 0)
			{
				circleNumber.Value = (int)(time / unitTime);
				//foreach (GameObject ball in NumberBallList)
				//{
				//	NumberBall script = ball.GetComponent<NumberBall>();
				//	script.SetPosition(time);
				//}


			}

		}


		void GenerateNumberBall(int count)
		{
			if (count <= 1) return;

			NumberBallList = new List<GameObject>();
			for (int i = 2; i <= count; i++)
			{
				if (!Prime || IsPrime(i))
				{
					GameObject numberBall = Instantiate(numberBallPrefab, new Vector3(GetRadius(i), 0, 0), Quaternion.identity);
					numberBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
					// numberBall.transform.position = new Vector3(i, 0, 0);
					//NumberBall script = numberBall.AddComponent<NumberBall>();
					numberBall.GetComponent<NumberBall>().SetParam(unitTime, i);
					NumberBallList.Add(numberBall);
					numberBall.GetComponent<NumberBallView>().SetLabel(i);
				}
			}

		}
		float GetRadius(int number)
		{
			if (number == 1)
			{
				return 1;
			}
			return 1 + Mathf.Log(number, 2) * 1.5f;
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
