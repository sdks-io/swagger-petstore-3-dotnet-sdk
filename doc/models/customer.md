
# Customer

## Structure

`Customer`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long?` | Optional | - |
| `Username` | `string` | Optional | - |
| `Address` | [`List<Models.Address>`](../../doc/models/address.md) | Optional | - |

## Example (as JSON)

```json
{
  "id": 100000,
  "username": "fehguy",
  "address": [
    {
      "street": "street4",
      "city": "city4",
      "state": "state0",
      "zip": "zip8"
    }
  ]
}
```

