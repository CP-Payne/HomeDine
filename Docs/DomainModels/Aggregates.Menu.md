# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "A little fishy",
  "description": "A section for fish enthusiasts",
  "averageRating": 4.5,
  "section": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Pond fish",
      "description": "Fresh fish from  backyard pond!",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Salmon",
          "description": "Fresh salmon from  backyard pond!",
          "price": 7.99
        }
      ]
    }
  ],
  "createdDateTime": "2020-01-01T00:00:00.000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.000000Z",
  "hostId": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": ["00000000-0000-0000-0000-000000000000"],
  "menuReviewIds": ["00000000-0000-0000-0000-000000000000"]
}
```
