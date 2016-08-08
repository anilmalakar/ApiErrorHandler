# ApiErrorHandler
Api Error handler handles webApi error at base controller and store them in mongodb.

When we are working on WebApi, we tend to write try/catch in each action method. The proposed solution is to have exception handling
in base controller and store the exceptions in some persistent medium. 
I choose to store the exceptions in mongodb and use Angularjs to display the exception stores in mongodb on UI.

1.	To start using this project, you should install mongodb from here https://www.mongodb.com/download-center#community
2.	These instructions assume that you have installed MongoDB to C:\Program Files\MongoDB\Server\3.2\bin
3.	After installation set the data directory as below. MongoDB requires a data directory to store all data.
4.	Create directory path like: C>ApiErrorHandler>mongodb>data. Open command prompt and use command
C:\Program Files\MongoDB\Server\3.2\bin>mongod.exe --dbpath c:\ApiErrorHandler\mongodb\data
Close command prompt.
5.	Now run two new command prompt. On one command prompt use >mongod , it wait for connection on port 27017.
6.	On 2nd command prompt use command >mongo , it shows connecting to test [default db]
7.	Create Db while using command on mondo shell >use ErrorDb
8.	Create Error collection as >db.createCollection('Errors')
9.	Create Error collection as >db.createCollection('Users')
10.	Download the solution from github, update nuget package if any required.
11.	Build the solution and run it [ http://localhost:port/ ].
12.	You will see empty grid
13.	On browser run this: http://localhost:port/api/User . It calls the User ApiController Get method where code is written to throw exception  [use port on which you application running]
14.	Refresh web application page. You can see error added to it.
15.	Now add a post request using fiddler. First add a legitimate user using endpoint http://localhost: port/api/AddUser and RequestBody : {'FirstName' : 'FirstTestName' , 'LastName' : 'lastTestName'}
16.	Now add an error using below endpoint : http://localhost:port/api/AddUserError with RequestBody : {null}  [Even if you pass correct value, code is marking it null]
17.	Now if you to application home page and refresh, you can see error recorded and displayed in grid.
