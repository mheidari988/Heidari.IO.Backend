# Heidari.IO.Backend

Backend project of the www.heidari.io website

## Configuration of the DbContext

The first step of wireing up the backend is to implement our database schema. we will do it by adding a new dbcontext class to the infrastrucutre layer. to do so, I will create a new folder inside the infrastructure layer `WebContents` and then I will add `WebContentsDbContext.cs` file inside it.
This will allow us to create a new database context that will be used to access the database. this dbcontext will inherit from the `DbContext` class that is provided by the Entity Framework Core. we will add DbSets for each of the entities that we will need to access in the database.

for adding the entities I will create a folder `Models` inside the `WebContents` folder and then I will add `Entity` record as a base record for all the entities that we will need to create. Then i will add all other entities that we will need.

However, as you know, we need to have configurations for each and every entity that we have. these configurations are called Entity Type Configurations and they are used to configure the behavior of the entities like relationships, max length, etc. We will create a new folder called `Configurations` inside the `WebContents` folder and then I will add a new class for each entity that we will need to create.

lets say that we have a `Skill` entity that has a relationship with the `Experience` entity. we will need to add a new class named `SkillTypeConfiguration` that will implements from the `IEntityTypeConfiguration<Skill>` interface. and then we will override the `Configure` method and add the relationship between the two entities or any other behavior that we need to add.
