# Blazor Polygon.io dashboard
This is a Blazor WebAssembly application that can fetch, display and store data from Polygon.io.

## How it works
- Since Polygon's free API is limited, caching is implemented to reduce the number of requests made.

- The cached data, as well as user accounts and their followed tickers are stored in a local MS SQL database.

- Entity Framework is used for database management.

## Credits
+ https://polygon.io/ - financial data
+ https://mudblazor.com/ - UI components
+ https://www.syncfusion.com/ - Blazor Stock Chart component
