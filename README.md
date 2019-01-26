## ASP.NET MVC online training

## ASP.NET MVC Fundamentals
	controllers, actions, routing, views and view models
	
## Entity Framework (Code-First)
	-DbContext<<database>>, DbSet<<table>>
	-LINQ(add/modity/delet) <<DbSet>>, SQL <<database>>
	-eager loading: load obj and related objs together
	
## Forms

## Validation
	-add data annotation to -entities:[Required],[StringLength(255)],[Range(1,10)],[Compare("OtherProperty")],[Phone],[EmailAddress],[Url],[RegularExpression("...")]
	-use ModelState to change the flow of program
	-add validation message to form
	-pure viewmodel implementation
	
## Build RESTful Services
	-Data Services(Web Application Programming Interfaces)
	-Less server resources (improve scalability)
	-Less bandwidth (improve performance)
	-Support for a broad range of clients
	-jQuery plugin:DataTable + WebAPI
	-Get|Post|Put|Delete
	-use automapper with custom DTOs instead of domain objects
	-install-package automapper -version:4.1
## Client-side Development
	-jQuery: Datatable and Bootbox.js
	-install-package bootbox -version:4.3.0
	-install-package jquery.datatables -version:1.10.11
	-Optimize jQuery code
	-add pagination, sorting
## Authentication and Authorization
	-Identity Framework(Domain:IdentityUser,Role;API/Service:UserManager,RoleManager,SignInManager;Persistence:UserStore,RoleStore)
	-use filters:[Authorize],[AllowAnonymous]
	-seeding users and roles
	-OAuth and Social Logins
## Performance Optimization
	-data tier: optimizing queries
	-install-package glimpse.mvc5
	-install-package glimpse.ef6
	-localhost:44300/glimpse.axd
	-application tier:OutputCaching[duration][location][varybyparam];memorycaching for data;release builds;disabling session
	-client tier:light weight dtos,use bundles on css and js
## Building a Feature Systematically (end to end)
	-install-package Twitter.Typeahead
	-install-package toastr
## Deployment
	-update-database -script
	-update-database -script -SourceMigration:<<start_from_migration_name>>
	-handle customErrors 
	-logging unhandled exceptions
	-install-package Elmah
	-localhost:44300/elmah.axd
	







