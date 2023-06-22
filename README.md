# Products, Stores, and Inventory API 
This project is a .NET 7.0 API for managing products, stores, and the inventory of a specific store. The API provides endpoints for creating, retrieving, updating, and deleting products, stores, and inventory items. Additionally, the API allows adding and removing products from a store's inventory while keeping track of the available quantity.

## Installation

To install and run this .NET (C#) project, you will need an IDE for .NET development, such as Visual Studio or Visual Studio Code. You will also need MySQL (Workbench) to manage the database. Follow the steps below to set up and run the project:

1. Make sure you have the .NET SDK 7.0 or higher installed on your machine. You can check your SDK version by running the command dotnet --version in the terminal or command prompt.

2. Install MySQL Server on your machine or use a remote server. If you don't have it, download and install the latest version of MySQL Community Server from the official website: https://dev.mysql.com/downloads/mysql/.

3. Create a new MySQL database for the project.

4. Clone the project repository to your machine using the command git clone https://github.com/your-repository-link.

5. Navigate to the cloned project folder using the command cd project-folder-name.

6. Open the appsettings.json file and configure the MySQL database connection string. Replace the values for Server, Database, User Id, and Password with your own database settings.

7. Run the command dotnet ef database update to create the database tables and relationships in MySQL.

8. Run the command dotnet run to start the project's web server.

9. Open a web browser and access the URL http://localhost:5000 to view the project's home page.

That's it! You have successfully installed and set up the project. Now you can explore the functionality and start developing new features using the latest .NET technologies and concepts.

## Project Images

<p align="center">
  <span>Application Image</span>
  <img src="./asserts/imgs/App.jpeg" alt="Project Image, Application Image">
</p>

The image showcases the application overview using Swagger as the API documentation. Swagger is a powerful tool for documenting and exploring APIs, making it easier to understand and consume the available endpoints in a system.

The image displays a user-friendly and intuitive Swagger interface, presenting a list of different API endpoints. Each endpoint is accompanied by relevant information, such as the associated HTTP method (GET, POST, PUT, DELETE), the endpoint URL, and a brief description of its functionality.

Additionally, the image highlights the required parameters for each endpoint, including the expected input format and available options. This information helps developers and API consumers understand how to interact with each endpoint and what data is necessary to perform desired operations.

Swagger also provides clear and detailed examples of requests and responses, allowing developers to visualize the data they need to send and receive for each API call. This reduces errors and simplifies the integration process with the application.

In summary, the image demonstrates the use of Swagger as an essential tool for API documentation, offering an overview of the application and facilitating understanding and interaction with the various available endpoints.

<p align="center">
  <span>Image of product endpoints</span>
  <img src="./asserts/imgs/CRUDProduct.jpeg" alt="Project Image, Product endpoints">
</p>

Listed endpoints:

1. GET /products: Retrieves a list of all products.
2. GET /products/{id}: Retrieves a specific product by its ID.
3. POST /products: Creates a new product.
4. PUT /products/{id}: Updates an existing product by its ID.
5. DELETE /products/{id}: Deletes a product by its ID.

These are basic CRUD (Create, Read, Update, Delete) operations commonly used in RESTful APIs. 

<p align="center">
  <span>Image of store endpoints</span>
  <img src="./asserts/imgs/CRUDStore.jpeg" alt="Project Image, Store endpoints">
</p>

Image with their respective endpoints, however, some functions and some endpoints still need to be implemented here, which are more specific to add and remove products from the stock based on the store. List endpoints, however, here is for stockItem, not for products
1. GET /stockItems: Retrieve a list of all products.
2. GET /stockItems/{id}: Retrieve a specific product by its ID.
3. POST /stockItems: Creates a new product.
4. PUT /stockItems/{id}: Updates an existing product by its ID.
5. DELETE /stockItems/{id}: Deletes a product by its ID.

These are basic CRUD (Create, Read, Update, Delete) operations commonly used in RESTful APIs.

<p align="center">
  <span>Image of stockItem endpoints</span>
  <img src="./asserts/imgs/CRUDStockItem.jpeg" alt="Project Image, StockItems endpoints">
</p>

Image with their respective endpoints, list the endpoints, as if it were here, however, here 'and store, instead of product
1. GET /stores: Retrieves a list of all products.
2. GET /stores/{id}: Retrieve a specific product by its ID.
3. POST /stores: Creates a new product.
4. PUT /stores/{id}: Updates an existing product by its ID.
5. DELETE /stores/{id}: Deletes a product by its ID.

These are basic CRUD (Create, Read, Update, Delete) operations commonly used in RESTful APIs.

<p align="center">
  <span>Relationship diagram</span>
  <img src="./asserts/imgs/UML.jpeg" alt="Project Image, Relationship diagram">
</p>

The diagram illustrates the relationships between three entities: Product, StockItem, and Store. It is a UML diagram representing the associations between these entities.

The relationships depicted in the diagram are as follows:

- Product 1-0..1 StockItem: This relationship signifies that a Product can have zero or one associated StockItem. It implies that a Product may or may not be in stock, and if it is in stock, there will be a corresponding StockItem.

- StockItem 0..1 - 1 Store: This relationship represents that a StockItem belongs to exactly one Store, while a Store can have zero or one associated StockItem. It implies that a Store may or may not have a specific StockItem in its inventory.

## Technologies used:

This project utilizes the following technologies and libraries for developing a .NET 7.0 API for managing products, stores, and product inventory:

- .NET 7.0: The latest version of the .NET framework, providing enhanced features and improved performance.
- Entity Framework Core: An object-relational mapping (ORM) framework for interacting with the database and performing CRUD operations.
- MySQL: A popular relational database management system used for storing and retrieving data.
- AutoMapper: A library for object-to-object mapping, simplifying the process of mapping DTOs (Data Transfer Objects) to entity models and vice versa.
- FluentValidation: A library for validating objects, ensuring the data meets specific criteria.

By using .NET 7.0, Entity Framework Core, MySQL, and other libraries, this API enables developers to efficiently manage products, stores, and inventory for a given store. It provides endpoints for creating, retrieving, updating, and deleting products, stores, and inventory items. Additionally, it allows for adding and removing products from a store's inventory while tracking the available quantity.

Throughout the development of this project, I gained valuable experience in working with the latest technologies and concepts in the .NET ecosystem. By leveraging the power of .NET 7.0, I was able to take advantage of its enhanced features and performance improvements. Entity Framework Core facilitated seamless database interactions, and MySQL served as a reliable and scalable storage solution.

Moreover, AutoMapper simplified the mapping process between DTOs and entity models, reducing manual coding efforts. FluentValidation ensured that data passed through the API met the required validation rules, enhancing data integrity and reliability.

This project was an opportunity to expand my knowledge and skills in API development using .NET, and I successfully leveraged the latest technologies and concepts to deliver a robust and efficient solution.
