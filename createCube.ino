const int trigPin = 9;       // Pin for ultrasonic sensor trigger
const int echoPin = 10;      // Pin for ultrasonic sensor echo
const int buzzerPin = 8;     // Pin connected to the buzzer

void setup() {
  Serial.begin(9600);              // Initialize serial communication at 9600 baud
  pinMode(trigPin, OUTPUT);        // Set trigger pin as output
  pinMode(echoPin, INPUT);         // Set echo pin as input
  pinMode(buzzerPin, OUTPUT);      // Set buzzer pin as output
}

void loop() {
  long duration, distance;

  // Send an ultrasonic pulse
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);            // Short delay before trigger
  digitalWrite(trigPin, HIGH);     // Send high pulse for 10µs
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  // Read the duration of the echo pulse
  duration = pulseIn(echoPin, HIGH);

  // Calculate distance in cm (speed of sound is ~0.034 cm/µs)
  distance = duration * 0.034 / 2;

  if (distance <= 5) {
    digitalWrite(buzzerPin, HIGH);   // Turn buzzer ON
    Serial.println("DETECTED");      // Send detection message to serial
  } else {
    digitalWrite(buzzerPin, LOW);    // Turn buzzer OFF
    Serial.println("CLEAR");         // Send "clear" message to serial
  }

  delay(100);  // Small delay to prevent flooding the serial port
}
