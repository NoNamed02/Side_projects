using UnityEngine;
using System.Collections;

public class GPSManager : MonoBehaviour
{
    public double latitude;
    public double longitude;
    void Start()
    {
        // 위치 서비스를 시작합니다.
        Input.location.Start();
        
        // 위치 서비스를 사용할 수 있는지 확인합니다.
        if (Input.location.isEnabledByUser)
        {
            // 위치 서비스가 활성화되어 있으면 GPS 값을 받아옵니다.
            StartCoroutine(UpdateGPS());
        }
        else
        {
            Debug.Log("GPS is not enabled on this device.");
        }
    }

    IEnumerator UpdateGPS()
    {
        // 위치 서비스가 시작될 때까지 대기합니다.
        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(1);
        }

        // 위치 서비스 시작에 성공했을 때
        if (Input.location.status == LocationServiceStatus.Running)
        {
            // GPS 값을 받아옵니다.
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }
        else
        {
            Debug.Log("Failed to initialize location service.");
        }

        // 위치 서비스를 중지합니다.
        Input.location.Stop();
    }
    
    void OnDestroy()
    {
        // 앱이 종료되면 위치 서비스를 중지합니다.
        Input.location.Stop();
    }
}
