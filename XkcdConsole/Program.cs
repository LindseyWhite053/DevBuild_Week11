Console.Write("Enter a number to view a comic: ");

int input = int.Parse(Console.ReadLine().Trim());

// API: https://xkcd.com/info.0.json

// Connects to the server 
HttpClient web = new HttpClient();

//separated into the base website and the path 
//base website
web.BaseAddress = new Uri("https://xkcd.com/");

// set up a connection with a path 
var connection = await web.GetAsync($"{input}/info.0.json");

try
{
    // Connect to the server and create a class with the data returned
    Comic com = await connection.Content.ReadAsAsync<Comic>();

    Console.WriteLine(com.alt);
    Console.WriteLine(com.img);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


//// communicate with the server and return a string 
//string result = await connection.Content.ReadAsStringAsync();

//Console.WriteLine(result);






class Comic
{
    public int month { get; set; }
    public int num { get; set; }
    public string link { get; set; }
    public int year { get; set; }
    public string news { get; set; }
    public string safe_title { get; set; }
    public string transcript { get; set; }
    public string alt { get; set; }
    public string img { get; set; }
    public string title { get; set; }
    public int day { get; set; }
}

