using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMoveToRight : MonoBehaviour
{
    // Khai báo biến để chứa prefab của gem
    public GameObject gemPrefap;

    //Biến đếm thời gian kể từ lần sinh viên gem cuối cùng
    public float timer;

    //khoảng thời gian (tính bằng giây) giữa mỗi lần sinh viên gem mới
    public float spawnInterval = 3f;

    // Update is called once per frame
    void Update()
    {
        //B1: start timer
        timer += Time.deltaTime;

        //B2:Kiểm tra thời gian có pass interval để tạo ngọc mới
        if (timer >= spawnInterval)
        {
            SpawnGem(); //gọi hàm tạo gem
            timer = 0; //reset timer
        }

    }

    //khai báo hàm tạo gem
    void SpawnGem()
    {
        float randomY = Random.Range(-3f, 3f);
        //Trỏ tới vị trí cố định trên màn hình
        Vector3 spawnPosition = new Vector3(-20f, randomY, 0);

        //Hàm Instantiate để tạo 1 bản sao của object prefab trên vị trí đã trỏ
        Instantiate(gemPrefap, spawnPosition, Quaternion.identity); //Instatiiate(object,vị trí, hướng quay)
    }
}