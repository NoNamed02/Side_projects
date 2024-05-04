using UnityEngine;

public class GPSManager : MonoBehaviour
{
    public float latitude = 0.0f; // 시작 위도를 0으로 설정
    public float longitude = 0.0f; // 시작 경도를 0으로 설정

    private float previousLatitude = 0.0f; // 이전 위도
    private float previousLongitude = 0.0f; // 이전 경도

    public float latitudeChange = 0.0f; // 위도 변화량
    public float longitudeChange = 0.0f; // 경도 변화량

    public float distanceMoved = 0.0f; // 움직인 거리
    public float movementSpeed = 100000.0f;

    public float pos_x = 0.0f;
    public float pos_y = 0.0f;

    private bool initialized = false; // 위치 초기화 여부를 추적하는 변수

    void Start()
    {
        // 위치 서비스를 시작합니다.
        Input.location.Start();

        // 위치 서비스를 사용할 수 있는지 확인합니다.
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS is not enabled on this device.");
        }
    }

    void Update()
    {
        // GPS 값을 업데이트합니다.
        UpdateGPSValues();
        
        // 움직인 거리를 시간에 따라 조절하여 배경을 움직입니다.
        distanceMoved *= Time.deltaTime * movementSpeed;

        Vector3 newPosition = transform.position;
        newPosition.y -= distanceMoved;
        transform.position = newPosition;
    }

    void UpdateGPSValues()
    {
        // 위치 서비스가 실행 중이고 정상적인 경우에만 위치 정보를 업데이트합니다.
        if (Input.location.status == LocationServiceStatus.Running)
        {
            // GPS 값을 받아옵니다.
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            if (!initialized)
            {
                // 첫 번째 프레임에서의 이전 위치를 현재 위치로 초기화합니다.
                previousLatitude = latitude;
                previousLongitude = longitude;
                initialized = true;
            }

            // 이전 위치와 현재 위치의 차이를 계산합니다.
            latitudeChange = latitude - previousLatitude;
            longitudeChange = longitude - previousLongitude;
            pos_x += latitudeChange;
            pos_y += longitudeChange;

            // 벡터값
            distanceMoved = Mathf.Sqrt(latitudeChange * latitudeChange + longitudeChange * longitudeChange);

            // 이전 위치를 현재 위치로 업데이트합니다.
            previousLatitude = latitude;
            previousLongitude = longitude;
        }
    }

    void OnDestroy()
    {
        // 앱이 종료되면 위치 서비스를 중지합니다.
        Input.location.Stop();
    }
}
