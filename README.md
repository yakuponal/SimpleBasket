# SimpleBasket
 Simple e-commerce basket API based on .NET Core
 
## Notes
* Normally, when the project is run, the database should be created on your local server automatically. If your SQL Server version does not support using "Server=.", use your local computer name instead of (.) in appsettings.json file.
* You can test the API by importing the following Postman collection: https://www.postman.com/collections/ebdece7ad08a5d0aadef
* While adding the product to the basket, stock control was carried out using the number of the product in the basket and the desired amount to be added.
* The customer information, product information and quantity sent during adding products to the basket have been validated.
* Available endpoints: 
  * GET /products
  * GET /basket/{customerId}
  * POST /basket

## Technologies and approaches used
.NET Core\
Entity Framework Core\
Code First\
CQRS\
Onion Architecture\
DDD\
Clean Code\
SOLID\
OOP\
Design Patterns\
Dependency Injection\
MSSQL

## Solution Structure
SimpleBasket.Application\
SimpleBasket.Domain\
SimpleBasket.Persistence\
SimpleBasket.API

## Database Design
![db_design](https://user-images.githubusercontent.com/21276521/104153309-14706280-53f3-11eb-853d-66a4790df8dd.png)
