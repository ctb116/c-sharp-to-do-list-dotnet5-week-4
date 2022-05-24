Following this lesson: [Many-to-Many Relationships: Join Entities](https://www.learnhowtoprogram.com/c-and-net/many-to-many-relationships/many-to-many-relationships-join-entities)

This lesson will walk through refactoring our existing ToDoList project to:
1. Use Entity migrations to automatically manage our database updates so we no longer have to update our databases manually. <br>
2. Update our project to use Many-to-Many relationships

In this repo - this branch `1_to_2`, contains notes about changes that happen from branch `1_initial` to `2_m2m_join_entities` 

--- 

# Steps

1. Delete any existing `to_do_list` database in MySQL Workbench. Right-click the database and Drop Schema. <br>

Further notes for each step can be found in file. <br>

2. Update `Models/Category.cs` <br>

3. Update `Models/Item.cs` <br>

4. Create `Models/CategoryItem.cs` <br>

5. Update `Models/ToDoListContext.cs` <br>

6. Create `Models/DesignTimeDbContextFactory.cs` <br>

7. Add new package `dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0`

8. Comment out code in Controllers and Views because we are not concerned with front-end for now and we don't want anything to accidently interfer with our first attempt at Entity Migrations. Comment out code in `HomeController.cs`, `ItemsController.cs`, and `CategoriesController.cs`. Comment out all code in all `.cshtml` files using `@* Code to be commented *@`

9. run `dotnet build` in ToDoList directory. Should have no errors

10. run `dotnet ef migrations add Initial` in ToDoList directory. Creates a `Migrations` directory with three files.

11. run `dotnet ef database update` to apply migration to our database. Can check MySQL Workbench to see the changes.
<br><br>

---

# Glossary and resources
virtual https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual - new access modifier. In our case, allows the property to be to overridden in a derived class (or the class that inherits it)
This example is good 
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/virtual#example
Since there is no paired override access modifer I asumme that Entiy is doing that

Inheritance - derive types https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance


scaffold from Entity " We will use the scaffold that Entity provides for our migration. When we run this command, Entity looks at all our models and then creates our migration based on that."

The JOIN entity is a class that creates a relationship between two classes (e.i Category and Item). The class is called CategoryItem (alphabetical combination of the two classes)
- Entity needs properties 

https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#many-to-many
<br><br>

---

# More Info 
## IDesignTimeDbContextFactory<TContext> Interface
### What's in the `DesignTimeDbContextFactory.cs` file?
<br>

The [docs](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-5.0)
First understanding hte word "derived"

design time = just the time when we are writing (in other words, actually creating or designing our code) our application and not running it

---

## Migrations
### What just happened?
<br>

The docs on [Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) go into a lot of information about migrations. When presented with a lot of information and not a lot of time - I try to answer these questions:

1. **What is the general take-a-way here?** The general take-a-way is that updating a database manually is a lot of work so Entity migrations do that for us. Enity uses the application's data models (in other words - what's in the Models directory) to make a database. I don't fully understand how this tool works but I understand what this tool is for.

2. **What do I know or what sounds familiar?** A `migration` (lower case) is a snapshot of the database in that point in time based on what the application's data models look like. I can create many migrations. I use Entity to update my actual database that I can see in MySQL Workshop. When I do, Entity will sequentially apply the changes in each migration up to the latest one. It sounds similar to how git takes a snapshot of my project each time I make a commit.

3. **What knowledge gaps do I have?** I don't really understand line by line what is happening in `DesignTimeDbContextFactory.cs` or what's happening in any files in the  `Migrations` directory. **Is this knowledge gap okay?** Yes, I don't think I need to know what exactly is going on here before moving on. I trust I will over time and with more practice. <br>

    I know generally that `DeisgnTimeDbContextFactory.cs` helps our application find our database. If I get any errors that sound similar to this purpose I should check here first. I can read more on [these docs later](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-5.0)

    For the files in the `Migration` directory. `[Timestamp]_Initial.Designer.cs` is metadata for Entity and `MyContextModelSnapshot.cs` is the snapshot of the database that Entity will use. I know I don't need to touch these. 
    
    The first file `[Timestamp]_Initial.cs` can be edited. This file controls how Entity will scaffold (basically to create the thing our database needs to update) migrations based off our models. If Entity is not scaffolding the migration the way I want - I should learn more about this file and how to edit it.

