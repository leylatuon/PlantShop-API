# PlantShop-API
Final Project for API class, the only thing that was changed from my original proposal was the additional constraints on my columns that include NOT NULL.

## Endpoints
| API | Description | Request Body | Response Body |
| --- | --- | --- | --- |
| POST https://localhost:7081/api/order | Add an order to orders | Order object | Order object |
| GET https://localhost:7081/api/order | Get all orders | None | Array of order objects |
| GET https://localhost:7081/api/order/{order_id} | Gets a specific order | None | Order object |
| PUT https://localhost:7081/api/order/{order_id} | Updates a specific order | Order object | None |
| DELETE https://localhost:7081/api/order/{order_id} | Deletes a specific order | None | None |
| POST https://localhost:7081/api/orderitem | Add an order item to order items | Order item object | Order item object |
| GET https://localhost:7081/api/orderitem | Get all order items | None | Array of order item objects |
| GET https://localhost:7081/api/orderitem/{orderitemid} | Gets a specific order item | None | Order item object |
| PUT https://localhost:7081/api/orderitem/{orderitemid} | Updates a specific order item | Order item object | None |
| DELETE https://localhost:7081/api/orderitem/{orderitemid} | Deletes a specific order item | None | None |

### Sample Order Request Body
```
{
    "customerName": "Derick Dragonfruit",
    "customerEmail": "derick@fruit.com",
    "customerAddress": "123 Orchard St, Randomcity USA",
    "orderDate": "2023-01-01T00:00:00",
    "totalPrice": 111.11,
    "fulfillmentStatus": "Pending",
    "orderItems": [
        {
            "plantName": "Carnation",
            "quantity": 2,
            "unitPrice": 20.00
        }
    ]
}
```
### Sample Order Response Body
```
{
    "statusCode": 200,
    "statusDescription": "Retrieved orders successfully",
    "orders": [
        {
            "orderId": 1,
            "customerName": "Annie Apple",
            "customerEmail": "annie@apple.com",
            "customerAddress": "123 Orchard St, Randomcity USA",
            "orderDate": "2023-01-01T00:00:00",
            "totalPrice": 50.50,
            "fulfillmentStatus": "Pending",
            "orderItems": [
                {
                    "itemId": 2,
                    "plantName": "Tulip",
                    "quantity": 5,
                    "unitPrice": 5.00,
                    "orderId": 1
                },
                {
                    "itemId": 1,
                    "plantName": "Rose",
                    "quantity": 2,
                    "unitPrice": 10.00,
                    "orderId": 1
                }
            ]
        },
        {
            "orderId": 2,
            "customerName": "Billy Banana",
            "customerEmail": "billy@banana.com",
            "customerAddress": "456 Monkey Ave, Randomcity USA",
            "orderDate": "2023-02-02T00:00:00",
            "totalPrice": 75.21,
            "fulfillmentStatus": "Shipped",
            "orderItems": [
                {
                    "itemId": 4,
                    "plantName": "Daisy",
                    "quantity": 10,
                    "unitPrice": 2.50,
                    "orderId": 2
                }
            ]
        }
    ],
    "orderItems": null
}
```
### Sample Order Item Request Body
```
{
    "plantName": "Philodendron",
    "quantity": 1,
    "unitPrice": 124.00,
    "OrderId": 1
}
```
### Sample Order Item Response Body
```
{
    "statusCode": 200,
    "statusDescription": "Retrieved successfully",
    "orders": null,
    "orderItems": [
        {
            "itemId": 1,
            "plantName": "Rose",
            "quantity": 2,
            "unitPrice": 10.00
        }
    ]
}
```
