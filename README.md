# Blazor Polygon.io dashboard
This is a Blazor WebAssembly application that can fetch, display and store data from Polygon.io.

## How it works
- Since Polygon's free API is limited, caching is implemented to reduce the number of requests made.

- The cached data, as well as user accounts and their followed tickers are stored in a local MS SQL database.

- Entity Framework is used for database management.
## Prerequicites 
- Please make sure  to create localhost sql server on your machine
- create finance-prod db in that
- change the connection string in  https://github.com/harika469/PocketFinanceAPplication/blob/master/Server/appsettings.json
- Also change teh Polygon API key  in the appsettings.json file
- Run the code and make sure to verify the Database if all the tables are created or not
  

## Credits
+ https://polygon.io/ - financial data
+ https://mudblazor.com/ - UI components
+ https://www.syncfusion.com/ - Blazor Stock Chart component
