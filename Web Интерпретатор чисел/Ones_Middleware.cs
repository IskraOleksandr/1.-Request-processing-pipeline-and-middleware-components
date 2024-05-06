namespace Number_interpreter
{ 
    public class Ones_Middleware
    { 
        private readonly RequestDelegate _next; 
        public Ones_Middleware(RequestDelegate next)
        {
            _next = next;
        }
         
        public async Task Invoke(HttpContext context)
        { 
            string? token = context.Request.Query["number"];
            try
            { 
                var number = Convert.ToInt32(token);
                number = Math.Abs(number); 
                if (number == 10)
                {
                    await context.Response.WriteAsync("Your number is " + context.Session.GetString("number") + " " +
                                                      "ten");
                } 
                else
                { 
                    number %= 10; 
                    if (number > 0)
                    {
                        string[] Numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                        var ses = context.Session.GetString("number");
                        context.Session.SetString("number", ses + " " + Numbers[number - 1]);
                        var newses = context.Session.GetString("number"); 
                        await context.Response.WriteAsync("Your number is " + context.Session.GetString("number"));
                    }
                    else
                    { 
                        await context.Response.WriteAsync("Your number is " + context.Session.GetString("number"));
                    }
                }
            } 
            catch (Exception)
            {
                await context.Response.WriteAsync("Incorrect parameter");
            }
        }
    }
}