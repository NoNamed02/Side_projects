 #include <Wire.h>
#include <MPU6050.h>

MPU6050 mpu(0x68);  // 기본 주소
MPU6050 mpu2(0x69);  // AD0 핀을 HIGH로 설정하여 주소 변경
unsigned long last_time = 0;

void setup() {
    Serial.begin(9600);
    Wire.begin();
    mpu.initialize();
    mpu2.initialize();
    if (!mpu.testConnection()) {
        Serial.println("MPU6050 연결 실패");
        while (1);
    }
    Serial.println("MPU6050 연결 성공");
}

void loop() {
    int16_t ax, ay, az;
    int16_t gx, gy, gz;
    
    int16_t ax1, ay1, az1, gx1, gy1, gz1;

    mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    mpu2.getMotion6(&ax1, &ay1, &az1, &gx1, &gy1, &gz1);
    float ay_rad = ay / 16384.0;
    float az_rad = az / 16384.0;

    float ay_deg = ay_rad * 180.0 / PI;
    float az_deg = az_rad * 180.0 / PI;

    float ay1_rad = ay1 / 16384.0;
    float az1_rad = az1 / 16384.0;

    float ay1_deg = ay1_rad * 180.0 / PI;
    float az1_deg = az1_rad * 180.0 / PI;

    if (millis() > last_time + 1000) {
        Serial.print(ay_deg);
        Serial.print(",");
        Serial.print(ay1_deg);
        Serial.print(",");
        Serial.println(az_deg);
        last_time = millis();
    }
}
