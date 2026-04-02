using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu vật chạm vào có Tag là Player
        if (other.CompareTag("Player"))
        {
            // Gọi hàm trừ máu từ HealthManager mà bạn đã có
            if (HealthManager.instance != null)
            {
                HealthManager.instance.HurtPlayer();
                Debug.Log("Đã trừ 1 đơn vị máu!");
            }
            else
            {
                Debug.LogError("Chưa tìm thấy HealthManager trong Scene!");
            }
        }
    }
}