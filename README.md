<h1 align="center"> Max & Arvids Anonymous forum: Weddit 🗣️ </h1>

<h4 align = center> Project members</h4>

<p align = center>
  &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="https://github.com/Sparven704">Arvid</a>
  &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="https://github.com/akaMaxg">Max</a>
  &nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;
</p>

<h4 align = center>
<a href="https://trello.com/b/z5FSNNJq/projekt-1-anonymt-forum">&nbsp; Trello Board</a>
</h4>

<h2>📚 Assignment Overview </h2>
The assignment was to create a forum-website with certain funcionality using ASP.NET MVC framework. The required functionality was amongst others:<br><br>

 - Using ASP.NET & Razor   
 - Persistance of data    
 - Validation of input    
 - Partial views    
 - ViewModels    
 - Database design   
 - Dont Repeat Yourself (DRY)


<h2>🌍 Product Solution </h2>

The result of the assignment is a ASP.NET MVC website that hosts forum functionality. It is possible to register as a user, log in and to view a pre-set of topics for which one can create posts. It is also possible to enter existing posts to commment on a specific posts. All data is persisted to the database. 

<h2>⌨️ Technological solution:</h2>

In a more technological perspective, the application is built in a MVC format. This means that the logic, data and views are separated. The model hosts the datastructure but is not utilized in the logic or views. By creating and utilizing Viewmodels, the application passes data between views and logic. The data is structured with 3 main models/classes. Topics, Posts, and comments. They follow a hierarchical structure and are tied to the superceding model. 
This means that every comment is tied to one superceding post, and every post is tied to one superceding topic. The foreign-keys in respective element are used to orient each element to its proper context. All elements that are created goes through a validation check to ensure proper information and formatting is passed to the DB. 

In addition we have elements of partial views, e.g. the header which are utilized as a main navigation bar to return to the start pages or similar. We have also applied the same and existing structure for the various controllers and views to avoid over-complicating the solutions. 

<h2>💻 Technology Stack</h2>   

- C#, HTML, CSS, EF

- ASP.NET: MVC

- GitHub: Version Control.

- Visual Studio and Visual Studio Code: IDEs

<h2>🏎️ To Run Application:   </h2>

To run the application, clone or fork the project then:   

- create DB migration ``` add-migration <MigrationName> ```
- update the DB ``` database-update ```
- Create dummy Topics using SQL query ```INSERT INTO Topics (```
- build application ```dotnet build```
- Register, Log in and use the website

<h2>✍🏽 Contribution and Feedback </h2>
If you would like to contribute to this project, please fork the repository and submit a pull request. All contributions, and feedbacks are welcome and appreciated!


