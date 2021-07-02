# EventApp
## Предметная область 
Поиск кампании по хобби
## Связанные сущности
- Пользователь
- Хобби
- Кампания
- Сообщение
## Описание предметной области
- Приложение создано помагать пользователю находить себе кампании по интересам.  
- Пользователь может создавать свои кампании или присоединяться к уже существующим.  
- При создании кампании, ей указывается одно или несколько хобби.  
- По указанным кампании хобби, пользователь может решить присоединяться ли к ней или нет.  
- Пользователи внутри кампании могут общаться между собой путем отправки сообщений в общий чат.  
## Ограничения, связи сущностей
- Пользователь может создавать кампании.
- При создании, кампании задается одно или несколько хобби.
- Пользователь может присоединяться к нескольким кампаниям.
- Любой пользователь, находящийся в кампании, может оставлять в ней сколько угодно сообщений.
- Не должно быть двух пользователей с одинаковым именем.
## Entity Relation Diagram
![Alt text](/src/docs/ER_Diagram.svg)
## Use-Case Diagram
![Alt text](/src/docs/Use_Case_Diagram.svg)
## Вид приложения
Клиент-серверное SPA web-приложение.  
**Бэкенд**: .NET Core, C#.  
**БД - MySQL**: легка в настройке, поддерживает GUID, есть драйвер для .NET, есть поддержка в Nhibernate "из коробки".  
**ORM - Nhibernate**: подходит для DDD.  
**Тип API - REST**: распространённый, прост в изучении, есть поддержка в .NET Core "из коробки", легковесный.  
## Class diagram
![Alt text](/src/docs/Class_Diagram.svg)
