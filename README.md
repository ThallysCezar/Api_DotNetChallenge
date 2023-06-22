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

<!-- ## Project Images

<p align="center">
  <span>Image Home Page</span>
  <img src="Assets/img/img.png" alt="Project Image, Home Page">
</p>

The homepage with the Localiza car image slider was a way to draw the user's attention to the company, showcasing car images dynamically. Additionally, the technologies table could be a way to show users the technologies used in the project development, providing relevant information.

<p align="center">
  <span>Image Vehicle category</span>
  <img src="Assets/img/img2.png" alt="Project Image, Vehicle category">
</p>

On the car group page, the table to edit, view details, and delete each car group offers users the possibility of managing information about each department of the company in an organized way. This can make it easier to maintain information and allow for better business management.

<p align="center">
  <span>Image Sellers Page</span>
  <img src="Assets/img/img3.png" alt="Project Image, Sellers Page">
</p>

On the sellers page, the table with the options to edit, view details, and delete each seller provides a way to manage employee information. Additionally, the ability to create new sellers can be useful for the company in cases of new hires.

<p align="center">
  <span>Image Search Page</span>
  <img src="Assets/img/img4.png" alt="Project Image, Search Page">
</p>

The search page can be a way to facilitate searching for specific information within the system. The simple search and the group search can offer different search options for users, helping them find the information they need more quickly and efficiently. The use of start and end dates can be useful for filtering results according to the desired period. -->

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
