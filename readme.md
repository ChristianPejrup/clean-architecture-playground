# Account service demo repository

Intention of the repository is to try and show small **oppinionated** optimizations that can be implemented with Clean/Onion architecture to limit overhead.

**TODO**

[x] Domain service(s)

[x] Generic Exception handling with domain exceptions

[ ] EF Core mapping class implementation (don't use annotations on Domain objects, don't annotate Dto's and map them to the Domain type)

[ ] HATEOAS Driven resources

[ ] Docker development environment

[ ] Local Kubernetes development [Tilt](https://tilt.dev/) 

[ ] Specflow integration test(s)

[x] Mediatr (CQRS)


## Domain Services

**Status: Started**

Typical implementations of Clean/Onion architecture will put interfaces for accessing domain types (typically repositories) in the Application Service project.

The result of this is typicall that all projects end up referencing both Domain (for concreat type) and the Application Service for the service to retrieving or persisting the domain entity.

Moving **interfaces** that purely deal with **domain types** into the domain (eg. domain services) reduces the dependency on the Application Service layer.

*To prevent the repository pattern from being used in the domain, a CQRS inspired Domain service with more generic naming have been used.*

**Projects**
* Account.Domain

## Exception handling

**Status: Done**

Many people prefere to handle exceptions in the controller or application service and then use the controller to donfigure both the normal success response and error handling.

An alternative to this approach is do use a global exception filter, excapsulating the global way of handling exception in one central place (this could obviously be a function that every controller could call, but it would require each controller action to have a try/catch blog).

To support better error messages for application specific errors a set of generic exceptions are used 
* BaseException
* NotFoundException
* Unauthorized

These exceptions get translated to the appropriate HTTP status code and they retain their error messages.

Any message not inheriting from the BaseException will have message and stack trace removed - this is intentional to not cause leak of internal application logic to end users or consumers of the API.

**Projects**
* Shared.Exceptions (Base exceptions)
    * In use in Account.Infrastructure.Sql 
    * *Could also be used directly in the Domain*
* Shared.AspNetCore.Mvc.Abstractions (Global exception handling)


### Client side exception handling

HTTP Status codes are interpreted into a error message representing the status code (not the same class as server side) and thrown as part of processing a request.

This is a very oppinionated approach that ensure that the consumer of the service (asuming they didnt generate their client from Swagger) can just rely on normal exception handling in place of testing status codes on the individual http request(s).

## EF Core mapping files (Fluent API)

**Status: Not started**

Using mapping files in place of EF Core annotations allow's **reader(s)** and **writer(s)** to work directly with domain types without

1. Putting annotation directly on the domain entities
2. Seperate persistance entities that EF Core loades data to before mapping their content to the domain entity (or the other way around)

Some one will make the argument that **persistance model != domain model** and this is a perfectly valid point. Mapping files do support splitting an entity into multiple tables or saving properties with a more appropriate database naming scheme.

[Use fluent API to configure a model](https://learn.microsoft.com/en-us/ef/core/modeling/#use-fluent-api-to-configure-a-model)

## HATEOAS Driven resources

**Status: Not started**

Using HATEOAS can make working with/consuming the API a lot simpler. At it's core this is achieved by adding a list of links on each object returned from the API. 

As there can be a significant amount of content overhead in embedding these links into each object, I prefere to just include the GET links and have a potential consumer rely on Swagger for the rest.

[HATEOAS Driven REST APIs](https://restfulapi.net/hateoas/)

## Docker development environment

**Status: Not started**

Docker Compose 

* Sql container
* Api container


