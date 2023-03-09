# Sort an array of object with the key I choose

## Example

```
package play

orders := [
	{
		"name": "Jeff",
		"id": 3,
		"count": 10,
	},
	{
		"name": "Peter",
		"id": 4,
		"count": 5,
	},
	{
		"id": 2,
		"name": "Karen",
		"count": 3,
	},
]

names := [x.name | x := orders[_]]

sorted_names := sort(names)

sorted_orders := [x | 
	n := sorted_names[_] 
	x := orders[_]
    x.name == n
]

```

Output

```
{
    "names": [
        "Jeff",
        "Peter",
        "Karen"
    ],
    "orders": [
        {
            "count": 10,
            "id": 3,
            "name": "Jeff"
        },
        {
            "count": 5,
            "id": 4,
            "name": "Peter"
        },
        {
            "count": 3,
            "id": 2,
            "name": "Karen"
        }
    ],
    "sorted_names": [
        "Jeff",
        "Karen",
        "Peter"
    ],
    "sorted_orders": [
        {
            "count": 10,
            "id": 3,
            "name": "Jeff"
        },
        {
            "count": 3,
            "id": 2,
            "name": "Karen"
        },
        {
            "count": 5,
            "id": 4,
            "name": "Peter"
        }
    ]
}
```