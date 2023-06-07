# User

Operations about user

```csharp
UserController userController = client.UserController;
```

## Class Name

`UserController`

## Methods

* [Create User](../../doc/controllers/user.md#create-user)
* [Create Users With List Input](../../doc/controllers/user.md#create-users-with-list-input)
* [Login User](../../doc/controllers/user.md#login-user)
* [Logout User](../../doc/controllers/user.md#logout-user)
* [Get User by Name](../../doc/controllers/user.md#get-user-by-name)
* [Update User](../../doc/controllers/user.md#update-user)
* [Delete User](../../doc/controllers/user.md#delete-user)


# Create User

This can only be done by the logged in user.

```csharp
CreateUserAsync(
    long? id = null,
    string username = null,
    string firstName = null,
    string lastName = null,
    string email = null,
    string password = null,
    string phone = null,
    int? userStatus = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `long?` | Form, Optional | - |
| `username` | `string` | Form, Optional | - |
| `firstName` | `string` | Form, Optional | - |
| `lastName` | `string` | Form, Optional | - |
| `email` | `string` | Form, Optional | - |
| `password` | `string` | Form, Optional | - |
| `phone` | `string` | Form, Optional | - |
| `userStatus` | `int?` | Form, Optional | User Status |

## Response Type

[`Task<Models.User>`](../../doc/models/user.md)

## Example Usage

```csharp
long? id = 10L;
string username = "theUser";
string firstName = "John";
string lastName = "James";
string email = "john@email.com";
string password = "12345";
string phone = "12345";
int? userStatus = 1;
try
{
    User result = await userController.CreateUserAsync(id, username, firstName, lastName, email, password, phone, userStatus);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Users With List Input

Creates list of users with given input array

```csharp
CreateUsersWithListInputAsync(
    List<Models.User> body = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`List<Models.User>`](../../doc/models/user.md) | Body, Optional | - |

## Response Type

[`Task<Models.User>`](../../doc/models/user.md)

## Example Usage

```csharp
try
{
    User result = await userController.CreateUsersWithListInputAsync(null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| Default | successful operation | `ApiException` |


# Login User

Logs user into the system

```csharp
LoginUserAsync(
    string username = null,
    string password = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `username` | `string` | Query, Optional | The user name for login |
| `password` | `string` | Query, Optional | The password for login in clear text |

## Response Type

`Task<string>`

## Example Usage

```csharp
try
{
    string result = await userController.LoginUserAsync(null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid username/password supplied | `ApiException` |


# Logout User

Logs out current logged in user session

```csharp
LogoutUserAsync()
```

## Response Type

`Task`

## Example Usage

```csharp
try
{
    await userController.LogoutUserAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Get User by Name

Get user by user name

```csharp
GetUserByNameAsync(
    string name)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Template, Required | The name that needs to be fetched. Use user1 for testing. |

## Response Type

[`Task<Models.User>`](../../doc/models/user.md)

## Example Usage

```csharp
string name = "name0";
try
{
    User result = await userController.GetUserByNameAsync(name);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid username supplied | `ApiException` |
| 404 | User not found | `ApiException` |


# Update User

This can only be done by the logged in user.

```csharp
UpdateUserAsync(
    string name,
    long? id = null,
    string username = null,
    string firstName = null,
    string lastName = null,
    string email = null,
    string password = null,
    string phone = null,
    int? userStatus = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Template, Required | name that need to be deleted |
| `id` | `long?` | Form, Optional | - |
| `username` | `string` | Form, Optional | - |
| `firstName` | `string` | Form, Optional | - |
| `lastName` | `string` | Form, Optional | - |
| `email` | `string` | Form, Optional | - |
| `password` | `string` | Form, Optional | - |
| `phone` | `string` | Form, Optional | - |
| `userStatus` | `int?` | Form, Optional | User Status |

## Response Type

`Task`

## Example Usage

```csharp
string name = "name0";
long? id = 10L;
string username = "theUser";
string firstName = "John";
string lastName = "James";
string email = "john@email.com";
string password = "12345";
string phone = "12345";
int? userStatus = 1;
try
{
    await userController.UpdateUserAsync(name, id, username, firstName, lastName, email, password, phone, userStatus);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Delete User

This can only be done by the logged in user.

```csharp
DeleteUserAsync(
    string name)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `name` | `string` | Template, Required | The name that needs to be deleted |

## Response Type

`Task`

## Example Usage

```csharp
string name = "name0";
try
{
    await userController.DeleteUserAsync(name);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid username supplied | `ApiException` |
| 404 | User not found | `ApiException` |

