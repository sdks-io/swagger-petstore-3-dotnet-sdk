
# Order

## Structure

`Order`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `PetId` | `long?` | Optional | - |
| `Quantity` | `int?` | Optional | - |
| `ShipDate` | `DateTime?` | Optional | - |
| `OrderStatus` | [`Models.OrderStatusEnum?`](../../doc/models/order-status-enum.md) | Optional | Order Status<br>**Default**: `OrderStatusEnum.approved` |
| `Complete` | `bool?` | Optional | - |

## Example (as JSON)

```json
{
  "id": 10,
  "petId": 198772,
  "quantity": 7,
  "shipDate": "05/31/2023 00:00:00",
  "orderStatus": "approved",
  "complete": true
}
```

