# TTracker
### Task
 ```txt
1. Создать базу данных при помощи Entity Framework.
Структура базы и связей должна быть следующая - есть список туристов,
есть список стран. У туриста должно быть имя.
У страны - название и короткое описание.
Каждый турист мог побывать в одной и той же стране несколько раз в разные даты
(скажем, он мог быть в Германии три раза в этом году,
и два раза в предыдущем). Даты посещений фиксируются.
Базу можно заполнить любыми данными,
сама база должна быть в локальном файле (развертывать где-то на сервере необязательно,
 но если решите делать так, то будет необходим бэкап базы и инструкция по установке).
 
2. На UI создать две странички - "Список стран" и "Отчет о посещаемости".
Переход между страничками желательно сделать через меню с роутингом.

3. "Список стран" - отображает список стран.

4. "Отчет о посещаемости" - здесь должно быть поле выбора туриста по имени
(можно просто заполнять одним списком),
а также поле выбора года (с доступным списком годов).
Пользователь выбирает туриста, выбирает год, нажимает кнопку "Получить данные",
и ему отображается таблица, в которой перечислены страны,
где побывал турист в заданный год и количество раз,
сколько раз он там побывал. Например - Германия - 2, Финляндия - 1.
Если турист не был в какой-либо стране, нулевые значения отображать не нужно.

5. Структуру серверной части,
формат обмена данными и прочее вы проектируете самостоятельно
в соответствии с собственными предпочтениями.
```
### Current state
![Current state](https://raw.githubusercontent.com/iMoonlight/TTracker/master/misc/currentstate.png)
![Current state2](https://raw.githubusercontent.com/iMoonlight/TTracker/master/misc/currentstate2.png)
![Current state3](https://raw.githubusercontent.com/iMoonlight/TTracker/master/misc/currentstate3.png)

### Startup

Install and configure your own MySQL server.

Install package references with NuGet.

 ```pwsh
PM> Install-Package Microsoft.EntityFrameworkCore
PM> Install-Package Pomelo.EntityFrameworkCore.MySql
```

Filup connectionString in Startup.cs with your config

```cs
connectionString = "server=YOUR_SERVER;database=YOUR_DB;uid=YOUR_USER;pwd=YOUR_PASS";
```
Apply already generaed migration.

```pwsh
> Update-Database
```

Build solution.

Done.

Also you can execute fakedata.sql to to fill db with some data.

### APIs
Basic
```api
GET api/countries/all
GET api/countries/by/id/{countryId}

GET api/tourists/all
GET api/tourists/by/id/{touristId}

GET api/visits/yearsrange
GET api/visits/by/tourist/tourist.id/country/country.id/year/visit.date.year
```
Dev
```api
GET api/dev/visits/gen/{chance} - generates fake visits data
```

License
----

MIT
