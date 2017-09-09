using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public GameObject goods;
    public GameObject bigGoods;
    public GameObject dummy;
    public GameObject bigDummy;
    float timeleft;
	// Use this for initialization
	void Start () {
        timeleft = 1;
	}
	
	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
        if(timeleft <= 0){
            timeleft = 1;
			if (UnityEngine.Random.Range(1, 3) == 1)
			{
				// 戻り値はObjectクラスなので、必ず複製したオブジェクトと同じクラスへキャストする
				GameObject instance = (GameObject)Instantiate(dummy);
				// 複製したオブジェクトの位置をemmitterオブジェクトと同じ位置へ
				instance.transform.position = new Vector3(Random.Range(-30.0f, 30.0f), 1, 40);
			}
			else if (UnityEngine.Random.Range(1, 4) == 1)
			{
				// 戻り値はObjectクラスなので、必ず複製したオブジェクトと同じクラスへキャストする
				GameObject instance = (GameObject)Instantiate(goods);
				// 複製したオブジェクトの位置をemmitterオブジェクトと同じ位置へ
				instance.transform.position = new Vector3(Random.Range(-30.0f, 30.0f), 1, 40);
			}
			else if (UnityEngine.Random.Range(1, 5) == 1)
			{
				// 戻り値はObjectクラスなので、必ず複製したオブジェクトと同じクラスへキャストする
				GameObject instance = (GameObject)Instantiate(bigDummy);
				// 複製したオブジェクトの位置をemmitterオブジェクトと同じ位置へ
				instance.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1, 40);
			}
			else if (UnityEngine.Random.Range(1, 10) == 1)
			{
				// 戻り値はObjectクラスなので、必ず複製したオブジェクトと同じクラスへキャストする
				GameObject instance = (GameObject)Instantiate(bigGoods);
				// 複製したオブジェクトの位置をemmitterオブジェクトと同じ位置へ
				instance.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1, 40);
			}    
        }
	}
}
