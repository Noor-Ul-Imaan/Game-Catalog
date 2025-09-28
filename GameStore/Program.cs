using GameStore.Data;
using GameStore.Endpoints; //automatically added when you wrote List>GameDto > 
//becuase it scanned for a GameDto type defined smehwere and found the record type file in Dto folder.

var builder = WebApplication.CreateBuilder(args);

//use builder object to configure services
var connString = builder.Configuration.GetConnectionString("GameStore");//root of your project
builder.Services.AddSqlite<GameStoreContext>(connString); //REGISTERING OUR DB CONTEXT INTO THE SERVICE PROVIDER
builder.Services.AddScoped<GameStoreContext>


var app = builder.Build();

app.MapGamesEndpoints();

// app.MapGet("/", () => "Hello World!");
// if request comes for get in the root, we will rely with this

app.MigrateDb();
app.Run();
