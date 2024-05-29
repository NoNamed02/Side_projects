#include <Wire.h>
#include <MPU6050.h>

MPU6050 mpu;
unsigned long last_time = 0;

void setup() {
    Serial.begin(9600);
    Wire.begin();
    mpu.initialize();
    if (!mpu.testConnection()) {
        Serial.println("MPU6050 연결 실패");
        while (1);
    }
    Serial.println("MPU6050 연결 성공");
}

void loop() {
    int16_t ax, ay, az;
    int16_t gx, gy, gz;

    mpu.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);

    float ax_rad = ax / 16384.0;  // 16384.0은 MPU6050의 감도 값 (2g)
    float ay_rad = ay / 16384.0;
    float az_rad = az / 16384.0;

    float ax_deg = ax_rad * 180.0 / PI;
    float ay_deg = ay_rad * 180.0 / PI;
    float az_deg = az_rad * 180.0 / PI;

    if (millis() > last_time + 1000) {
        Serial.print(ax_deg);
        Serial.print(",");
        Serial.print(ay_deg);
        Serial.print(",");
        Serial.println(az_deg);
        last_time = millis();
    }

    // Send some message when I receive an 'A' or a 'Z'.
    switch (Serial.read()) {
        case 'A':
            Serial.println("That's the first letter of the abecedarium.");
            break;
        case 'Z':
            Serial.println("That's the last letter of the abecedarium.");
            break;
    }
}
