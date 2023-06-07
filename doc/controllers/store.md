# Store

Access to Petstore orders

Find out more about our store: [http://swagger.io](http://swagger.io)

```csharp
StoreController storeController = client.StoreController;
```

## Class Name

`StoreController`

## Methods

* [Get Inventory](../../doc/controllers/store.md#get-inventory)
* [Place Order](../../doc/controllers/store.md#place-order)
* [Get Order by Id](../../doc/controllers/store.md#get-order-by-id)
* [Delete Order](../../doc/controllers/store.md#delete-order)


# Get Inventory

Returns a map of status codes to quantities

```csharp
GetInventoryAsync()
```

## Response Type

`Task<Dictionary<string, int>>`

## Example Usage

```csharp
try
{
    Dictionary<string, int> result = await storeController.GetInventoryAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Place Order

Place a new order in the store

```csharp
PlaceOrderAsync(
    long? id = null,
    long? petId = null,
    int? quantity = null,
    DateTime? shipDate = null,
    Models.OrderStatusEnum? orderStatus = Models.OrderStatusEnum.Approved,
    bool? complete = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `id` | `long?` | Form, Optional | - |
| `petId` | `long?` | Form, Optional | - |
| `quantity` | `int?` | Form, Optional | - |
| `shipDate` | `DateTime?` | Form, Optional | - |
| `orderStatus` | [`Models.OrderStatusEnum?`](../../doc/models/order-status-enum.md) | Form, Optional | Order Status<br>**Default**: `OrderStatusEnum.approved` |
| `complete` | `bool?` | Form, Optional | - |

## Response Type

[`Task<Models.Order>`](../../doc/models/order.md)

## Example Usage

```csharp
long? id = 10L;
long? petId = 198772L;
int? quantity = 7;
DateTime? shipDate = DateTime.ParseExact(
        "05/31/2023 00:00:00",
        "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
        provider: CultureInfo.InvariantCulture,
        DateTimeStyles.RoundtripKind);
Models.OrderStatusEnum? orderStatus = OrderStatusEnum.Approved;
bool? complete = true;
try
{
    Order result = await storeController.PlaceOrderAsync(id, petId, quantity, shipDate, orderStatus, complete);
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
| 405 | Invalid input | `ApiException` |


# Get Order by Id

For valid response try integer IDs with value <= 5 or > 10. Other values will generate exceptions.

```csharp
GetOrderByIdAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of order that needs to be fetched |

## Response Type

[`Task<Models.Order>`](../../doc/models/order.md)

## Example Usage

```csharp
long orderId = 62L;
try
{
    Order result = await storeController.GetOrderByIdAsync(orderId);
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
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Order not found | `ApiException` |


# Delete Order

For valid response try integer IDs with value < 1000. Anything above 1000 or nonintegers will generate API errors

```csharp
DeleteOrderAsync(
    long orderId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `orderId` | `long` | Template, Required | ID of the order that needs to be deleted |

## Response Type

`Task`

## Example Usage

```csharp
long orderId = 62L;
try
{
    await storeController.DeleteOrderAsync(orderId);
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
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Order not found | `ApiException` |

