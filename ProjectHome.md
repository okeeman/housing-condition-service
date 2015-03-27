## Enterprise Applications Development Continuous Assessment 3 ##
This project consists of 4 solutions in total:

1. MVC3 Web app

2. WCF Web service

3. Windows Phone app

4. Windows console client

The application is meant to be used by local authorities who would send inspectors to survey houses and record the cost of repairs needed, if any. The MVC app and WCF Web service are hosted on Windows Azure and are linked to a SQL Database also hosted on Azure:

http://housecondition.cloudapp.net/

http://housingcondition.cloudapp.net/HouseCondition.svc

The MVC app has CRUD ability. It features a Bing map which shows the location of the individual houses.

The WCF Web service supports SOAP and REST. REST calls may be made without appending .svc to the URL.

The Windows phone app utilises the WCF Web service to access the database and return aggregate data from it.

The Windows console client makes SOAP and REST calls to the WCF Web service.
