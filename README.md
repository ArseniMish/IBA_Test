Тестовое задание для IBA:

1. Написана API для системы учета и контроля скоростного режима.
  1.1 AddMeasurement - - Прием данных от системы фиксации скорости авто
	
![image](https://user-images.githubusercontent.com/66179442/124829476-5aad1580-df81-11eb-8b80-a5cf3c892ed4.png)

![image](https://user-images.githubusercontent.com/66179442/124829526-6993c800-df81-11eb-86cf-c9ccac544aa5.png)

Создает в системе json файлы, в которые упакованы объекты измерения скорости ![image](https://user-images.githubusercontent.com/66179442/124829735-ae1f6380-df81-11eb-9621-ce0bbd3b00c8.png)
  2.1 GetOffendingVehicle - Запрос на авто превысившие указанную скорость за указанную дату
	
  ![image](https://user-images.githubusercontent.com/66179442/124829971-f5a5ef80-df81-11eb-879c-98c55ea0aab0.png)
	
  ![image](https://user-images.githubusercontent.com/66179442/124830232-43225c80-df82-11eb-803f-d85cbe675bbb.png)
	
  2.2 GetSpeed - Максимальная и минимальная зафиксированная скорость за указанную дату
	
  ![image](https://user-images.githubusercontent.com/66179442/124830467-9694aa80-df82-11eb-8021-16a3b3fc3bcc.png)
	
![image](https://user-images.githubusercontent.com/66179442/124830484-9eece580-df82-11eb-8722-5bd4c560daf8.png)

2. Вся работа с файлами реализована в FileStorageService
3. Вся бизнес логика реализована в MeasurementService
4. Ограничения по времени сделаны через фильтр, который в виде аттрибута набрасывается на нужные методы - WorkTimeAttribute. Время указывается в  appsettings
5. 
  ![image](https://user-images.githubusercontent.com/66179442/124830899-33574800-df83-11eb-9d69-7ddea62b9223.png)
	
![image](https://user-images.githubusercontent.com/66179442/124830919-394d2900-df83-11eb-9028-0ffd7c1cde71.png)

![image](https://user-images.githubusercontent.com/66179442/124830936-3f430a00-df83-11eb-8e42-0a8b30d94f56.png)

