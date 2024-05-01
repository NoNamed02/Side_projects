using UnityEngine;

public class background_move : MonoBehaviour
{
    public GPSManager playerGPS; // GPSManager 스크립트에 접근하기 위한 변수
    public float movementSpeed = 1.0f; // 배경 이동 속도

    void Update()
    {
        // 플레이어의 위치 변화량을 받아옵니다.
        float latitudeChange = playerGPS.latitudeChange;
        float longitudeChange = playerGPS.longitudeChange;

        // 플레이어의 움직임에 따라 배경을 이동시킵니다.
        Vector3 newPosition = transform.position;
        newPosition.x -= longitudeChange * movementSpeed; // 경도 변화량에 따라 x축 이동
        newPosition.y -= latitudeChange * movementSpeed; // 위도 변화량에 따라 y축 이동
        transform.position = newPosition;
    }
}
